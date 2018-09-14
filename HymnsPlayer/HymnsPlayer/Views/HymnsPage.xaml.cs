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
        protected override void OnAppearing()
        {
            InitializeComponent();
        }

        public void Destroy()
        {
            HymnsListView.Behaviors.Clear();
        }
    }
}
