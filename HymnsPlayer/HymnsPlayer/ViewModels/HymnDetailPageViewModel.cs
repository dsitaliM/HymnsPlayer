using Prism.Commands;
using Prism.Mvvm;
using System.Linq;
using HymnsPlayer.Models;
using HymnsPlayer.Services;
using Prism.Navigation;

namespace HymnsPlayer.ViewModels
{
	public class HymnDetailPageViewModel : BindableBase, INavigatedAware
	{

	    private readonly INavigationService _navigationService;

	    private Hymn _hymn;
	    public Hymn Hymn
	    {
	        get => _hymn;
	        set => SetProperty(ref _hymn, value);
	    }

//	    private DelegateCommand<Hymn> _playCommand;
//	    public DelegateCommand<Hymn> PlayCommand
//            => _playCommand ?? (_playCommand = new DelegateCommand<Hymn>(OnPlayClicked));

	    private DelegateCommand _playCommand;
	    public DelegateCommand PlayCommand
	        => _playCommand ?? (_playCommand = new DelegateCommand(OnPlayClicked));

//        private async void OnPlayClicked(Hymn hymn)
//	    {
//	        //var navParams = new NavigationParameters { { "HymnNymber", _hymn.HymnNumber } };
//	        await _navigationService.NavigateAsync("MainNavigation?selectedTab=HymnPlayPage");
//	    }

	    private async void OnPlayClicked()
	    {
	        //var navParams = new NavigationParameters { { "HymnNymber", _hymn.HymnNumber } };
	        await _navigationService.NavigateAsync("MainNavigation?selectedTab=HymnPlayPage");
	    }

        public HymnDetailPageViewModel() { }
        public HymnDetailPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            //PlayCommand = new DelegateCommand(OnPlayClicked);
        }

	    public void OnNavigatedFrom(INavigationParameters parameters)
	    {

	    }

	    public void OnNavigatedTo(INavigationParameters parameters)
	    {
	        var hymns = new HymnService();
            if (parameters.ContainsKey("HymnNumber"))
	        {
	            Hymn = hymns.Hymns.FirstOrDefault(hymn => hymn.HymnNumber == (int)parameters["HymnNumber"]);
	        }
            else
            {
                Hymn = hymns.Hymns.FirstOrDefault();
            }
        }

	    
        public void OnNavigatingTo(INavigationParameters parameters)
	    {
	        
        }
	}
}
