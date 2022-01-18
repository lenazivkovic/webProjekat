INSERT INTO Agencija (imeAgencije, adresa, email, kontaktTelefon)
VALUES ('ITravel' , 'Dusanova 3' , 'itravel@hotmail.com' , '065555478');
INSERT INTO Agencija (imeAgencije, adresa, email, kontaktTelefon)
VALUES ('Travellist' , 'Vojvode Misica 4' , 'travellist@gmail.com' , '063548876');

INSERT INTO Klijent (imeKlijenta,prezimeKlijenta, JMBG, grad, adresa, kontaktTelefon)
VALUES ('Misa' , 'Petrovic' , '1204998748512' , 'Nis','Vojvodjanska 76', '066748851');
INSERT INTO Klijent (imeKlijenta,prezimeKlijenta, JMBG, grad, adresa, kontaktTelefon)
VALUES ('Sasa' , 'Ilic' , '1805991245236' , 'Nis','Kubska 6', '066574111');
INSERT INTO Klijent (imeKlijenta,prezimeKlijenta, JMBG, grad, adresa, kontaktTelefon)
VALUES ('Ivana' , 'Mitic' , '1711987456287' , 'Leskovac','Malska bb', '064753126');
INSERT INTO Klijent (imeKlijenta,prezimeKlijenta, JMBG, grad, adresa, kontaktTelefon)
VALUES ('Katarina' , 'Dinic' , '0103989124365' , 'Nis','Niska 47', '062333658');
INSERT INTO Klijent (imeKlijenta,prezimeKlijenta, JMBG, grad, adresa, kontaktTelefon)
VALUES ('Sanja' , 'Petric' , '1106999128775' , 'Nis','Knjazevacka 132', '066521884');
INSERT INTO Klijent (imeKlijenta,prezimeKlijenta, JMBG, grad, adresa, kontaktTelefon)
VALUES ('Andrija' , 'Arsic' , '2608977135877' , 'Prokuplje','Vrtisna 7', '064111358');
INSERT INTO Klijent (imeKlijenta,prezimeKlijenta, JMBG, grad, adresa, kontaktTelefon)
VALUES ('Aleksandra' , 'Stojkovic' , '0505000195326' , 'Aleksinac','Tibetska bb', '061548889');
INSERT INTO Klijent (imeKlijenta,prezimeKlijenta, JMBG, grad, adresa, kontaktTelefon)
VALUES ('Filip' , 'Markovic' , '0504000857223' , 'Nis','Aleksinacka 24', '069554821');
INSERT INTO Klijent (imeKlijenta,prezimeKlijenta, JMBG, grad, adresa, kontaktTelefon)
VALUES ('Dragana' , 'Milanovic' , '1507976655123' , 'Krusevac','Cara Lazara 101', '065744100');
INSERT INTO Klijent (imeKlijenta,prezimeKlijenta, JMBG, grad, adresa, kontaktTelefon)
VALUES ('Marina' , 'Zivkovic' , '0205971244036' , 'Nis','Orasacka 6', '0646654052');

INSERT INTO Lokacija (grad,drzava, hotel,slika)
VALUES ('Pariz' , 'Francuska' , 'Baguette','./Slike/Pariz.jpg');
INSERT INTO Lokacija (grad,drzava, hotel,slika)
VALUES ('London' , 'Engleska' , 'Big Ben','./Slike/London.jpg');
INSERT INTO Lokacija (grad,drzava, hotel,slika)
VALUES ('Sofija' , 'Bugarska' , 'Sandy', './Slike/Sofija.jpg');
INSERT INTO Lokacija (grad,drzava, hotel,slika)
VALUES ('Skiathos' , 'Grcka' , 'Blue horizon', './Slike/Skiathos.jpg');
INSERT INTO Lokacija (grad,drzava, hotel,slika)
VALUES ('Tirana' , 'Albanija' , 'Havana', './Slike/Tirana.jpg');
INSERT INTO Lokacija (grad,drzava, hotel,slika)
VALUES ('Nottingham' , 'Engleska' , 'Hood','./Slike/Nottingham1.jpeg');
INSERT INTO Lokacija (grad,drzava, hotel,slika)
VALUES ('Bec' , 'Austrija' , 'Alpino', './Slike/Bec.jpg');
INSERT INTO Lokacija (grad,drzava, hotel,slika)
VALUES ('Krf' , 'Grcka' , 'Blues', './Slike/Krf.jpg');
INSERT INTO Lokacija (grad,drzava, hotel,slika)
VALUES ('Male' , 'Maldivi' , 'Paradise', './Slike/Male.jpg');
INSERT INTO Lokacija (grad,drzava, hotel,slika)
VALUES ('Tokyo' , 'Japan' , 'Nakamura','./Slike/Tokyo.jpg');
INSERT INTO Lokacija (grad,drzava, hotel,slika) 
VALUES ('Dablin' , 'Irska' , 'Clover', './Slike/Dablin.jpg');
INSERT INTO Lokacija (grad,drzava, hotel,slika)
VALUES ('Honolulu' , 'Amerika' , 'Limbo', './Slike/Honolulu.jpg');
INSERT INTO Lokacija (grad,drzava, hotel,slika)
VALUES ('Nottingham' , 'Engleska' , 'Prestige', './Slike/Nottingham.jpg');

