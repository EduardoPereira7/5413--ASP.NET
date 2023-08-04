# 5413--ASP.NET

CREATE TABLE Utilizadores (
    Id INT PRIMARY KEY IDENTITY,
    Nome NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    Password NVARCHAR(100) NOT NULL,
    Verificado BIT NOT NULL DEFAULT 0,
    Tipo NVARCHAR(20) NOT NULL DEFAULT 'normalUser'
);

select * from Utilizadores
