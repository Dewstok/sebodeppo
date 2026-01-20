SELECT u.ad, u.soyad, k.karavan_turu 
FROM uyeler u
JOIN karavanlar k ON u.uye_id = k.uye_id;