INSERT INTO Ponuda (lokacijaID,cena, datum,agencijaID)
VALUES (3 , 10000,'2022-06-15T13:45:30', 1);
INSERT INTO Ponuda (lokacijaID,cena, datum,agencijaID)
VALUES (5 , 16500,'2022-03-11T13:45:30', 1);
INSERT INTO Ponuda (lokacijaID,cena, datum,agencijaID)
VALUES (4 , 25000,'2022-07-10T13:45:30', 1);
INSERT INTO Ponuda (lokacijaID,cena, datum,agencijaID)
VALUES (6 , 45000,'2022-04-10T13:45:30', 1);
INSERT INTO Ponuda (lokacijaID,cena, datum,agencijaID)
VALUES (9 , 100000,'2022-08-17T13:45:30', 1);
INSERT INTO Ponuda (lokacijaID,cena, datum,agencijaID)
VALUES (7 , 21000,'2022-04-15T13:45:30', 1);
INSERT INTO Ponuda (lokacijaID,cena, datum,agencijaID)
VALUES (1 , 30500,'2022-10-11T13:45:30', 2);
INSERT INTO Ponuda (lokacijaID,cena, datum,agencijaID)
VALUES (2 , 25000,'2022-04-10T13:45:30', 2);
INSERT INTO Ponuda (lokacijaID,cena, datum,agencijaID)
VALUES (8 , 12000,'2022-06-11T13:45:30', 2);
INSERT INTO Ponuda (lokacijaID,cena, datum,agencijaID)
VALUES (10 , 60000,'2022-08-25T13:45:30', 2);
INSERT INTO Ponuda (lokacijaID,cena, datum,agencijaID)
VALUES (11 , 36000,'2022-10-17T13:45:30', 2);
INSERT INTO Ponuda (lokacijaID,cena, datum,agencijaID)
VALUES (12 , 95000,'2022-07-28T13:45:30', 2);
INSERT INTO Ponuda (lokacijaID,cena, datum,agencijaID)
VALUES (13 , 30000,'2022-04-10T13:45:30', 1);

INSERT INTO Rezervacija (brojOsoba,brojDana, klijentID,ponudaID)
VALUES (2 , 7, 2, 2);
INSERT INTO Rezervacija (brojOsoba,brojDana, klijentID,ponudaID)
VALUES (3, 15, 7, 12);
INSERT INTO Rezervacija (brojOsoba,brojDana, klijentID,ponudaID)
VALUES (4, 10, 4, 10);
INSERT INTO Rezervacija (brojOsoba,brojDana, klijentID,ponudaID)
VALUES (3, 15, 9, 7);
INSERT INTO Rezervacija (brojOsoba,brojDana, klijentID,ponudaID)
VALUES (5, 7, 7, 4);
INSERT INTO Rezervacija (brojOsoba,brojDana, klijentID,ponudaID)
VALUES (2, 7, 1, 6);
INSERT INTO Rezervacija (brojOsoba,brojDana, klijentID,ponudaID)
VALUES (3, 10, 6, 8);
INSERT INTO Rezervacija (brojOsoba,brojDana, klijentID,ponudaID)
VALUES (2, 15, 3, 10);
INSERT INTO Rezervacija (brojOsoba,brojDana, klijentID,ponudaID)
VALUES (4, 15, 1, 11);
INSERT INTO Rezervacija (brojOsoba,brojDana, klijentID,ponudaID)
VALUES (2, 7, 5, 12);
INSERT INTO Rezervacija (brojOsoba,brojDana, klijentID,ponudaID)
VALUES (3, 15, 10, 1);
INSERT INTO Rezervacija (brojOsoba,brojDana, klijentID,ponudaID)
VALUES (2, 14, 5, 1);
INSERT INTO Rezervacija (brojOsoba,brojDana, klijentID,ponudaID)
VALUES (4, 10, 4, 9);
INSERT INTO Rezervacija (brojOsoba,brojDana, klijentID,ponudaID)
VALUES (2, 10, 1, 4);
INSERT INTO Rezervacija (brojOsoba,brojDana, klijentID,ponudaID)
VALUES (3, 7, 2, 12);
INSERT INTO Rezervacija (brojOsoba,brojDana, klijentID,ponudaID)
VALUES (3, 15, 9, 11);
INSERT INTO Rezervacija (brojOsoba,brojDana, klijentID,ponudaID)
VALUES (4, 15, 10, 4);
INSERT INTO Rezervacija (brojOsoba,brojDana, klijentID,ponudaID)
VALUES (5, 7, 8, 10);
INSERT INTO Rezervacija (brojOsoba,brojDana, klijentID,ponudaID)
VALUES (5, 15, 4, 5);
INSERT INTO Rezervacija (brojOsoba,brojDana, klijentID,ponudaID)
VALUES (4,7, 7, 8);

