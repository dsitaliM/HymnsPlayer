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
	    private readonly HymnService _hymns;

        private Hymn _hymn;
	    public Hymn Hymn
	    {
	        get => _hymn;
	        set => SetProperty(ref _hymn, value);
	    }

	    private DelegateCommand<Hymn> _playCommand;
	    public DelegateCommand<Hymn> PlayCommand
            => _playCommand ?? (_playCommand = new DelegateCommand<Hymn>(OnPlayClicked));


        private async void OnPlayClicked(Hymn hymn)
	    {
	        var navParams = new NavigationParameters { { "HymnNumber", Hymn.HymnNumber } };
	        await _navigationService.NavigateAsync("MainNavigation?selectedTab=HymnPlayPage", navParams);
	    }

        public HymnDetailPageViewModel() { }
        public HymnDetailPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            _hymns = new HymnService();
        }

	    public void OnNavigatedFrom(INavigationParameters parameters)
	    {

	    }

	    public void OnNavigatedTo(INavigationParameters parameters)
	    {
	        Hymn = parameters.ContainsKey("HymnNumber") 
	            ? _hymns.Hymns.FirstOrDefault(hymn => hymn.HymnNumber == (int)parameters["HymnNumber"]) 
	            : _hymns.Hymns.FirstOrDefault();
	    }

	}
}
