using ElVegetarianoFurio.Core;

namespace ElVegetarianoFurio.Contact
{
    public class ContactViewModel : BaseViewModel
    {
        private readonly IMap _map;
        private readonly IPhoneDialer _phoneDialer;

        public ContactViewModel(IMap map, IPhoneDialer phoneDialer)
        {
            Title = "Kontakt";
            NavigateCommand = new Command(OnNavigate);
            CallCommand = new Command(OnCall);
            _map = map;
            _phoneDialer = phoneDialer;
        }

        public Command NavigateCommand { get; }
        public Command CallCommand { get; }

        private void OnNavigate()
        {
            // Code zu besseren Übersichtlichkeit entfernt. Erklärung folgt im nächsten 
            // Listing

            var placemark = new Placemark
            {
                CountryName = "Germany",            // Land
                PostalCode = "53498",               // Postleitzahl
                Locality = "Bad Breisig",           // Ort
                Thoroughfare = "Brunnenstraße 21"   // Straße
            };

            var options = new MapLaunchOptions
            {
                Name = "El Vegetariano Furio",            // Bezeichnung auf der Karte
                NavigationMode = NavigationMode.Driving   // Navigationsmodus (Fahren, Laufen ...)
            };
            _map.OpenAsync(placemark, options);

        }

        private void OnCall()
        {
            _phoneDialer.Open("0123456789");
        }
    }

}
