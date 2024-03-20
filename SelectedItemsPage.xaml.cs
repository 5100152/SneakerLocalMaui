using Microsoft.Maui.Controls;
using SneakerLocalMaui.Models;
using System.Collections.ObjectModel;
using SneakerLocalMaui.Services;
using System.Diagnostics;
using System.Linq;

namespace SneakerLocalMaui
{
    public partial class SelectedItemsPage : ContentPage
    {
        private ObservableCollection<Sneakers> SelectedSneakers { get; set; }
        private SneakerLocalDatabase _database;

        public SelectedItemsPage(ObservableCollection<Sneakers> selectedSneakers)
        {
            InitializeComponent();
            SelectedSneakers = selectedSneakers;
            BindingContext = this;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Filter out the selected sneakers
            var selectedItems = SelectedSneakers.Where(s => s.IsSelected).ToList();

            // Display the selected items with their quantities
            SelectedItemsListView.ItemsSource = selectedItems.Select(s => new
            {


                SelectedQuantity = s.SelectedQuantity // Display the selected quantity
            });
        }
    }
}
