CREATE DATABASE TareaSemana9
GO
USE TareaSemana9

GO
CREATE TABLE Departamento(
idDepartamento INT IDENTITY(1,1) PRIMARY KEY,
Nombre NVARCHAR(150) NOT NULL,
);

GO
CREATE TABLE Persona(
idPersona INT IDENTITY(1,1) PRIMARY KEY,
Nombre NVARCHAR(150) NOT NULL,
Apellido NVARCHAR(150),
idDepartamento INT FOREIGN KEY REFERENCES Departamento(idDepartamento)
);

INSERT INTO Departamento (Nombre) VALUES ('Recursos Humanos');
INSERT INTO Departamento (Nombre) VALUES ('Soporte');
INSERT INTO Departamento (Nombre) VALUES ('Finanzas');

INSERT INTO Persona (Nombre, Apellido, idDepartamento) VALUES ('Juan', 'Pérez', 1);
INSERT INTO Persona (Nombre, Apellido, idDepartamento) VALUES ('Ana', 'Gómez', 2);
INSERT INTO Persona (Nombre, Apellido, idDepartamento) VALUES ('Luis', 'Martínez', 3);


GO
CREATE PROCEDURE spBuscarPersonaPorDepartamento
(
@pidDepartamento INT
)
AS
BEGIN
SELECT P.idPersona, P.Nombre,P.Apellido, D.Nombre AS 'NombreDepartamento'
FROM Persona P
INNER JOIN Departamento D
ON P.idDepartamento = D.idDepartamento
WHERE P.idDepartamento = @pidDepartamento;
END;

GO
CREATE PROCEDURE spListarDepartamentos
AS
BEGIN
SELECT D.idDepartamento,D.Nombre
FROM Departamento D
END


GO
CREATE PROCEDURE spListarPersonas
AS
BEGIN
SELECT P.idPersona,P.Nombre,P.Apellido, D.Nombre AS 'NombreDepartamento'
FROM Persona P
INNER JOIN Departamento D
ON P.idDepartamento = D.idDepartamento
END;