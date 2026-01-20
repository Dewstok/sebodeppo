def main():
    print("📜 Sipariş Listesi")

    # Dosyanın var olup olmadığını kontrol et
    if os.path.exists("siparisler.txt"):
        with open("siparisler.txt", "r") as file:
            siparisler = file.readlines()

            if siparisler:
                for siparis in siparisler:
                    print(siparis.strip())  # strip() ile satır sonu boşlukları temizler
            else:
                print("Henüz sipariş yok.")
    else:
        print("Henüz sipariş yok.")

if __name__ == "__main__":
    import os
    main()
