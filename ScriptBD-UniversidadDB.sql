
IF DB_ID(N'UniversidadDB') IS NULL
BEGIN
    CREATE DATABASE UniversidadDB;
END
GO

USE UniversidadDB;
GO

---------------------------------------------------------------
-- 2) Limpiar (solo para desarrollo)
---------------------------------------------------------------
IF OBJECT_ID(N'Estudiante', N'U') IS NOT NULL DROP TABLE Estudiante;
IF OBJECT_ID(N'Carrera',    N'U') IS NOT NULL DROP TABLE Carrera;
IF OBJECT_ID(N'vw_Estudiantes', N'V') IS NOT NULL DROP VIEW vw_Estudiantes;
GO

---------------------------------------------------------------
-- 3) Tablas
---------------------------------------------------------------

-- 3.1) Carrera
CREATE TABLE Carrera
(
    Id      INT IDENTITY(1,1) NOT NULL,
    Nombre  NVARCHAR(150)     NOT NULL,

    CONSTRAINT PK_Carrera PRIMARY KEY CLUSTERED (Id),
    CONSTRAINT UQ_Carrera_Nombre UNIQUE (Nombre) 
);
GO

-- 3.2) Estudiante
CREATE TABLE Estudiante
(
    Id               INT IDENTITY(1,1) NOT NULL,
    Paterno          NVARCHAR(100)     NOT NULL,
    Materno          NVARCHAR(100)     NULL,   
    Nombres          NVARCHAR(150)     NOT NULL,
    FechaNacimiento  DATE              NOT NULL,
    Correo           NVARCHAR(256)     NOT NULL,
    CarreraId        INT               NOT NULL,

    CONSTRAINT PK_Estudiante PRIMARY KEY CLUSTERED (Id),

    -- Relación con Carrera
    CONSTRAINT FK_Estudiante_Carrera
        FOREIGN KEY (CarreraId) REFERENCES Carrera(Id)
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,

    -- Calidad de datos
    CONSTRAINT CK_Estudiante_FechaNacimiento
        CHECK (FechaNacimiento >= '1900-01-01' AND FechaNacimiento <= CAST(GETDATE() AS DATE))
);
GO

---------------------------------------------------------------
-- 4) Índices y restricciones adicionales
---------------------------------------------------------------
-- Correo único
CREATE UNIQUE INDEX UQX_Estudiante_Correo ON Estudiante(Correo);

-- Búsquedas por carrera
CREATE NONCLUSTERED INDEX IX_Estudiante_CarreraId ON Estudiante(CarreraId);
GO

---------------------------------------------------------------
-- 5) Datos de ejemplo (semilla)
---------------------------------------------------------------
INSERT INTO Carrera (Nombre)
VALUES (N'Ingeniería de Sistemas'),
       (N'Administración'),
       (N'Derecho');

INSERT INTO Estudiante (Paterno, Materno, Nombres, FechaNacimiento, Correo, CarreraId)
VALUES 
(N'García',  N'Lopez',   N'María Fernanda', '2001-04-12', N'maria.fernanda@uni.edu', 1),
(N'Ramos',   N'',        N'Luis Alberto',   '2000-11-03', N'luis.alberto@uni.edu',   2),
(N'Paredes', N'Castro',  N'Flor',           '1999-07-28', N'flor.paredes@uni.edu',   1);
GO

---------------------------------------------------------------
-- 6) Vista útil (opcional)
---------------------------------------------------------------
CREATE VIEW vw_Estudiantes
AS
SELECT  e.Id,
        e.Paterno,
        e.Materno,
        e.Nombres,
        e.FechaNacimiento,
        e.Correo,
        e.CarreraId,
        c.Nombre AS Carrera
FROM Estudiante e
JOIN Carrera   c ON c.Id = e.CarreraId;
GO

---------------------------------------------------------------
-- 7) Consultas de verificación
---------------------------------------------------------------
SELECT * FROM Carrera;
SELECT * FROM Estudiante;
SELECT * FROM vw_Estudiantes;
GO
