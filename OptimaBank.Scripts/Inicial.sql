-- Crear la base de datos
CREATE DATABASE optimabank
GO

USE optimabank
GO

-- Tabla de Usuarios
CREATE TABLE Usuarios (
    UsuarioID INT IDENTITY(1,1) PRIMARY KEY,
    NombreUsuario VARCHAR(50) NOT NULL UNIQUE,
    Contrasena VARCHAR(100) NOT NULL,
    NombreCompleto VARCHAR(100) NOT NULL,
    Email VARCHAR(100),
    Activo BIT DEFAULT 1,
    FechaCreacion DATETIME DEFAULT GETDATE(),
    UltimoAcceso DATETIME
)
GO

-- Tabla de Roles
CREATE TABLE Roles (
    RolID INT IDENTITY(1,1) PRIMARY KEY,
    NombreRol VARCHAR(50) NOT NULL UNIQUE,
    Descripcion VARCHAR(200)
)
GO

-- Tabla de UsuarioRoles (Relación muchos a muchos)
CREATE TABLE UsuarioRoles (
    UsuarioID INT,
    RolID INT,
    PRIMARY KEY (UsuarioID, RolID),
    FOREIGN KEY (UsuarioID) REFERENCES Usuarios(UsuarioID),
    FOREIGN KEY (RolID) REFERENCES Roles(RolID)
)
GO

-- Tabla de Menús
CREATE TABLE Menus (
    MenuID INT IDENTITY(1,1) PRIMARY KEY,
    NombreMenu VARCHAR(50) NOT NULL,
    Descripcion VARCHAR(200),
    Orden INT,
    Icono VARCHAR(50),
    Activo BIT DEFAULT 1
)
GO

-- Tabla de SubMenús
CREATE TABLE SubMenus (
    SubMenuID INT IDENTITY(1,1) PRIMARY KEY,
    MenuID INT,
    NombreSubMenu VARCHAR(50) NOT NULL,
    Descripcion VARCHAR(200),
    Orden INT,
    Icono VARCHAR(50),
    Formulario VARCHAR(100),
    Activo BIT DEFAULT 1,
    FOREIGN KEY (MenuID) REFERENCES Menus(MenuID)
)
GO

-- Tabla de Permisos
CREATE TABLE Permisos (
    PermisoID INT IDENTITY(1,1) PRIMARY KEY,
    RolID INT,
    SubMenuID INT,
    PuedeVer BIT DEFAULT 0,
    PuedeEditar BIT DEFAULT 0,
    PuedeEliminar BIT DEFAULT 0,
    FOREIGN KEY (RolID) REFERENCES Roles(RolID),
    FOREIGN KEY (SubMenuID) REFERENCES SubMenus(SubMenuID)
)
GO

-- Insertar datos de ejemplo para Menús
INSERT INTO Menus (NombreMenu, Descripcion, Orden, Icono) VALUES
('Inicio', 'Menú principal', 1, 'home'),
('Administración', 'Configuración del sistema', 2, 'settings'),
('Reportes', 'Reportes del sistema', 3, 'report')
GO

-- Insertar datos de ejemplo para SubMenús
INSERT INTO SubMenus (MenuID, NombreSubMenu, Descripcion, Orden, Formulario) VALUES
(1, 'Dashboard', 'Panel de control', 1, 'frmDashboard'),
(1, 'Perfil', 'Perfil de usuario', 2, 'frmPerfil'),
(2, 'Usuarios', 'Gestión de usuarios', 1, 'frmUsuarios'),
(2, 'Roles', 'Gestión de roles', 2, 'frmRoles'),
(3, 'Reporte Diario', 'Reportes diarios', 1, 'frmReporteDiario'),
(3, 'Reporte Mensual', 'Reportes mensuales', 2, 'frmReporteMensual')
GO

-- Insertar roles básicos
INSERT INTO Roles (NombreRol, Descripcion) VALUES
('Administrador', 'Acceso total al sistema'),
('Usuario', 'Acceso básico al sistema')
GO

-- Crear procedimiento almacenado para login
CREATE PROCEDURE sp_ValidarLogin
    @NombreUsuario VARCHAR(50),
    @Contrasena VARCHAR(100)
AS
BEGIN
    SELECT 
        u.UsuarioID,
        u.NombreUsuario,
        u.NombreCompleto,
        u.Email,
        r.NombreRol
    FROM Usuarios u
    INNER JOIN UsuarioRoles ur ON u.UsuarioID = ur.UsuarioID
    INNER JOIN Roles r ON ur.RolID = r.RolID
    WHERE u.NombreUsuario = @NombreUsuario 
    AND u.Contrasena = @Contrasena
    AND u.Activo = 1
END
GO

-- Crear procedimiento almacenado para obtener menú
CREATE PROCEDURE sp_ObtenerMenu
    @UsuarioID INT
AS
BEGIN
    SELECT DISTINCT
        m.MenuID,
        m.NombreMenu,
        m.Icono,
        sm.SubMenuID,
        sm.NombreSubMenu,
        sm.Formulario,
        sm.Icono as SubMenuIcono
    FROM Menus m
    INNER JOIN SubMenus sm ON m.MenuID = sm.MenuID
    INNER JOIN Permisos p ON sm.SubMenuID = p.SubMenuID
    INNER JOIN UsuarioRoles ur ON p.RolID = ur.RolID
    WHERE ur.UsuarioID = @UsuarioID
    AND m.Activo = 1
    AND sm.Activo = 1
    AND p.PuedeVer = 1
    ORDER BY m.Orden, sm.Orden
END
GO

-- Insertar usuario administrador por defecto
INSERT INTO Usuarios (NombreUsuario, Contrasena, NombreCompleto, Email)
VALUES ('admin', 'admin123', 'Administrador', 'admin@optimabank.com')
GO

-- Asignar rol de administrador al usuario admin
INSERT INTO UsuarioRoles (UsuarioID, RolID)
VALUES (1, 1)
GO

-- Asignar todos los permisos al rol administrador
INSERT INTO Permisos (RolID, SubMenuID, PuedeVer, PuedeEditar, PuedeEliminar)
SELECT 1, SubMenuID, 1, 1, 1
FROM SubMenus
GO