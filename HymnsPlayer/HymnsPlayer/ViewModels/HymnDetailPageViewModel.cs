using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using HymnsPlayer.Models;
using HymnsPlayer.Services;
using Prism;
using Prism.Navigation;

namespace HymnsPlayer.ViewModels
{
	public class HymnDetailPageViewModel : BindableBase, INavigatedAware
	{

	    private INavigationService _navigationService;
	    private Hymn _hymn;
	    public Hymn Hymn
	    {
	        get => _hymn;
	        set => SetProperty(ref _hymn, value);
	    }
        public HymnDetailPageViewModel() { }
        public HymnDetailPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

	    public void OnNavigatedFrom(INavigationParameters parameters)
	    {

	    }

	    public void OnNavigatedTo(INavigationParameters parameters)
	    {
	        if (parameters.ContainsKey("HymnNumber"))
	        {
	            var hymns = new HymnService();
	            Hymn = hymns.Hymns.FirstOrDefault(hymn => hymn.HymnNumber == (int)parameters["HymnNumber"]);
	        }
        }

	    public void OnNavigatingTo(INavigationParameters parameters)
	    {
	        
        }
	}
}
