using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CollectionViewSamples.Services;
using Microsoft.Maui.Controls;

namespace CollectionViewSamples.ViewModels
{
    public abstract class BaseViewModel<T> : INotifyPropertyChanged
    {
        private bool _isBusy;
        private string _title = string.Empty;

        public event PropertyChangedEventHandler PropertyChanged;

        public IDataStore<T> DataStore => DependencyService.Get<IDataStore<T>>();

        /// <summary>
        /// IsBusy gibt an, ob gerade ein längerer Aufruf läuft.
        /// Die Eigenschaft muss explizit durch den Entwickler gesetzt werden.
        /// Sie kann genutzt werden, um in der View eine Ladeanimation anzuzeigen
        /// </summary>
        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        /// <summary>
        /// Titel des ViewModels. Dient zur Anzeige der Überschrift in der View
        /// </summary>
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public virtual Task Initialize()
        {
            return Task.FromResult(default(object));
        }

        /// <summary>
        /// Aktualisiert den Wert eines Felds und löst das Ereignis
        /// <see cref="PropertyChanged"/> aus, falls erforderlich.
        /// </summary>
        /// <typeparam name="T">Datentyp des zu ändernden Felds</typeparam>
        /// <param name="backingStore">das zu ändernde Feld</param>
        /// <param name="value">neuer Wert</param>
        /// <param name="propertyName">Name der Eigenschaft, die das Feld umschließt.</param>
        /// <param name="onChanged">Methode, die Aufgerufen werden soll, falls
        /// der Wert verändert wurde.</param>
        /// <returns></returns>
        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
            {
                return false;
            }

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
