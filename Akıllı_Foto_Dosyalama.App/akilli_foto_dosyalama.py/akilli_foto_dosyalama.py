import os
import shutil
from datetime import datetime
from PIL import Image
from PIL.ExifTags import TAGS
import tkinter as tk
from tkinter import filedialog, messagebox


def cekim_tarihi_al(dosya_yolu):
    try:
        image = Image.open(dosya_yolu)
        exif = image._getexif()

        if exif:
            for tag_id, value in exif.items():
                tag = TAGS.get(tag_id, tag_id)
                if tag == "DateTimeOriginal":
                    return datetime.strptime(value, "%Y:%m:%d %H:%M:%S")
    except:
        pass

    zaman = os.path.getctime(dosya_yolu)
    return datetime.fromtimestamp(zaman)


def foto_kopyala():
    klasor = secilen_klasor.get()

    if not klasor or not os.path.exists(klasor):
        messagebox.showerror("Hata", "Geçerli bir klasör seçmelisin")
        return

    hedef_ana = os.path.join(klasor, "Duzenlenmis_Fotograflar")
    os.makedirs(hedef_ana, exist_ok=True)

    aylar = {
        "01": "Ocak", "02": "Subat", "03": "Mart", "04": "Nisan",
        "05": "Mayis", "06": "Haziran", "07": "Temmuz", "08": "Agustos",
        "09": "Eylul", "10": "Ekim", "11": "Kasim", "12": "Aralik"
    }

    sayac = 0

    for dosya in os.listdir(klasor):
        yol = os.path.join(klasor, dosya)

        if os.path.isfile(yol) and dosya.lower().endswith((".jpg", ".jpeg", ".png")):
            tarih = cekim_tarihi_al(yol)
            yil = str(tarih.year)
            ay = f"{tarih.month:02d}"

            hedef = os.path.join(hedef_ana, yil, f"{ay}_{aylar[ay]}")
            os.makedirs(hedef, exist_ok=True)

            shutil.copy2(yol, os.path.join(hedef, dosya))
            sayac += 1

    messagebox.showinfo("Tamamlandı", f"{sayac} fotoğraf başarıyla kopyalandı ✅")


def klasor_sec():
    yol = filedialog.askdirectory()
    secilen_klasor.set(yol)


# ---------------- GUI ----------------
pencere = tk.Tk()
pencere.title("📸 Akıllı Fotoğraf Dosyalayıcı")
pencere.geometry("420x220")
pencere.resizable(False, False)

secilen_klasor = tk.StringVar()

tk.Label(pencere, text="Fotoğraf Klasörü Seç", font=("Arial", 12)).pack(pady=10)

tk.Entry(pencere, textvariable=secilen_klasor, width=45).pack(pady=5)

tk.Button(pencere, text="📁 Klasör Seç", command=klasor_sec).pack(pady=5)
tk.Button(pencere, text="🚀 Başlat", command=foto_kopyala, bg="#4CAF50", fg="white").pack(pady=15)

pencere.mainloop()

