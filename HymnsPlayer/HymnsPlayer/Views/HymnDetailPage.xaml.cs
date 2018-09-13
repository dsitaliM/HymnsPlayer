using Xamarin.Forms;

namespace HymnsPlayer.Views
{
    public partial class HymnDetailPage : ContentPage
    {
        public HymnDetailPage()
        {
            InitializeComponent();
            //var page = new BottomNavigation();
            //page.CurrentPage = this;
        }
        protected override void OnAppearing()
        {

        }
        protected override void OnDisappearing()
        {
            //Navigation.RemovePage(this);
            //Navigation.PopAsync(true);
        }

       

    }
}
