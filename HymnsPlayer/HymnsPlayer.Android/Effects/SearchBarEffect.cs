using Android.Graphics.Drawables;
using Android.Widget;
using HymnsPlayer.Droid.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportEffect(typeof(SearchBarEffect), "SearchBarEffect")]
namespace HymnsPlayer.Droid.Effects
{
    public class SearchBarEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            var searchBar = (SearchView) Control;

            if (searchBar != null)
            {
                searchBar.Background = new ColorDrawable(new Android.Graphics.Color(225, 245, 222, 179));
            }
                
        }


        protected override void OnDetached()
        {
            throw new System.NotImplementedException();
        }
    }
}