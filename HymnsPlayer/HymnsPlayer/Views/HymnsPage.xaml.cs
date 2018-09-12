using System;
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

        private void Button_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HymnDetailPage());
        }
    }
}
