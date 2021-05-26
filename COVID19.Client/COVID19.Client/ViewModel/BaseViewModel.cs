using COVID19.Client.Services;
using COVID19.Shared.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace COVID19.Client.ViewModel
{
    /// <summary>
    /// View Model Base
    /// </summary>
    public abstract class BaseViewModel : ObservableObject
    {
        private bool _isProgressing;
        private string _title;

        public bool IsProgressing { get => _isProgressing; set => SetProperty(ref _isProgressing, value); }
        public string Title { get => _title; set => SetProperty(ref _title, value); }
        public IServiceLocator Services { get; set; } = ServiceLocator.Instance;
        public BaseViewModel()
        {
        }
        /// <summary>
        /// Handles loaded
        /// </summary>
        /// <param name="param"></param>
        public virtual Task OnLoaded(object param)
        {
            return default;
        }
        /// <summary>
        /// Handles unloaded
        /// </summary>
        /// <param name="param"></param>
        public virtual Task OnUnLoaded(object param)
        {
            return default;
        }
    }
}
