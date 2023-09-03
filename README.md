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
