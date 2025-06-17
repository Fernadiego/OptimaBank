using OptimaBank.Domain;
using OptimaBank.ApplicationLogic.Menues;

namespace OptimaBank.UI.Controllers
{
    public class MenuController
    {
        private readonly IMenuApplicationService<Menu> _menuAppServer;

        private readonly ISubMenuApplicationService<Submenu> _submenuAppServer;

        public MenuController(IMenuApplicationService<Menu> menuAppServer, ISubMenuApplicationService<Submenu> submenuAppServer)
        {
            _menuAppServer = menuAppServer;
            _submenuAppServer = submenuAppServer;
        }

        public IList<Menu> TraerMenu()
        {
            return _menuAppServer.CargarMenues();
        }

        public IList<Submenu> TraerSubMenu()
        {
            return _submenuAppServer.CargarSubMenues();
        }
    }
}
