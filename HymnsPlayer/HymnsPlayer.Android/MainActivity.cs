using System;

using Android.App;
using Android.Content.PM;
using Android.Graphics;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Naxam.Controls.Platform.Droid;
using Prism;
using Prism.Ioc;

namespace HymnsPlayer.Droid
{
    [Activity(Label = "HymnsPlayer", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            CustomizeTab();

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App(new AndroidInitailizer()));
        }

        private static void CustomizeTab()
        {

            var stateList = new Android.Content.Res.ColorStateList(
                new int[][]
                {
                    new int[] {Android.Resource.Attribute.StateChecked},
                    new int[] {Android.Resource.Attribute.StateEnabled},
                }, 
                new int[]
                {
                    new Android.Graphics.Color(253, 217, 169), new Android.Graphics.Color(11, 4, 1)
                });

            BottomTabbedRenderer.FontSize = 10;
            BottomTabbedRenderer.IconSize = 20;
            BottomTabbedRenderer.ItemSpacing = 8;
            BottomTabbedRenderer.ItemPadding = new Xamarin.Forms.Thickness(8);
            BottomTabbedRenderer.BottomBarHeight = 50;
            BottomTabbedRenderer.BackgroundColor = new Android.Graphics.Color(58, 38, 30);
            BottomTabbedRenderer.ItemTextColor = stateList;
            BottomTabbedRenderer.ItemIconTintList = stateList;
        }

        public class AndroidInitailizer : IPlatformInitializer
        {
            public void RegisterTypes(IContainerRegistry containerRegistry)
            {
            }
        }
    }
}

