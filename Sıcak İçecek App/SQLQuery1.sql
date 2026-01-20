CREATE TABLE Satislar (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    MusteriAdi NVARCHAR(100),
    TurkKahvesiAdet INT,
    FiltreKahveAdet INT,
    CayAdet INT,
    ToplamTutar DECIMAL(10,2),
    SatisTarihi DATETIME DEFAULT GETDATE()
);
