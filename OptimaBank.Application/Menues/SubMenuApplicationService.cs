using OptimaBank.Domain;
using OptimaBank.Repository;

namespace OptimaBank.ApplicationLogic.Menues
{
    public interface ISubMenuApplicationService<T>
    {
        IList<T> CargarSubMenues();
    }

    public class SubMenuApplicationService : ISubMenuApplicationService<Submenu>
    {
        IRepositoryManager<Submenu> _submenuRepositoryManager;

        public SubMenuApplicationService(IRepositoryManager<Submenu> submenuRepositoryManager)
        {
            _submenuRepositoryManager = submenuRepositoryManager;
        }
        public IList<Submenu> CargarSubMenues()
        {
            return _submenuRepositoryManager.GetAll();
        }
    }
}
