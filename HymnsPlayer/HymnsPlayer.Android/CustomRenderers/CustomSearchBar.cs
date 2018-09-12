using Android.Content;
using Android.Support.V4.Content;
using HymnsPlayer.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(SearchBar), typeof(CustomSearchBar))]
namespace HymnsPlayer.Droid.CustomRenderers
{
    public class CustomSearchBar : SearchBarRenderer
    {
        public CustomSearchBar(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.Background = ContextCompat.GetDrawable(Context, Resource.Drawable.search_bar);
                //Control.Background = new Color
            }
        }
    }
}