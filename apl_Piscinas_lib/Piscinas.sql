CREATE DATABASE db_Piscinas;
GO
USE db_Piscinas;
GO

CREATE TABLE [Tipos] (
    [Id]		INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    [Nombre]	NVARCHAR(100) NOT NULL,
	[Edad_Min]  INT NOT NULL,
	[Temperatura] DECIMAL(10,2) NOT NULL,
	[Profundidad] INT NOT NULL
);
GO

CREATE TABLE [Piscina] (
    [Id]			INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    [Nombre]		NVARCHAR(100) NOT NULL,
    [Tamaño]		DECIMAL(10,2) NOT NULL,
    [NumerMax]		INT NOT NULL DEFAULT 0,
    [Tipo]          INT NOT NULL REFERENCES [Tipos]([Id])
);
GO

CREATE TABLE [Historicos] (
    [Id]          INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    [Descripcion] NVARCHAR(100) NOT NULL,
    [Fecha]       DATETIME NOT NULL
);
GO


INSERT INTO [Tipos] (Nombre, Edad_Min, Temperatura, Profundidad) VALUES ('Olimpica', '20', '19.0', '20');
INSERT INTO [Tipos] (Nombre, Edad_Min, Temperatura, Profundidad) VALUES ('Amateur', '15', '22.0', '4');
INSERT INTO [Tipos] (Nombre, Edad_Min, Temperatura, Profundidad) VALUES ('Jacussi', '10', '30.0', '1');


