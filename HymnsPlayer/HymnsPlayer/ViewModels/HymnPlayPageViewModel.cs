using Prism.Mvvm;
using System.Linq;
using HymnsPlayer.Models;
using HymnsPlayer.Services;
using Plugin.SimpleAudioPlayer;
using Prism.Navigation;

namespace HymnsPlayer.ViewModels
{
	public class HymnPlayPageViewModel : BindableBase, INavigatedAware
	{
	    private readonly INavigationService _navigationService;
	    private readonly ISimpleAudioPlayer _player;
	    private readonly HymnService _hymns;

	    private Hymn _hymn;
	    public Hymn Hymn
	    {
	        get => _hymn;
	        set => SetProperty(ref _hymn, value);
	    }

	    private string _icon;
	    public string Icon
	    {
	        get => _icon;
	        set => SetProperty(ref _icon, value);
	    }

	    private string _songTite;
	    public string SongTitle
	    {
	        get => _songTite;
	        set => SetProperty(ref _songTite, value);
	    }

	    private string _hymnNumber;
	    public string HymnNumber
	    {
	        get => _hymnNumber;
	        set => SetProperty(ref _hymnNumber, value);
	    }
        public HymnPlayPageViewModel()
        {

        }

	    public HymnPlayPageViewModel(INavigationService navigationService)
	    {
	        _navigationService = navigationService;
            _hymns = new HymnService();
	        _player = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();

	        Icon = "md-play-arrow";

	    }   

	    public void OnNavigatedFrom(INavigationParameters parameters)
	    {
            _player.Stop();
	    }

	    public void OnNavigatedTo(INavigationParameters parameters)
	    {
	        Hymn = parameters.ContainsKey("HymnNumber") 
	            ? _hymns.Hymns.FirstOrDefault(hymn => hymn.HymnNumber == (int)parameters["HymnNumber"]) 
	            : _hymns.Hymns.FirstOrDefault();
	    }
	}
}
