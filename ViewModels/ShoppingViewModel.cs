using System.Collections.ObjectModel;
using System.ComponentModel;
using SneakerLocalMaui.Models;

namespace SneakerLocalMaui.ViewModels
{
    public class ShoppingViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Sneakers> _sneakers;

        public ObservableCollection<Sneakers> Sneakers
        {
            get => _sneakers;
            private set
            {
                if (_sneakers != value)
                {
                    _sneakers = value;
                    OnPropertyChanged(nameof(Sneakers));
                }
            }
        }

        // Constructor
        public ShoppingViewModel()
        {
            // Initialize the ObservableCollection of Sneakers
            Sneakers = new ObservableCollection<Sneakers>();
        }

        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
