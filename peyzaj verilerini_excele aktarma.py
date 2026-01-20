import pandas as pd

# Değiştirilebilir Peyzaj Verileri Girilecek Excel İçin!
peyzaj_verisi = {
    "bitkisel_ogeler": {
        "ağaçlar": [
            {"tür": "Çınar", "yaş": 5, "adet": 12},
            {"tür": "Meşe", "yaş": 8, "adet": 7}
        ],
        "çalılar": [
            {"tür": "Lavanta", "yaş": 2, "adet": 30},
            {"tür": "Ortanca", "yaş": 3, "adet": 15}
        ],
        "çiçekler": [
            {"tür": "Lale", "yaş": 1, "adet": 100},
            {"tür": "Gül", "yaş": 2, "adet": 50}
        ]
    },
    "yapısal_ogeler": {
        "taş_döşeme": {"alan_m2": 120, "adet": 600},
        "beton_döküm": {"alan_m2": 80, "adet": 4},
        "bank": {"adet": 6},
        "çöp_kutusu": {"adet": 3}
    }
}

# Tablolama
def bitkisel_rapor(veri):
    bitkisel_listesi = []
    for kategori, ogeler in veri["bitkisel_ogeler"].items():
        for oge in ogeler:
            bitkisel_listesi.append({
                "Kategori": kategori.capitalize(),
                "Tür": oge["tür"],
                "Yaş": oge["yaş"],
                "Adet": oge["adet"]
            })
    return pd.DataFrame(bitkisel_listesi)

# Yapısal öğeleri tablolama
def yapısal_rapor(veri):
    yapısal_listesi = []
    for isim, detay in veri["yapısal_ogeler"].items():
        yapısal_listesi.append({
            "Öğe": isim.replace("_", " ").capitalize(),
            "Alan (m²)": detay.get("alan_m2", "-"),
            "Adet": detay.get("adet", "-")
        })
    return pd.DataFrame(yapısal_listesi)


bitkisel_df = bitkisel_rapor(peyzaj_verisi)
yapısal_df = yapısal_rapor(peyzaj_verisi)

# Excel e yaz
with pd.ExcelWriter("peyzaj_raporu.xlsx") as writer:
    bitkisel_df.to_excel(writer, sheet_name="Bitkisel Öğeler", index=False)
    yapısal_df.to_excel(writer, sheet_name="Yapısal Öğeler", index=False)

print("✅ Excel dosyası başarıyla oluşturuldu: peyzaj_raporu.xlsx")