import sys
import pyodbc
from PyQt5 import QtWidgets, QtGui, QtCore

# Veritabanı bağlantı bilgileri
DB_CONFIG = {
    'driver': '{SQL Server}',
    'server': 'DESKTOP-LPE01RK\\SQLEXPRESS',
    'database': 'YOUR_DB',
    'trusted_connection': 'yes'
}

class CaravanRentalApp(QtWidgets.QWidget):
    def __init__(self):
        super().__init__()
        self.initUI()

    def initUI(self):
        self.setWindowTitle("Karavan Park Kayıt Sistemi")

        layout = QtWidgets.QFormLayout()

        self.name_input = QtWidgets.QLineEdit(self)
        self.name_input.setPlaceholderText("Ad-Soyad")
        layout.addRow("Ad Soyad:", self.name_input)

        self.phone_input = QtWidgets.QLineEdit(self)
        self.phone_input.setPlaceholderText("Telefon")
        phone_validator = QtGui.QRegularExpressionValidator(QtCore.QRegularExpression(r"^\d{10,11}$"))
        self.phone_input.setValidator(phone_validator)
        layout.addRow("Telefon:", self.phone_input)

        self.address_input = QtWidgets.QLineEdit(self)
        self.address_input.setPlaceholderText("Adres")
        layout.addRow("Adres:", self.address_input)

        self.caravan_type = QtWidgets.QComboBox(self)
        self.caravan_type.addItems(["Motokaravan", "Çekme Karavan"])
        layout.addRow("Karavan Tipi:", self.caravan_type)

        self.parking_area = QtWidgets.QComboBox(self)
        self.parking_area.addItems(["5 m²", "10 m²", "15 m²"])
        layout.addRow("Park Alanı:", self.parking_area)

        self.guest_count = QtWidgets.QSpinBox(self)
        self.guest_count.setMinimum(1)
        layout.addRow("Kişi Sayısı:", self.guest_count)

        self.stay_duration = QtWidgets.QSpinBox(self)
        self.stay_duration.setMinimum(1)
        self.stay_duration.setSuffix(" Ay")
        layout.addRow("Konaklama Süresi:", self.stay_duration)

        self.payment_type = QtWidgets.QComboBox(self)
        self.payment_type.addItems(["Havale", "Kredi Kartı"])
        layout.addRow("Ödeme Tipi:", self.payment_type)

        self.save_button = QtWidgets.QPushButton("Kaydet")
        self.save_button.clicked.connect(self.save_data)
        layout.addRow(self.save_button)

        self.payment_button = QtWidgets.QPushButton("Ödeme Sayfasına Git")
        self.payment_button.clicked.connect(self.redirect_to_payment)
        layout.addRow(self.payment_button)

        self.setLayout(layout)
        self.show()

    def save_data(self):
        conn = None
        try:
            conn = pyodbc.connect(
                f"DRIVER={DB_CONFIG['driver']};"
                f"SERVER={DB_CONFIG['server']};"
                f"DATABASE={DB_CONFIG['database']};"
                f"Trusted_Connection={DB_CONFIG['trusted_connection']};"
            )
            cursor = conn.cursor()

            name = self.name_input.text().strip()
            phone = self.phone_input.text().strip()
            address = self.address_input.text().strip()
            caravan_type = self.caravan_type.currentText()
            parking_area = self.parking_area.currentText()
            guest_count = self.guest_count.value()
            stay_duration = self.stay_duration.value()
            payment_type = self.payment_type.currentText()

            if not name or not phone or not address:
                QtWidgets.QMessageBox.warning(self, "Uyarı", "Tüm alanları doldurun!")
                return

            # Fiyat hesaplama
            price_per_month = {"5 m²": 7500, "10 m²": 8500, "15 m²": 10000}
            paid_amount = price_per_month.get(parking_area, 0) * stay_duration

            # Tabloyu kontrol et (opsiyonel)
            cursor.execute("IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'CaravanUsers') "
                           "BEGIN CREATE TABLE CaravanUsers ("
                           "ID INT IDENTITY(1,1) PRIMARY KEY, "
                           "Name NVARCHAR(100), "
                           "Phone NVARCHAR(20), "
                           "Address NVARCHAR(255), "
                           "CaravanType NVARCHAR(50), "
                           "GuestCount INT, "
                           "StayDuration INT, "
                           "PaymentType NVARCHAR(50), "
                           "ParkingArea NVARCHAR(20), "
                           "PaidAmount DECIMAL(10,2)) END;")
            conn.commit()

            # Veriyi ekle
            cursor.execute('''
                INSERT INTO CaravanUsers (Name, Phone, Address, CaravanType, GuestCount, StayDuration, PaymentType, ParkingArea, PaidAmount)
                VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)
            ''', (name, phone, address, caravan_type, guest_count, stay_duration, payment_type, parking_area, paid_amount))
            conn.commit()

            QtWidgets.QMessageBox.information(self, "Başarı", "Kayıt başarıyla tamamlandı!")

        except pyodbc.Error as ex:
            QtWidgets.QMessageBox.critical(self, "Hata", f"Veritabanı hatası: {ex}")
        finally:
            if conn:
                conn.close()

    def redirect_to_payment(self):
        payment_url = QtCore.QUrl("https://www.example-payment-gateway.com")
        QtGui.QDesktopServices.openUrl(payment_url)
        QtWidgets.QMessageBox.information(self, "Ödeme Yönlendirme", "Ödeme sayfasına yönlendiriliyorsunuz...")

if __name__ == '__main__':
    app = QtWidgets.QApplication(sys.argv)
    window = CaravanRentalApp()
    sys.exit(app.exec_())