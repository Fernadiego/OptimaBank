using OptimaBank.Domain.Exceptions;

namespace OptimaBank.Domain.Common
{
    public class ExceptionHandler : IExceptionHandler
    {
        //private readonly ILogger<ExceptionHandler> _logger;

        public ExceptionHandler()
        {

        }

        public ExceptionResult HandleException(Exception ex)
        {
            //_logger.LogError(ex, "Error no manejado: {Message}", ex.Message);

            return ex switch
            {
                ValidationException validationEx =>
                    new ExceptionResult(false, validationEx.Message, validationEx.ErrorCode),

                BusinessRuleException businessEx =>
                    new ExceptionResult(false, businessEx.Message, businessEx.ErrorCode),

                //DataAccessException dataEx =>
                //    new ExceptionResult(false, "Error al acceder a los datos", dataEx.ErrorCode),

                //ConfigurationException configEx =>
                //    new ExceptionResult(false, configEx.Message, configEx.ErrorCode),

                DomainException domainEx =>
                    new ExceptionResult(false, domainEx.Message, domainEx.ErrorCode),

                _ => new ExceptionResult(false, "Ha ocurrido un error inesperado", "SYS001")
            };
        }
    }

    public interface IExceptionHandler
    {
        ExceptionResult HandleException(Exception ex);
    }

    public class ExceptionResult
    {
        public bool IsSuccess { get; }
        public string Message { get; }
        public string ErrorCode { get; }
        public bool IsFailure => !IsSuccess;

        public ExceptionResult(bool isSuccess, string message, string errorCode)
        {
            IsSuccess = isSuccess;
            Message = message;
            ErrorCode = errorCode;
        }
    }
}