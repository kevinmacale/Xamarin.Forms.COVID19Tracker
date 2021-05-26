using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace COVID19.Shared.Model
{
    public abstract class ObservableObject : INotifyPropertyChanged
    {
        #region Properties
        /// <summary>
        /// PropertyChanged event handler
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Methods
        /// <summary>
        /// Sets property calling on property change
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="storage"></param>
        /// <param name="value"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        protected Boolean SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            // if new value = existing value then do nothing
            if (Equals(storage, value)) return false;

            // assign the new value
            storage = value;

            // run OnPropertyChanged to update bindings, etc
            OnPropertyChanged(propertyName);

            // return true as we successfully changed the value
            return true;
        }

        /// <summary>
        /// OnPropertyChanged method.
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
