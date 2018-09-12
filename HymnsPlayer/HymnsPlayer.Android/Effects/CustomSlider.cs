using Android.Graphics;
using Android.Widget;
using HymnsPlayer.Droid.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("CustomEffects")]
[assembly: ExportEffect(typeof(CustomSlider), "CustomSliderEffect")]
namespace HymnsPlayer.Droid.Effects
{
    public class CustomSlider : PlatformEffect
    {
        protected override void OnAttached()
        {
            var seekBar = (SeekBar) Control;
            seekBar.ProgressDrawable.SetColorFilter(new PorterDuffColorFilter(Xamarin.Forms.Color.Bisque.ToAndroid(), PorterDuff.Mode.SrcIn));
            seekBar.Thumb.SetColorFilter(new PorterDuffColorFilter(Xamarin.Forms.Color.SandyBrown.ToAndroid(), PorterDuff.Mode.SrcIn));
        }

        protected override void OnDetached()
        {
            throw new System.NotImplementedException();
        }
    }
}