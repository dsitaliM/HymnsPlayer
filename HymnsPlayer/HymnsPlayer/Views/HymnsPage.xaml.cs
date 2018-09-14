using System;
using HymnsPlayer.ViewModels;
using Naxam.Controls.Forms;
using Prism;
using Prism.Navigation;
using Xamarin.Forms;

namespace HymnsPlayer.Views
{
    public partial class HymnsPage : ContentPage, IDestructible
    {
        public HymnsPage()
        {
            InitializeComponent();
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var vm = BindingContext as HymnsPageViewModel;
            vm?.SearchCommand.Execute();
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {

//            Navigation.PushAsync(new HymnDetailPage());
//
//            if (this.Parent is TabbedPage masterPage)
//                masterPage.CurrentPage = masterPage.Children[1];

            //Navigation.PushAsync(new HymnDetailPage());
            //HymnsListView.SelectedItem = null;
            //Navigation.PushAsync(new NavigationPage(new HymnDetailPage()));
        }

        protected override void OnAppearing()
        {
            HymnsListView.SelectedItem = null;
            InitializeComponent();
        }

        public void Destroy()
        {
            HymnsListView.Behaviors.Clear();
        }
    }
}
