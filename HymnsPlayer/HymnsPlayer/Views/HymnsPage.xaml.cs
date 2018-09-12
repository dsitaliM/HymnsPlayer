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
    }
}
