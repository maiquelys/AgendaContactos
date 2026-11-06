CREATE DATABASE AgendaContactos;
GO

USE AgendaContactos;
GO

CREATE TABLE Grupo (
    IdGrupo INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL
);
GO

CREATE TABLE Contacto (
    IdContacto INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Telefono VARCHAR(10) NOT NULL UNIQUE,
    Correo VARCHAR(100) NOT NULL,
    IdGrupo INT NOT NULL,
    CONSTRAINT FK_Contacto_Grupo FOREIGN KEY (IdGrupo) REFERENCES Grupo(IdGrupo)
);
GO

INSERT INTO Grupo (Nombre) VALUES
('Familia'),
('Trabajo'),
('Amigos'),
('Universidad'),
('Otros');
GO

INSERT INTO Contacto (Nombre, Telefono, Correo, IdGrupo) VALUES
('Ana Martínez', '8095551001', 'ana.martinez@gmail.com', 1),
('Pedro Gómez', '8295551002', 'pedro.gomez@hotmail.com', 2),
('Rosa Peña', '8495551003', 'rosa.pena@gmail.com', 3),
('Luis Santana', '8095551004', 'luis.santana@uce.edu.do', 4),
('Marta Reyes', '8295551005', 'marta.reyes@gmail.com', 1),
('Carlos Díaz', '8495551006', 'carlos.diaz@empresa.com', 2);
GO