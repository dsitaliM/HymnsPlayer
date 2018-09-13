using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism;
using Prism.Navigation;

namespace HymnsPlayer.ViewModels
{
	public class HymnDetailPageViewModel : BindableBase, INavigatedAware, INavigationAware, IActiveAware
	{
        public HymnDetailPageViewModel()
        {

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

	    public bool IsActive { get; set; }
	    public event EventHandler IsActiveChanged;
	}
}
