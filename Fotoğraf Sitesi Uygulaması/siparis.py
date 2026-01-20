def main():
    print("Lütfen sipariş bilgilerini giriniz:")

    isim = input("İsim: ")
    adres = input("Adres: ")
    telefon = input("Telefon: ")
    foto = input("Fotoğraf Adı: ")
    adet = input("Adet: ")

    # Kaydedilecek veri formatı
    veri = f"İsim: {isim}, Adres: {adres}, Telefon: {telefon}, Fotoğraf: {foto}, Adet: {adet}\n"

    # Veriyi "siparisler.txt" dosyasına ekleyelim
    with open("siparisler.txt", "a") as file:
        file.write(veri)

    print("\n✅ Siparişiniz kaydedildi!")

if __name__ == "__main__":
    main()