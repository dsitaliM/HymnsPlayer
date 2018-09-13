using System;
using HymnsPlayer.ViewModels;
using Xamarin.Forms;

namespace HymnsPlayer.Views
{
    public partial class HymnsPage : ContentPage
    {
        public HymnsPage()
        {
            InitializeComponent();
            //SearchBar.Effects.Add(Effect.Resolve("CustomEffects.SearchBarEffect"));
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var vm = BindingContext as HymnsPageViewModel;
            vm?.SearchCommand.Execute();
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
//            var aPage = new BottomNavigation();
//            Navigation.PushAsync(aPage.);
            //var page = new NavigationPage(new HymnDetailPage());
            //Application.Current.MainPage.Navigation.PushAsync(page, true);

            //Navigation.PushAsync(new HymnDetailPage());
            //HymnsListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            HymnsListView.SelectedItem = null;
            InitializeComponent();
        }
    }
}
