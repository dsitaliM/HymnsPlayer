using System;
using HymnsPlayer.Views;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace HymnsPlayer
{
	public partial class App : PrismApplication
	{
        public App() : this(null) { }

	    public App(IPlatformInitializer initializer) : base(initializer)
	    {
	    }

	    protected override async void OnInitialized()
	    {
	        InitializeComponent();
            //await NavigationService.NavigateAsync("NavigationPage/MainNavigation?createTab=HymnsPage&createTab=HymnDetailPage&createTab=HymnPlayPage&createTab=AboutPage");
	        await NavigationService.NavigateAsync("NavigationPage/BottomNavigation");
        }

	    protected override void RegisterTypes(IContainerRegistry containerRegistry)
	    {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<BottomNavigation>();
            containerRegistry.RegisterForNavigation<HymnsPage>();
            containerRegistry.RegisterForNavigation<AboutPage>();
            containerRegistry.RegisterForNavigation<HymnDetailPage>();
            containerRegistry.RegisterForNavigation<HymnPlayPage>();
            containerRegistry.RegisterForNavigation<MainNavigation>();
        }
	}
}
