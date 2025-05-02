
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
}
