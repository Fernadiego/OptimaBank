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

IF EXISTS (SELECT * FROM sys.tables WHERE name = 'TRADUCCION')
    DROP TABLE TRADUCCION
GO

IF EXISTS (SELECT * FROM sys.tables WHERE name = 'IDIOMA')
    DROP TABLE IDIOMA
GO

IF EXISTS (SELECT * FROM sys.tables WHERE name = 'ETIQUETA')
    DROP TABLE ETIQUETA
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
    DROP TABLE USUARIO
GO

IF EXISTS (SELECT * FROM sys.tables WHERE name = 'BITACORA')
    DROP TABLE BITACORA
GO

CREATE TABLE BITACORA (
    Id INT IDENTITY(1,1) PRIMARY KEY,
	NombreUsuario VARCHAR(10) NOT NULL,
	FechaSuceso DATETIME DEFAULT GETDATE(),
	Modulo VARCHAR(500) NOT NULL,
	Mensaje VARCHAR(200) NOT NULL,
	Tipo TINYINT NOT NULL CHECK (Tipo BETWEEN 0 AND 2),
	Categoria TINYINT NOT NULL CHECK (Categoria BETWEEN 0 AND 2)
)
GO

-- Crear tablas
CREATE TABLE USUARIO (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    NombreUsuario VARCHAR(10) NOT NULL UNIQUE,
    Contrasena VARCHAR(80) NOT NULL,
    Email VARCHAR(160),
    Activo BIT DEFAULT 1,
    FechaCreacion DATETIME DEFAULT GETDATE(),
    FechaModificacion DATETIME,
    CantidadIntentos INT DEFAULT 0,
    UltimoAcceso DATETIME,
    IdiomaId INT
)
GO

--agrego foranea idioma

ALTER TABLE USUARIO
ADD CONSTRAINT FK_Usuario_Idioma
FOREIGN KEY (IdiomaId) REFERENCES IDIOMA(Id);
GO


CREATE TABLE ETIQUETA (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL UNIQUE,
    Descripcion VARCHAR(200)
)
GO

CREATE TABLE IDIOMA (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL UNIQUE,
    Descripcion VARCHAR(200),
	Is_Default BIT,
	Imagen VARCHAR(15)
)
GO

CREATE TABLE TRADUCCION (
	IdiomaId INT NOT NULL,
    EtiquetaId INT NOT NULL,
    Texto VARCHAR(200) NOT NULL,
	CONSTRAINT FK_TRADUCCION_ETIQUETA FOREIGN KEY (EtiquetaId) REFERENCES ETIQUETA(Id),
	CONSTRAINT FK_TRADUCCION_IDIOMA FOREIGN KEY (IdiomaId) REFERENCES IDIOMA(Id)
)
GO

CREATE TABLE COMPOSITE_PERMISO(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	Nombre VARCHAR(200) NULL,
	Permiso VARCHAR(50) NULL
)
GO

CREATE TABLE COMPOSITE_PERMISO_PERMISO(
	PermisoPadreId INT NULL,
	PermisoHijoId INT NULL
)
GO

CREATE TABLE COMPOSITE_USUARIOS_PERMISOS(
	UsuarioId INT NOT NULL,
	PermisoId INT NOT NULL,
	CONSTRAINT FK_USUARIOS_ID FOREIGN KEY (UsuarioId) REFERENCES USUARIO(Id),
	CONSTRAINT FK_PERMISOS_ID FOREIGN KEY (PermisoId) REFERENCES COMPOSITE_PERMISO(Id)
)
GO




CREATE TABLE OB_PERMISO (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    RolID INT,
    SubMenuID INT,
    PuedeVer BIT DEFAULT 0,
    PuedeEditar BIT DEFAULT 0,
    PuedeEliminar BIT DEFAULT 0,
    FOREIGN KEY (RolID) REFERENCES ROL(Id),
    FOREIGN KEY (SubMenuID) REFERENCES OB_SUBMENU(Id)
)
GO

