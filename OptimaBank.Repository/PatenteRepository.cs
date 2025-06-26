using OptimaBank.Domain;
using OptimaBank.Repository.Interfaces;
using OptimaBank.SQLServerDataProvider.Composite.Interfaces;
using OptimaBank.SQLServerDataProvider.Idiomas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimaBank.Repository
{
    public class PatenteRepository : RepositoryManager<Patente>, IPatenteRepository
    {
        IPatenteDbContext _context;
        public PatenteRepository(IPatenteDbContext context) : base(context)
        {
            this._context = context;
        }

        public IList<Patente> ListarPatentes()
        {
            return _context.GetAllPatentes();
        }
    }
}
