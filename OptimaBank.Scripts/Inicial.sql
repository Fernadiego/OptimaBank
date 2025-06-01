-- Verificar y eliminar la base de datos si existe
IF EXISTS (SELECT name FROM sys.databases WHERE name = 'OptimaBank')
BEGIN
    -- Cerrar conexiones existentes
    ALTER DATABASE OptimaBank SET MULTI_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE OptimaBank;
END
GO

CREATE DATABASE OptimaBank
GO

USE OptimaBank
GO

-- Eliminar procedimientos almacenados si existen
IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'SP_VALIDAR_LOGIN')
    DROP PROCEDURE SP_VALIDAR_LOGIN
GO

IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'SP_USUARIO_BY_CRED')
    DROP PROCEDURE SP_USUARIO_BY_CRED
GO

IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'SP_TELEFONO_INSERT')
    DROP PROCEDURE SP_TELEFONO_INSERT
GO

IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'SP_OBTENER_MENU')
    DROP PROCEDURE SP_OBTENER_MENU
GO

-- Eliminar tablas si existen (en orden correcto por las dependencias)
IF EXISTS (SELECT * FROM sys.tables WHERE name = 'OB_PERMISO')
    DROP TABLE OB_PERMISO
GO

IF EXISTS (SELECT * FROM sys.tables WHERE name = 'OB_USUARIO_ROL')
    DROP TABLE OB_USUARIO_ROL
GO

IF EXISTS (SELECT * FROM sys.tables WHERE name = 'SUBMENU')
    DROP TABLE SUBMENU
GO

IF EXISTS (SELECT * FROM sys.tables WHERE name = 'MENU')
    DROP TABLE MENU
GO

IF EXISTS (SELECT * FROM sys.tables WHERE name = 'OB_ROL')
    DROP TABLE OB_ROL
GO

IF EXISTS (SELECT * FROM sys.tables WHERE name = 'USUARIO')
    DROP TABLE OB_USUARIO
GO

-- Crear tablas
CREATE TABLE USUARIO (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    NombreUsuario VARCHAR(10) NOT NULL UNIQUE,
    Contrasena VARCHAR(80) NOT NULL,
    Nombre VARCHAR(50) NOT NULL,
    Email VARCHAR(20),
    Activo BIT DEFAULT 1,
    FechaCreacion DATETIME DEFAULT GETDATE(),
    FechaModificacion DATETIME,
    CantidadIntentos INT DEFAULT 0,
    UltimoAcceso DATETIME,
    IdiomaId INT
)
GO

CREATE TABLE OB_ROL (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL UNIQUE,
    Descripcion VARCHAR(200)
)
GO

CREATE TABLE OB_USUARIO_ROL (
    UsuarioId INT,
    RolId INT,
    PRIMARY KEY (UsuarioId, RolId),
    FOREIGN KEY (UsuarioId) REFERENCES USUARIO(Id),
    FOREIGN KEY (RolId) REFERENCES OB_ROL(Id)
)
GO

CREATE TABLE MENU (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    NombreMenu VARCHAR(50) NOT NULL,
    Descripcion VARCHAR(100),
    Orden INT,
    Icono VARCHAR(50),
    Activo BIT DEFAULT 1
)
GO

CREATE TABLE SUBMENU (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    MenuId INT,
    NombreSubMenu VARCHAR(50) NOT NULL,
    Descripcion VARCHAR(100),
    Orden INT,
    Icono VARCHAR(50),
    Formulario VARCHAR(100),
    Activo BIT DEFAULT 1,
    FOREIGN KEY (MenuId) REFERENCES OB_MENU(Id)
)
GO

CREATE TABLE OB_PERMISO (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    RolID INT,
    SubMenuID INT,
    PuedeVer BIT DEFAULT 0,
    PuedeEditar BIT DEFAULT 0,
    PuedeEliminar BIT DEFAULT 0,
    FOREIGN KEY (RolID) REFERENCES OB_ROL(Id),
    FOREIGN KEY (SubMenuID) REFERENCES OB_SUBMENU(Id)
)
GO

