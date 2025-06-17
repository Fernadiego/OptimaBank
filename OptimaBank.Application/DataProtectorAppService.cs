using OptimaBank.Domain;
using OptimaBank.Repository;
using Microsoft.AspNetCore.DataProtection;

namespace OptimaBank.ApplicationLogic
{
    public interface IDataProtectorApp
    {
        string Proteger(string texto);
        string Desproteger(string texto);
    }

    public class DataProtectorAppService : IDataProtectorApp
    {
        private readonly IDataProtector _protector;
        IRepositoryManager<Telefono> _repository;

        public DataProtectorAppService(IDataProtectionProvider protectorProvider, IRepositoryManager<Telefono> repository)
        {
            _protector = protectorProvider.CreateProtector("Clave.Super.Secreta");
            _repository = repository;
        }

        public string Proteger(string texto)
        {
            string encryptedEmail = _protector.Protect("profileDto.Email");
            //string encryptedPhone = _protector.Protect("1556467653");

            //_repository.Insert(new Telefono() { Numero = encryptedPhone, TipoId = 1 });

            return encryptedEmail;
        }

        public string Desproteger(string texto)
        {
            return _protector.Unprotect(texto);
        }
    }
}
