using Prism.Regions;
using System.Windows;
namespace Shell.Desktop.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(IRegionManager regionManager)
        {
            InitializeComponent();
            // show splash screen first
            //new SplashWindow().ShowDialog();

            // register top menu
            regionManager.RegisterViewWithRegion("TopMenuRegion", typeof(Header.TopMainMenu));

            // register toolbar
            //regionManager.RegisterViewWithRegion("ToolbarRegion", typeof(Header.Toolbar));

            // register footer and statusbar
            //regionManager.RegisterViewWithRegion("FooterRegion", typeof(Footer.Footer));
        }
    }
}
