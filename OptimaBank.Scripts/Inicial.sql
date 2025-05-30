CREATE DATABASE OptimaBank
GO

USE OptimaBank
GO

CREATE TABLE Usuario (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Usuario VARCHAR(10) NOT NULL UNIQUE,
    Contrasena VARCHAR(10) NOT NULL,
    Nombre VARCHAR(50) NOT NULL,
    Email VARCHAR(20),
    Activo BIT DEFAULT 1,
    FechaCreacion DATETIME DEFAULT GETDATE(),
	FechaModificacion DATETIME,
	CantidadIntentos INT,
    UltimoAcceso DATETIME,
	IdiomaId INT
)
GO

-- Tabla de Roles
CREATE TABLE Rol (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL UNIQUE,
    Descripcion VARCHAR(200)
)
GO

-- Tabla de UsuarioRoles
CREATE TABLE UsuarioRol (
    UsuarioId INT,
    RolId INT,
    PRIMARY KEY (UsuarioId, RolId),
    FOREIGN KEY (UsuarioId) REFERENCES Usuario(Id),
    FOREIGN KEY (RolId) REFERENCES Rol(Id)
)
GO

-- Tabla de Menús
CREATE TABLE Menu (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    NombreMenu VARCHAR(50) NOT NULL,
    Descripcion VARCHAR(100),
    Orden INT,
    Icono VARCHAR(50),
    Activo BIT DEFAULT 1
)
GO

-- Tabla de SubMenús
CREATE TABLE SubMenu (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    MenuId INT,
    NombreSubMenu VARCHAR(50) NOT NULL,
    Descripcion VARCHAR(100),
    Orden INT,
    Icono VARCHAR(50),
    Formulario VARCHAR(100),
    Activo BIT DEFAULT 1,
    FOREIGN KEY (MenuID) REFERENCES Menu(Id)
)
GO

-- Tabla de Permisos
CREATE TABLE Permiso (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    RolID INT,
    SubMenuID INT,
    PuedeVer BIT DEFAULT 0,
    PuedeEditar BIT DEFAULT 0,
    PuedeEliminar BIT DEFAULT 0,
    FOREIGN KEY (RolID) REFERENCES Rol(Id),
    FOREIGN KEY (SubMenuID) REFERENCES SubMenu(Id)
)
GO

-- Insertar datos de ejemplo para Menús
INSERT INTO Menu (NombreMenu, Descripcion, Orden, Icono) VALUES
('Inicio', 'Menú principal', 1, 'home'),
('Administración', 'Configuración del sistema', 2, 'settings'),
('Reportes', 'Reportes del sistema', 3, 'report')
GO

-- Insertar datos de ejemplo para SubMenús
INSERT INTO SubMenu (MenuID, NombreSubMenu, Descripcion, Orden, Formulario) VALUES
(1, 'Dashboard', 'Panel de control', 1, 'frmDashboard'),
(1, 'Perfil', 'Perfil de usuario', 2, 'frmPerfil'),
(2, 'Usuarios', 'Gestión de usuarios', 1, 'frmUsuarios'),
(2, 'Roles', 'Gestión de roles', 2, 'frmRoles'),
(3, 'Reporte Diario', 'Reportes diarios', 1, 'frmReporteDiario'),
(3, 'Reporte Mensual', 'Reportes mensuales', 2, 'frmReporteMensual')
GO

-- Insertar roles básicos
INSERT INTO Rol (Nombre, Descripcion) VALUES
('Administrador', 'Acceso total al sistema'),
('Usuario', 'Acceso básico al sistema')
GO

-- Crear procedimiento almacenado para login
CREATE PROCEDURE sp_ValidarLogin
    @Usuario VARCHAR(50),
    @Contrasena VARCHAR(100)
AS
BEGIN
    SELECT 
        u.Id,
        u.Usuario,
        u.Nombre,
        u.Email,
        r.Nombre
    FROM Usuario u
    INNER JOIN UsuarioRol ur ON u.Id = ur.UsuarioId
    INNER JOIN Rol r ON ur.RolId = r.Id
    WHERE u.Usuario = @Usuario 
    AND u.Contrasena = @Contrasena
    AND u.Activo = 1
END
GO

CREATE PROCEDURE SP_TELEFONO_INSERT
AS 
BEGIN
	PRINT('DUMMY')
END
GO

-- Crear procedimiento almacenado para obtener menú
CREATE PROCEDURE sp_ObtenerMenu
    @UsuarioID INT
AS
BEGIN
    SELECT DISTINCT
        m.Id,
        m.NombreMenu,
        m.Icono,
        sm.Id,
        sm.NombreSubMenu,
        sm.Formulario,
        sm.Icono as SubMenuIcono
    FROM Menu m
    INNER JOIN SubMenu sm ON m.Id = sm.MenuId
    INNER JOIN Permiso p ON sm.Id = p.SubMenuID
    INNER JOIN UsuarioRol ur ON p.RolID = ur.RolID
    WHERE ur.UsuarioID = @UsuarioID
    AND m.Activo = 1
    AND sm.Activo = 1
    AND p.PuedeVer = 1
    --ORDER BY m.Orden, sm.Orden
END
GO

-- Insertar usuario administrador por defecto
INSERT INTO Usuario (Usuario, Contrasena, Nombre, Email)
VALUES ('admin', 'admin', 'Administrador', 'admin@optimabank.com')
GO

-- Asignar rol de administrador al usuario admin
INSERT INTO UsuarioRol (UsuarioID, RolID)
VALUES (1, 1)
GO

-- Asignar todos los permisos al rol administrador
INSERT INTO Permiso (RolID, SubMenuID, PuedeVer, PuedeEditar, PuedeEliminar)
SELECT 1, Id, 1, 1, 1
FROM SubMenu
GO