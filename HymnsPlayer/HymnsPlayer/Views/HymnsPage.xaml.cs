using System;
using HymnsPlayer.ViewModels;
using Naxam.Controls.Forms;
using Prism;
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
            if (this.Parent is TabbedPage masterPage)
                masterPage.CurrentPage = masterPage.Children[1];

            //Navigation.PushAsync(new HymnDetailPage());
            //HymnsListView.SelectedItem = null;
            //Navigation.PushAsync(new NavigationPage(new HymnDetailPage()));
        }

        protected override void OnAppearing()
        {
            HymnsListView.SelectedItem = null;
            InitializeComponent();
        }
    }
}
