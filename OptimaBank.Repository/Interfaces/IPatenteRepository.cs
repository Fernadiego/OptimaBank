using OptimaBank.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimaBank.Repository.Interfaces
{
   public interface IPatenteRepository
    {
        /// <summary>
        /// Obtiene todas las patentes del sistema.
        /// </summary>
        /// <returns>Lista de patentes.</returns>
        IList<Patente> ListarPatentes();
    }
}
