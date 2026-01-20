
import math
import matplotlib.pyplot as plt

def elektrik_proje_cizim():
    print("🔌 Gelişmiş Elektrik Proje Yardımcısı\n")

   
    uzunluk = float(input("Odanın uzunluğunu giriniz (m): "))
    genislik = float(input("Odanın genişliğini giriniz (m): "))
    priz_sayisi = int(input("Toplam priz sayısını giriniz: "))

    alan = uzunluk * genislik
    print(f"\n➡ Oda Alanı: {alan:.2f} m²")

    
    aydinlatma_sayisi = math.ceil(alan / 12)
    print(f"➡ Önerilen aydınlatma sayısı: {aydinlatma_sayisi} adet")

    
    aydinlatma_x = [uzunluk * (i+1) / (aydinlatma_sayisi+1) for i in range(aydinlatma_sayisi)]
    aydinlatma_y = [genislik / 2] * aydinlatma_sayisi

    priz_konumlari = [
        (0.5, 0.5),
        (uzunluk-0.5, 0.5),
        (0.5, genislik-0.5),
        (uzunluk-0.5, genislik-0.5)
    ]
    while len(priz_konumlari) < priz_sayisi:
        priz_konumlari.append((uzunluk/2, 0.5 + (len(priz_konumlari)*0.5)))

    # Yük hesaplamaları
    priz_gucu = 300  # W
    aydinlatma_gucu = 60  # W
    toplam_yuk = priz_sayisi * priz_gucu + aydinlatma_sayisi * aydinlatma_gucu
    akim = toplam_yuk / 230  # A

    print(f"\n🔋 Toplam Güç Tüketimi: {toplam_yuk} W")
    print(f"🔌 Tahmini Akım: {akim:.2f} A")

    # Sigorta önerisi
    if akim <= 10:
        sigorta = "10A"
    elif akim <= 16:
        sigorta = "16A"
    elif akim <= 20:
        sigorta = "20A"
    else:
        sigorta = "25A+ (yüksek yük)"

    print(f"🧯 Önerilen Sigorta: {sigorta}")

    # Kablo uzunluğu hesaplama (pano merkezi: 0,0)
    def kablo_uzunlugu(x, y):
        return math.sqrt(x**2 + y**2)

    priz_kablolari = [kablo_uzunlugu(x, y) for (x, y) in priz_konumlari[:priz_sayisi]]
    aydinlatma_kablolari = [kablo_uzunlugu(x, y) for x, y in zip(aydinlatma_x, aydinlatma_y)]
    toplam_kablo = sum(priz_kablolari + aydinlatma_kablolari)

    print(f"📏 Tahmini Toplam Kablo Uzunluğu: {toplam_kablo:.2f} m")

    
    fig, ax = plt.subplots()
    ax.set_xlim(0, uzunluk)
    ax.set_ylim(0, genislik)
    ax.set_aspect("equal")
    plt.title("Elektrik Planı (Yük ve Güzergahlar)")

  
    oda = plt.Rectangle((0, 0), uzunluk, genislik, fill=None, edgecolor="black", linewidth=2)
    ax.add_patch(oda)

    
    ax.scatter(aydinlatma_x, aydinlatma_y, c="yellow", marker="o", s=200, label="Aydınlatma")

    # Prizler ve kablo çizgileri
    etiket_eklenmis = False
    for (x, y) in priz_konumlari[:priz_sayisi]:
        ax.scatter(x, y, c="red", marker="s", s=100, label="Priz" if not etiket_eklenmis else "")
        ax.plot([0, x], [0, y], c="gray", linestyle="--")
        etiket_eklenmis = True

    # Aydınlatma kabloları
    for x, y in zip(aydinlatma_x, aydinlatma_y):
        ax.plot([0, x], [0, y], c="orange", linestyle=":")

    # Pano merkezi
    ax.scatter(0, 0, c="blue", marker="*", s=150, label="Pano")

    ax.legend()
    plt.pause(0.001)
    plt.show()
    input("Çizimi kapatmak için Enter'a basın...")


if __name__ == "__main__":
    elektrik_proje_cizim()