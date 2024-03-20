using SQLite;
using System.ComponentModel;

namespace SneakerLocalMaui.Models
{
    public class Sneakers : INotifyPropertyChanged
    {
        private bool _isSelected;
        private int _selectedQuantity; // New property

        [PrimaryKey, AutoIncrement]
        public int SneakerId { get; set; }

        public string SneakerPic {  get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        [Ignore] // This property won't be stored in the SQLite database
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    OnPropertyChanged(nameof(IsSelected));
                }
            }
        }

        // Property to store the selected quantity
        [Ignore] // This property won't be stored in the SQLite database
        public int SelectedQuantity
        {
            get { return _selectedQuantity; }
            set
            {
                if (_selectedQuantity != value)
                {
                    _selectedQuantity = value;
                    OnPropertyChanged(nameof(SelectedQuantity));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
