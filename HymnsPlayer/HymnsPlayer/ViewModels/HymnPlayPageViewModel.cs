using System;
using Prism.Mvvm;
using System.Linq;
using HymnsPlayer.Models;
using HymnsPlayer.Services;
using Plugin.SimpleAudioPlayer;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms;

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

	    private int _hymnNumber;
	    public int HymnNumber
	    {
	        get => _hymnNumber;
	        set => SetProperty(ref _hymnNumber, value);
	    }

	    private double _sliderMax;
	    public double SliderMax
	    {
	        get => _sliderMax;
	        set => SetProperty(ref _sliderMax, value);
	    }

	    private bool _sliderEnabled;
	    public bool SliderEnabled
	    {
	        get => _sliderEnabled;
	        set => SetProperty(ref _sliderEnabled, value);
	    }

	    private double _sliderValue;
	    public double SliderValue
	    {
	        get => _sliderValue;
	        set => SetProperty(ref _sliderValue, value);
	    }

//	    private DelegateCommand<double> _sliderValueChangedCommand;
//	    public DelegateCommand<double> SliderValueChangedCommand
//	        => _sliderValueChangedCommand ??
//	           (_sliderValueChangedCommand = new DelegateCommand<double>(SliderValueChanged));


	    private DelegateCommand _playCommand;
	    public DelegateCommand PlayCommand
	        => _playCommand ??
	           (_playCommand = new DelegateCommand(PlayHymn));

	    private void SliderValueChanged(double value)
	    {
            if (Math.Abs(value - _player.Duration) > 0.00001)
                _player.Seek(value);
	    }

	    private int _tracker = 1;
	    private void PlayHymn()
	    {
	        if (_tracker == 1)
	        {
	            Icon = "md-pause";
	            _player.Play();
	            SliderMax = _player.Duration;
	            SliderEnabled = _player.CanSeek;
	            Device.StartTimer(TimeSpan.FromSeconds(0.5), UpdateSliderPosition);
	            _player.Loop = true;
	            _tracker = 2;
	        }
	        else
	        {
	            Icon = "md-play-arrow";
                _player.Pause();
	            _tracker = 1;
	        }
	    }

	    private bool UpdateSliderPosition()
	    {
	        SliderValue = _player.CurrentPosition;
            //SliderValueChangedCommand.Execute(SliderValue);

	        return _player.IsPlaying;
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
	        if (parameters.ContainsKey("HymnNumber"))
	            Hymn = _hymns.Hymns.FirstOrDefault(hymn => hymn.HymnNumber == (int) parameters["HymnNumber"]);

	        if (Hymn != null)
	            _player.Load($"{Hymn.HymnNumber}.mid");
	    }
	}
}
