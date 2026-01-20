SELECT u.ad, u.soyad, r.konaklama_suresi, r.kisi_sayisi, r.odeme_turu, r.odeme_durumu 
FROM uyeler u
JOIN rezervasyonlar r ON u.uye_id = r.uye_id
WHERE r.odeme_durumu = 'Ödendi';
