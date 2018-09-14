using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using HymnsPlayer.Models;
using HymnsPlayer.Services;
using MvvmHelpers;
using Prism;
using Prism.Navigation;

namespace HymnsPlayer.ViewModels
{
	public class HymnsPageViewModel : BindableBase, INavigatedAware, IDestructible
	{
	    private readonly INavigationService _navigationService;

	    private ObservableRangeCollection<Hymn> _hymns;
	    public ObservableRangeCollection<Hymn> Hymns
	    {
	        get => _hymns;
	        set => SetProperty(ref _hymns, value);
	    }

	    private ObservableRangeCollection<Hymn> _suggestions;
	    public ObservableRangeCollection<Hymn> Suggestions
	    {
	        get => _suggestions;
	        set => SetProperty(ref _suggestions, value);
	    }

	    private string _searchQuery;
	    public string SearchQuery
	    {
	        get => _searchQuery;
	        set => SetProperty(ref _searchQuery, value);
	    }

	    private DelegateCommand<Hymn> _selectHymn;
	    public DelegateCommand<Hymn> SelectHymnCommand
	        => _selectHymn ?? (_selectHymn = new DelegateCommand<Hymn>(ShowHymnDetails));


	    public DelegateCommand<Hymn> HymnSelectedCommand { get; set; }

	    public DelegateCommand SearchCommand => new DelegateCommand(Search).ObservesProperty(() => SearchQuery);

	    public void Search()
	    {
	        if (_searchQuery.Length >= 1)
	        {
	            var suggested = Hymns.Where(hymn =>
	                hymn.Title.ToLower().Contains(_searchQuery.ToLower()) ||
	                hymn.HymnNumber.ToString().Contains(_searchQuery)).ToList();

                Suggestions = new ObservableRangeCollection<Hymn>(suggested);
	        }
	        else
	        {
                Suggestions = new ObservableRangeCollection<Hymn>(Hymns.ToList());
	        }
	    }

	    private async void ShowHymnDetails(Hymn hymn)
	    {
	        var param = new NavigationParameters {{"HymnNumber", hymn.HymnNumber}};
	        await _navigationService.NavigateAsync("MainNavigation?selectedTab=HymnDetailPage", param);
        }

        public HymnsPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            var hymnRepo = new HymnService();

            Hymns = new ObservableRangeCollection<Hymn>();
            Suggestions = new ObservableRangeCollection<Hymn>();

            Suggestions.AddRange(hymnRepo.Hymns);
            Hymns.AddRange(hymnRepo.Hymns);

        }

	    public void OnNavigatedFrom(INavigationParameters parameters)
	    {
	    }

	    public void OnNavigatedTo(INavigationParameters parameters)
	    {

	    }

	    public void OnNavigatingTo(INavigationParameters parameters)
	    {

	    }

	    public void Destroy()
	    {

	    }
	}
}
