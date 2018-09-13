using System;
using Prism;
using Prism.Mvvm;
using Prism.Navigation;

namespace HymnsPlayer.ViewModels
{
    public abstract class ChildViewModelBase : BindableBase, IActiveAware, INavigatingAware, IDestructible
    {

        protected bool HasInitialized { get; set; }
        private bool _isActive;
        public bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value, RaiseIsActiveChanged);
        }
        public event EventHandler IsActiveChanged;
        public void OnNavigatingTo(INavigationParameters parameters)
        {
        }

        public void Destroy()
        {
        }

        protected virtual void RaiseIsActiveChanged()
        {
            IsActiveChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}