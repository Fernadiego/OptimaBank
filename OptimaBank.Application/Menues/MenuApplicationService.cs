using OptimaBank.Domain;
using OptimaBank.Repository.Interfaces;
using OptimaBank.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimaBank.ApplicationLogic.Menues
{
    public interface IMenuApplicationService<T>
    {
        IList<T> CargarMenues();
    }

    public class MenuApplicationService : IMenuApplicationService<Menu>
    {
        IRepositoryManager<Menu> _menuRepositoryManager;

        public MenuApplicationService(IRepositoryManager<Menu> menuRepositoryManager)
        {
            _menuRepositoryManager = menuRepositoryManager;
        }
        public IList<Menu> CargarMenues()
        {
            return _menuRepositoryManager.GetAll();
        }
    }
}
