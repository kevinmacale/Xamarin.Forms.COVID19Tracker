using COVID19.Client.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace COVID19.Client.View
{
    public class BaseContentPage : ContentPage
    {
        private readonly object _onloadParam;

        public BaseContentPage(object onloadParam = null)
        {
            this._onloadParam = onloadParam;
        }

        protected override async void OnAppearing()
        {
            var vm = BindingContext as BaseViewModel;
            await vm.OnLoaded(_onloadParam);
        }

        protected override void OnDisappearing()
        {
            var vm = BindingContext as BaseViewModel;
            vm.OnUnLoaded(_onloadParam);
        }
        /// <summary>
        /// Get generic view model
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetViewModel<T>() where T : BaseViewModel
        {
            return BindingContext as T;
        }
    }
}
