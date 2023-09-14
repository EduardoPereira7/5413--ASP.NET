# 5413--ASP.NET

CREATE TABLE Utilizadores (
    Id INT PRIMARY KEY IDENTITY,
    Nome NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    Password NVARCHAR(100) NOT NULL,
    Verificado BIT NOT NULL DEFAULT 0,
    Tipo NVARCHAR(20) NOT NULL DEFAULT 'normalUser'
);


CREATE TABLE Artigos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Titulo NVARCHAR(255) NOT NULL,
    Subtitulo NVARCHAR(255),
    Conteudo TEXT NOT NULL,
    DataPublicacao DATETIME NOT NULL,
	Acessibilidade bit not null,
    CategoriaId INT NOT NULL,
    UtilizadorId INT NOT NULL,
    FOREIGN KEY (CategoriaId) REFERENCES Categorias(Id),
    FOREIGN KEY (UtilizadorId) REFERENCES Utilizadores(Id)
);

CREATE TABLE Categorias (
	Id INT IDENTITY(1,1) PRIMARY KEY,
    Nome NVARCHAR(100) NOT NULL,
)


select * from Utilizadores
select * from Artigos
select * from Categorias

delete from Utilizadores
delete from Artigos
delete from Likes
delete from Categorias

select * from Artigos
select * from Categorias
select * from Utilizadores
select * from Likes

DBCC CHECKIDENT ('Utilizadores', RESEED, 0);
DBCC CHECKIDENT ('Artigos', RESEED, 0);
DBCC CHECKIDENT ('Likes', RESEED, 0);
DBCC CHECKIDENT ('Categorias', RESEED, 0);

INSERT INTO Categorias (Nome) VALUES ('Tecnologia');
INSERT INTO Categorias (Nome) VALUES ('Saude');
INSERT INTO Categorias (Nome) VALUES ('Dinheiro');
INSERT INTO Categorias (Nome) VALUES ('Politica');
INSERT INTO Categorias (Nome) VALUES ('Carros');

INSERT INTO Utilizadores (Nome, Email, Password, Verificado, Admin) VALUES ('Admin', 'admin@admin.com', 'admin', 1, 1);
INSERT INTO Utilizadores (Nome, Email, Password, Verificado, Admin) VALUES ('Utilizador 2', 'email2@utilizador.com', 'senha2', 1, 0);
INSERT INTO Utilizadores (Nome, Email, Password, Verificado, Admin) VALUES ('Utilizador 3', 'email3@utilizador.com', 'senha3', 0, 0);