CREATE TABLE Prodotto (
	prodottoID INT PRIMARY KEY IDENTITY (1,1),
	codice VARCHAR(250) NOT NULL UNIQUE,
	nome VARCHAR(250) NOT NULL,
	descrizione VARCHAR(250),
	categoria VARCHAR (250) NOT NULL
);

CREATE TABLE Utente(
	utenteID INT PRIMARY KEY IDENTITY (1,1),
	username VARCHAR(250) NOT NULL,
	pass VARCHAR(250) NOT NULL,
	tipo VARCHAR(250) NOT NULL

);


INSERT INTO Prodotto (codice, nome, descrizione, categoria) 
VALUES ('P001', 'Smartphone', 'Telefono cellulare avanzato', 'Elettronica');

INSERT INTO Prodotto (codice, nome, descrizione, categoria) 
VALUES ('P002', 'Laptop', 'Computer portatile ad alte prestazioni', 'Elettronica');

INSERT INTO Prodotto (codice, nome, descrizione, categoria) 
VALUES ('P003', 'Cuffie Bluetooth', 'Cuffie wireless per l''ascolto di musica', 'Accessori');

INSERT INTO Prodotto (codice, nome, descrizione, categoria) 
VALUES ('P004', 'Borsa a tracolla', 'Borsa compatta per portare gli oggetti personali', 'Moda');

INSERT INTO Prodotto (codice, nome, descrizione, categoria) 
VALUES ('P005', 'Libro', 'Romanzo contemporaneo', 'Libri');

INSERT INTO Utente (username, pass, tipo) 
VALUES ('alice@example.com', 'password123', 'ADMIN');

INSERT INTO Utente (username, pass, tipo) 
VALUES ('bob@example.com', 'securepass', 'USER');

INSERT INTO Utente (username, pass, tipo) 
VALUES ('charlie@example.com', 'letmein', 'USER');

INSERT INTO Utente (username, pass, tipo) 
VALUES ('diana@example.com', 'strongpassword', 'ADMIN');

INSERT INTO Utente (username, pass, tipo) 
VALUES ('eve@example.com', 'password1234', 'USER');
SELECT * FROM Utente
