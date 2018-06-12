using Prism.Modularity;
using Prism.Regions;
using Microsoft.Practices.Unity;
using Modules.Users.Views;

namespace Users
{
    public class UsersModule : IModule
    {
        private IRegionManager _regionManager;
        private IUnityContainer _container;

        public UsersModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion("ContentRegion",typeof(UsersPage));
        }
    }
}