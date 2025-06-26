
namespace OptimaBank.Services
{
    public enum LoginResult
    {
        InvalidUsername,
        InvalidPassword,
        ValidUser,
        UserOPassNull,
        UserDisabled,
        UserWithgoutPermissions
    }

    public enum TypeOperation
    {
        ALTA,
        BAJA,
        MODIFICACION,
        LISTAR,
        EXISTE,
        POR_PARAMETRO
    }

    public enum UserProfile
    {
        ADMINISTRADOR,
        OPERADOR,
        SOPORTE,
        GERENTE,
        SUPERVISOR,
        LIDER,
        EMPLEADO,
        CLIENTE,
        DEFAULT
    }

    public enum LABEL
    {
        LABEL_NOT_LOGGER,
        MENU_SESSION,
        MENU_INICIAR,
        MENU_CERRAR,
        LABEL_TITULO,
        LABEL_LOGIN_TITULO
    }

    public enum Tipo
    {
        Error,
        Informacion,
        Advertencia
    }

    public enum Categoria
    {
        Logica,
        Sistema,
        Validacion
    }
}