CREATE TABLE ROL (
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
    FOREIGN KEY (RolId) REFERENCES ROL(Id)
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

INSERT INTO ROL (Nombre, Descripcion) VALUES
('ADMINISTRADOR', 'Acceso total al sistema'),
('USUARIO', 'Acceso básico al sistema')
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
        u.Email,
        r.Nombre as RolNombre
    FROM USUARIO u
    INNER JOIN OB_USUARIO_ROL ur ON u.Id = ur.UsuarioId
    INNER JOIN ROL r ON ur.RolId = r.Id
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
INSERT INTO USUARIO (NombreUsuario, Contrasena, Email)
VALUES ('admin', '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918', 'admin@optimabank.com')
GO

-- Asignar rol de administrador al usuario admin
INSERT INTO OB_USUARIO_ROL (UsuarioId, RolId)
VALUES (1, 1)
GO

-- Asignar todos los permisos al rol administrador
INSERT INTO OB_PERMISO (RolID, SubMenuID, PuedeVer, PuedeEditar, PuedeEliminar)
SELECT 1, Id, 1, 1, 1
FROM SUBMENU
GO



INSERT INTO IDIOMA ([Nombre] ,[Descripcion], [Is_Default]) VALUES ('es-AR', 'Español Argentina', 1, 'ARG')
INSERT INTO IDIOMA ([Nombre] ,[Descripcion], [Is_Default]) VALUES ('en-UK', 'Inglés United Kingdom', 'UK')
INSERT INTO IDIOMA ([Nombre] ,[Descripcion], [Is_Default]) VALUES ('por-BRA', 'Portugués Brasil', 'BRA')
GO

INSERT INTO ETIQUETA ([Nombre] ,[Descripcion]) VALUES ('LABEL_NOT_LOGGER', 'Etiqueta LABEL de usuario no logueado')
INSERT INTO ETIQUETA ([Nombre] ,[Descripcion]) VALUES ('LABEL_LOGIN_OK', 'Etiqueta LABEL de login ok')
INSERT INTO ETIQUETA ([Nombre] ,[Descripcion]) VALUES ('LABEL_LOGIN_NOK', 'Etiqueta LABEL de login no ok')
INSERT INTO ETIQUETA ([Nombre] ,[Descripcion]) VALUES ('MENU_SESSION', 'Etiqueta MENU de sesión')
INSERT INTO ETIQUETA ([Nombre] ,[Descripcion]) VALUES ('MENU_INICIAR', 'Etiqueta LABEL de iniciar sesión')
INSERT INTO ETIQUETA ([Nombre] ,[Descripcion]) VALUES ('MENU_CERRAR', 'Etiqueta LABEL de cerrar sesión')
INSERT INTO ETIQUETA ([Nombre] ,[Descripcion]) VALUES ('LABEL_TITULO', 'Etiqueta LABEL del titulo del programa')
INSERT INTO ETIQUETA ([Nombre] ,[Descripcion]) VALUES ('LABEL_USER', 'Etiqueta LABEL de user login')
INSERT INTO ETIQUETA ([Nombre] ,[Descripcion]) VALUES ('LABEL_PASS', 'Etiqueta LABEL de password login')
INSERT INTO ETIQUETA ([Nombre] ,[Descripcion]) VALUES ('LABEL_LOGIN_TITULO', 'Etiqueta LABEL del título de login')
INSERT INTO ETIQUETA ([Nombre] ,[Descripcion]) VALUES ('LABEL_BTN_ACEPTAR', 'Etiqueta boton aceptar')
INSERT INTO ETIQUETA ([Nombre] ,[Descripcion]) VALUES ('LABEL_BTN_CANCELAR', 'Etiqueta boton cancelar')
INSERT INTO ETIQUETA ([Nombre] ,[Descripcion]) VALUES ('LABEL_BTN_REGISTRAR', 'Etiqueta boton registrar')
INSERT INTO ETIQUETA ([Nombre] ,[Descripcion]) VALUES ('LABEL_BTN_OLVIDE', 'Etiqueta boton olvide contraseña')
INSERT INTO ETIQUETA ([Nombre] ,[Descripcion]) VALUES ('MSG_LOGIN_LABEL_BIENVENIDO', 'Etiqueta Bienvenido')
INSERT INTO ETIQUETA ([Nombre] ,[Descripcion]) VALUES ('MSG_LOGIN_BIENVENIDO', 'Mensaje Bienvenido')
INSERT INTO ETIQUETA ([Nombre] ,[Descripcion]) VALUES ('MSG_LOGIN_OK', 'Mensaje Login Ok')
INSERT INTO ETIQUETA ([Nombre] ,[Descripcion]) VALUES ('MSG_LOGIN_NOK', 'Mensaje Login Nok')
GO



INSERT INTO TRADUCCION ([IdiomaId] ,[EtiquetaId] ,[Texto]) VALUES (1, 1, 'No hay ningun usuario logueado.')
INSERT INTO TRADUCCION ([IdiomaId] ,[EtiquetaId] ,[Texto]) VALUES (2, 1, 'There is no logged in user.')
INSERT INTO TRADUCCION ([IdiomaId] ,[EtiquetaId] ,[Texto]) VALUES (3, 1, 'Não há nenhum usuário logado.')
GO
INSERT INTO TRADUCCION ([IdiomaId] ,[EtiquetaId] ,[Texto]) VALUES (1, 2, 'Inicio Sesion Exitoso!')
INSERT INTO TRADUCCION ([IdiomaId] ,[EtiquetaId] ,[Texto]) VALUES (2, 2, 'Successful Session Start!')
INSERT INTO TRADUCCION ([IdiomaId] ,[EtiquetaId] ,[Texto]) VALUES (3, 2, 'Início de Sessão Bem-sucedido!')
GO
INSERT INTO TRADUCCION ([IdiomaId] ,[EtiquetaId] ,[Texto]) VALUES (1, 3, 'Usuario o contraseña inválidos!')
INSERT INTO TRADUCCION ([IdiomaId] ,[EtiquetaId] ,[Texto]) VALUES (2, 3, 'Invalid username or password!')
INSERT INTO TRADUCCION ([IdiomaId] ,[EtiquetaId] ,[Texto]) VALUES (3, 3, 'Usuário ou senha inválidos!')
GO
INSERT INTO TRADUCCION ([IdiomaId] ,[EtiquetaId] ,[Texto]) VALUES (1, 4, 'Sesión')
INSERT INTO TRADUCCION ([IdiomaId] ,[EtiquetaId] ,[Texto]) VALUES (2, 4, 'Session')
INSERT INTO TRADUCCION ([IdiomaId] ,[EtiquetaId] ,[Texto]) VALUES (3, 4, 'Sessão')
GO
INSERT INTO TRADUCCION ([IdiomaId] ,[EtiquetaId] ,[Texto]) VALUES (1, 5, 'Iniciar')
INSERT INTO TRADUCCION ([IdiomaId] ,[EtiquetaId] ,[Texto]) VALUES (2, 5, 'Init')
INSERT INTO TRADUCCION ([IdiomaId] ,[EtiquetaId] ,[Texto]) VALUES (3, 5, 'Iniciar')
GO
INSERT INTO TRADUCCION ([IdiomaId] ,[EtiquetaId] ,[Texto]) VALUES (1, 6, 'Cerrar')
INSERT INTO TRADUCCION ([IdiomaId] ,[EtiquetaId] ,[Texto]) VALUES (2, 6, 'Close')
INSERT INTO TRADUCCION ([IdiomaId] ,[EtiquetaId] ,[Texto]) VALUES (3, 6, 'Fechar')
GO
INSERT INTO TRADUCCION ([IdiomaId] ,[EtiquetaId] ,[Texto]) VALUES (1, 7, 'Optima Bank - Software de Gestion Bancaria')
INSERT INTO TRADUCCION ([IdiomaId] ,[EtiquetaId] ,[Texto]) VALUES (2, 7, 'Optima Bank - Banking Management Software')
INSERT INTO TRADUCCION ([IdiomaId] ,[EtiquetaId] ,[Texto]) VALUES (3, 7, 'Optima Bank - Software de Gestão Bancária')
GO
INSERT INTO TRADUCCION ([IdiomaId] ,[EtiquetaId] ,[Texto]) VALUES (1, 8, 'Usuario:')
INSERT INTO TRADUCCION ([IdiomaId] ,[EtiquetaId] ,[Texto]) VALUES (2, 8, 'User:')
INSERT INTO TRADUCCION ([IdiomaId] ,[EtiquetaId] ,[Texto]) VALUES (3, 8, 'Usuário:')
GO
INSERT INTO TRADUCCION ([IdiomaId] ,[EtiquetaId] ,[Texto]) VALUES (1, 9, 'Clave:')
INSERT INTO TRADUCCION ([IdiomaId] ,[EtiquetaId] ,[Texto]) VALUES (2, 9, 'Password:')
INSERT INTO TRADUCCION ([IdiomaId] ,[EtiquetaId] ,[Texto]) VALUES (3, 9, 'Senha:')
GO
INSERT INTO TRADUCCION ([IdiomaId] ,[EtiquetaId] ,[Texto]) VALUES (1, 10, 'Optima Bank - Login')
INSERT INTO TRADUCCION ([IdiomaId] ,[EtiquetaId] ,[Texto]) VALUES (2, 10, 'Optima Bank - Login')
INSERT INTO TRADUCCION ([IdiomaId] ,[EtiquetaId] ,[Texto]) VALUES (3, 10, 'Optima Bank - Login')
GO
INSERT INTO TRADUCCION ([IdiomaId] ,[EtiquetaId] ,[Texto]) VALUES (1, 11, 'Aceptar')
INSERT INTO TRADUCCION ([IdiomaId] ,[EtiquetaId] ,[Texto]) VALUES (2, 11, 'Acept')
INSERT INTO TRADUCCION ([IdiomaId] ,[EtiquetaId] ,[Texto]) VALUES (3, 11, 'Aceitar')
GO
INSERT INTO TRADUCCION ([IdiomaId] ,[EtiquetaId] ,[Texto]) VALUES (1, 12, 'Cancelar')
INSERT INTO TRADUCCION ([IdiomaId] ,[EtiquetaId] ,[Texto]) VALUES (2, 12, 'Cancel')
INSERT INTO TRADUCCION ([IdiomaId] ,[EtiquetaId] ,[Texto]) VALUES (3, 12, 'Cancelar')
GO
INSERT INTO TRADUCCION ([IdiomaId] ,[EtiquetaId] ,[Texto]) VALUES (1, 13, 'Registrarse')
INSERT INTO TRADUCCION ([IdiomaId] ,[EtiquetaId] ,[Texto]) VALUES (2, 13, 'To Register')
INSERT INTO TRADUCCION ([IdiomaId] ,[EtiquetaId] ,[Texto]) VALUES (3, 13, 'Registrar-se')
GO
INSERT INTO TRADUCCION ([IdiomaId] ,[EtiquetaId] ,[Texto]) VALUES (1, 14, 'Olvidé Password')
INSERT INTO TRADUCCION ([IdiomaId] ,[EtiquetaId] ,[Texto]) VALUES (2, 14, 'Forgot Password')
INSERT INTO TRADUCCION ([IdiomaId] ,[EtiquetaId] ,[Texto]) VALUES (3, 14, 'Esqueci a Senha')
GO
INSERT INTO TRADUCCION ([IdiomaId] ,[EtiquetaId] ,[Texto]) VALUES (1, 15, 'Bienvenido')
INSERT INTO TRADUCCION ([IdiomaId] ,[EtiquetaId] ,[Texto]) VALUES (2, 15, 'Welcome')
INSERT INTO TRADUCCION ([IdiomaId] ,[EtiquetaId] ,[Texto]) VALUES (3, 15, 'Bem-vindo')
GO
INSERT INTO TRADUCCION ([IdiomaId] ,[EtiquetaId] ,[Texto]) VALUES (1, 16, '{0} su ultimo ingreso fue el {1}')
INSERT INTO TRADUCCION ([IdiomaId] ,[EtiquetaId] ,[Texto]) VALUES (2, 16, '{0} his last admission was on {1}')
INSERT INTO TRADUCCION ([IdiomaId] ,[EtiquetaId] ,[Texto]) VALUES (3, 16, '{0} sua última entrada foi o {1}')
GO
INSERT INTO TRADUCCION ([IdiomaId] ,[EtiquetaId] ,[Texto]) VALUES (1, 17, 'Inicio Sesión Exitoso!')
INSERT INTO TRADUCCION ([IdiomaId] ,[EtiquetaId] ,[Texto]) VALUES (2, 17, 'Inicio de Sessão bem-sucedido!')
INSERT INTO TRADUCCION ([IdiomaId] ,[EtiquetaId] ,[Texto]) VALUES (3, 17, 'Successful Session Start!')
GO
INSERT INTO TRADUCCION ([IdiomaId] ,[EtiquetaId] ,[Texto]) VALUES (1, 18, 'Usuario o contraseña inválidos!')
INSERT INTO TRADUCCION ([IdiomaId] ,[EtiquetaId] ,[Texto]) VALUES (2, 18, 'Usuario ou senha inválidos!')
INSERT INTO TRADUCCION ([IdiomaId] ,[EtiquetaId] ,[Texto]) VALUES (3, 18, 'Invalid username or password!')
GO