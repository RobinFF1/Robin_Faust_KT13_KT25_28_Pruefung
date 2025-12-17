USE master;
GO

IF DB_ID('StundenplanDB') IS NOT NULL
BEGIN
    ALTER DATABASE StundenplanDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE StundenplanDB;
END
GO

CREATE DATABASE StundenplanDB;
GO
USE StundenplanDB;
GO

-- 1) Klassen
CREATE TABLE Klassen (
    KlasseID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(20) NOT NULL UNIQUE
);

-- 2) Lehrer
CREATE TABLE Lehrer (
    LehrerID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL
);

-- 3) Zimmer
CREATE TABLE Zimmer (
    ZimmerID INT IDENTITY(1,1) PRIMARY KEY,
    Bezeichnung NVARCHAR(30) NOT NULL UNIQUE
);

-- 4) Stundenplaneinträge (Fakten-Tabelle)
CREATE TABLE StundenplanEintraege (
    EintragID INT IDENTITY(1,1) PRIMARY KEY,
    KlasseID INT NOT NULL,
    LehrerID INT NOT NULL,
    ZimmerID INT NOT NULL,
    Datum DATE NOT NULL,
    Uhrzeit TIME(0) NOT NULL,
    CONSTRAINT FK_Stundenplan_Klassen FOREIGN KEY (KlasseID) REFERENCES Klassen(KlasseID),
    CONSTRAINT FK_Stundenplan_Lehrer  FOREIGN KEY (LehrerID) REFERENCES Lehrer(LehrerID),
    CONSTRAINT FK_Stundenplan_Zimmer  FOREIGN KEY (ZimmerID) REFERENCES Zimmer(ZimmerID)
);

-- Testdaten
INSERT INTO Klassen (Name) VALUES ('INF22'), ('INF23');
INSERT INTO Lehrer (Name) VALUES ('M. Muster'), ('S. Beispiel');
INSERT INTO Zimmer (Bezeichnung) VALUES ('B201'), ('C105');

INSERT INTO StundenplanEintraege (KlasseID, LehrerID, ZimmerID, Datum, Uhrzeit)
VALUES (1, 1, 1, '2025-12-18', '08:15'),
       (1, 2, 2, '2025-12-18', '10:05');

-- Anzeige-Test
SELECT e.EintragID, k.Name AS Klasse, e.Datum, e.Uhrzeit, l.Name AS Lehrer, z.Bezeichnung AS Zimmer
FROM StundenplanEintraege e
JOIN Klassen k ON e.KlasseID = k.KlasseID
JOIN Lehrer  l ON e.LehrerID = l.LehrerID
JOIN Zimmer  z ON e.ZimmerID = z.ZimmerID
ORDER BY e.Datum, e.Uhrzeit;
