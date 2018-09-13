using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using TabbedPage = Xamarin.Forms.TabbedPage;

namespace HymnsPlayer.Views
{
    public partial class MainNavigation : TabbedPage
    {
        public MainNavigation()
        {
            InitializeComponent();
            //On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
        }
    }
}
