using Xamarin.Forms;

namespace HymnsPlayer.Views
{
    public partial class HymnPlayPage : ContentPage
    {
        public HymnPlayPage()
        {
            InitializeComponent();
            Slider.Effects.Add(Effect.Resolve("CustomEffects.CustomSliderEffect"));
        }
    }
}
