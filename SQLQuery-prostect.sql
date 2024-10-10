create database prospect;

use prospect;

CREATE TABLE usuarios (
    id INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    primer_apellido VARCHAR(100) NOT NULL,
    segundo_apellido VARCHAR(100) NOT NULL,
    calle VARCHAR(100) NOT NULL,
    numero VARCHAR(10) NOT NULL,
    colonia VARCHAR(100) NOT NULL,
    cp VARCHAR(10) NOT NULL,
    telefono VARCHAR(15) NOT NULL,
    rfc VARCHAR(13) NOT NULL,
    documento VARBINARY(MAX),
    estatus NVARCHAR(20) DEFAULT 'Enviado' CHECK (estatus IN ('Enviado', 'Autorizado', 'Rechazado'))
);

select * from usuarios;

INSERT INTO usuarios (
    nombre, 
    primer_apellido, 
    segundo_apellido, 
    calle, 
    numero, 
    colonia, 
    cp, 
    telefono, 
    rfc, 
    documento, 
    estatus
) VALUES (
    'Name', 
    'LastName', 
    'LastName', 
    'Av.Street', 
    '742', 
    'Mexico', 
    '12345', 
    '555-1233', 
    'LL1234DA', 
    (SELECT * FROM OPENROWSET(BULK 'C:\Users\alfon\Desktop\CODIGO\img\gatoo.jpg', SINGLE_BLOB) AS documento), 
    'Enviado'
);


CREATE TABLE Rechazos (
    RechazoId INT IDENTITY(1,1) PRIMARY KEY,  
    usuario_id INT NOT NULL,                   
    motivo NVARCHAR(255),                      
    fecha DATETIME DEFAULT GETDATE(),          
    FOREIGN KEY (usuario_id) REFERENCES usuarios(id) ON DELETE CASCADE
);