-- Insertar datos de ejemplo
INSERT INTO MENU (NombreMenu, Descripcion, Orden, Icono) VALUES
('Inicio', 'Menú principal', 1, 'home'),
('Administración', 'Configuración del sistema', 2, 'settings'),
('Reportes', 'Reportes del sistema', 3, 'report')
GO

INSERT INTO SUBMENU (MenuId, NombreSubMenu, Descripcion, Orden, Formulario) VALUES
(1, 'Dashboard', 'Panel de control', 1, 'frmDashboard'),
(1, 'Perfil', 'Perfil de usuario', 2, 'frmPerfil'),
(2, 'Usuarios', 'Gestión de usuarios', 1, 'frmUsuarios'),
(2, 'Roles', 'Gestión de roles', 2, 'frmRoles'),
(3, 'Reporte Diario', 'Reportes diarios', 1, 'frmReporteDiario'),
(3, 'Reporte Mensual', 'Reportes mensuales', 2, 'frmReporteMensual')
GO

INSERT INTO OB_ROL (Nombre, Descripcion) VALUES
('Administrador', 'Acceso total al sistema'),
('Usuario', 'Acceso básico al sistema')
GO

-- Crear procedimientos almacenados
CREATE PROCEDURE SP_VALIDAR_LOGIN
    @Usuario VARCHAR(50),
    @Contrasena VARCHAR(100)
AS
BEGIN
    SELECT 
        u.Id,
        u.NombreUsuario,
        u.Nombre,
        u.Email,
        r.Nombre as RolNombre
    FROM USUARIO u
    INNER JOIN OB_USUARIO_ROL ur ON u.Id = ur.UsuarioId
    INNER JOIN OB_ROL r ON ur.RolId = r.Id
    WHERE u.NombreUsuario = @Usuario 
    AND u.Contrasena = @Contrasena
    AND u.Activo = 1
END
GO

CREATE PROCEDURE SP_USUARIO_BY_CRED
    @USUARIO VARCHAR(20)
AS
BEGIN
    SELECT *
	FROM USUARIO 
    WHERE NombreUsuario = @USUARIO
    AND Activo = 1
END
GO

CREATE PROCEDURE SP_TELEFONO_INSERT
AS 
BEGIN
    PRINT('DUMMY')
END
GO

CREATE PROCEDURE SP_OBTENER_MENU
    @UsuarioID INT
AS
BEGIN
    SELECT --DISTINCT
        m.Id,
        m.NombreMenu,
        m.Icono,
        sm.Id as SubMenuId,
        sm.NombreSubMenu,
        sm.Formulario,
        sm.Icono as SubMenuIcono
    FROM OB_MENU m
    INNER JOIN SUBMENU sm ON m.Id = sm.MenuId
    INNER JOIN OB_PERMISO p ON sm.Id = p.SubMenuID
    INNER JOIN USUARIO_ROL ur ON p.RolID = ur.RolID
    WHERE ur.UsuarioID = @UsuarioID
    AND m.Activo = 1
    AND sm.Activo = 1
    AND p.PuedeVer = 1
    ORDER BY m.Orden, sm.Orden
END
GO

-- Insertar usuario administrador por defecto
INSERT INTO USUARIO (NombreUsuario, Contrasena, Nombre, Email)
VALUES ('admin', '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918', 'Administrador', 'admin@optimabank.com')
GO

-- Asignar rol de administrador al usuario admin
INSERT INTO OB_USUARIO_ROL (UsuarioId, RolId)
VALUES (1, 1)
GO

-- Asignar todos los permisos al rol administrador
INSERT INTO OB_PERMISO (RolID, SubMenuID, PuedeVer, PuedeEditar, PuedeEliminar)
SELECT 1, Id, 1, 1, 1
FROM OB_SUBMENU
GO