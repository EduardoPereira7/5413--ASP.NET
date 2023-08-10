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
    Id INT PRIMARY KEY,
    Titulo NVARCHAR(255) NOT NULL,
    Subtitulo NVARCHAR(255),
    Conteudo NVARCHAR(MAX) NOT NULL,
    DataPublicacao DATETIME NOT NULL,
    CategoriaId INT NOT NULL,
    UtilizadorId INT NOT NULL,
    FOREIGN KEY (CategoriaId) REFERENCES Categorias(Id),
    FOREIGN KEY (UtilizadorId) REFERENCES Utilizadores(Id)
);

CREATE TABLE Categorias (
	Id INT PRIMARY KEY,
    Nome NVARCHAR(100) NOT NULL,
)

insert into Artigos(Id,Titulo,Subtitulo,Conteudo,DataPublicacao,CategoriaId,UtilizadorId)
values (1,'teste','ertert','tret',GetDate(),2,2)

insert into Categorias
values(2,'Categoria 2')

select * from Utilizadores
select * from Artigos
select * from Categorias
