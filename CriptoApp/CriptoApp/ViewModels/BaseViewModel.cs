using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using CriptoApp.Models;
using CriptoApp.Services;

namespace CriptoApp.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public IDataStore<CriptoCurrencyModel> CriptoServiceDataStore => DependencyService.Get<IDataStore<CriptoCurrencyModel>>() ?? new CriptoServiceDataStore();
        public IDataStore<CriptoCurrencyModel> LoginServiceDataStore => DependencyService.Get<IDataStore<CriptoCurrencyModel>>() ?? new CriptoServiceDataStore();
        public IDataStore<UserPortfoyModel> PortfoyServiceDataStore => DependencyService.Get<IDataStore<UserPortfoyModel>>() ?? new PortfoyServiceDataStore();



        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        bool popupIsVisible = false;
        public bool PopupIsVisible
        {
            get { return popupIsVisible; }
            set { SetProperty(ref popupIsVisible, value); }
        }

        string _selectedItem;
        public string selectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged("selectedItem");
            }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
