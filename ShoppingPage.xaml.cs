using Microsoft.Maui.Controls;
using SneakerLocalMaui.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SneakerLocalMaui;
using SneakerLocalMaui.Models;
using System.Diagnostics;

namespace SneakerLocalMaui
{
    public partial class ShoppingPage : ContentPage
    {
        private SneakerLocalDatabase _database;

        public ShoppingPage()
        {
            InitializeComponent();

            // Initialize the database
            _database = new SneakerLocalDatabase();

            // Load the list of sneakers and set it as the ListView's ItemsSource
            var sneakers = _database.GetAllSneakers();
            SneakersListView.ItemsSource = sneakers;
        }

        private void ShoppingCartButton_ClickedAsync(object sender, EventArgs e)
        {
            try
            {
                // Get the selected items
                var selectedSneakers = GetSelectedSneakers();

                // Check if any items are selected
                if (selectedSneakers.Any())
                {
                    // Create a message with the selected items
                    var message = "Selected Items:\n";
                    foreach (var sneaker in selectedSneakers)
                    {
                        message += $"{sneaker.Name} - Quantity: {sneaker.Quantity}\n";
                    }

                    // Display the message in a DisplayAlert
                    DisplayAlert("Selected Items", message, "OK");
                }
                else
                {
                    // Display a message if no items are selected
                    DisplayAlert("Alert", "No items selected.", "OK");
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                Console.WriteLine($"Error: {ex.Message}");
                DisplayAlert("Error", $"Failed to retrieve selected items: {ex.Message}", "OK");
            }
        }

        private List<Sneakers> GetSelectedSneakers()
        {
            // Retrieve the selected items from the ListView
            var selectedSneakers = new List<Sneakers>();
            foreach (var sneaker in SneakersListView.ItemsSource)
            {
                if (sneaker is Sneakers selectedSneaker && selectedSneaker.IsSelected)
                {
                    selectedSneakers.Add(selectedSneaker);
                }
            }
            return selectedSneakers;
        }

        private async void AddToCartButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                // Get the selected items
                List<Sneakers> selectedSneakers = GetSelectedSneakers();

                // Prompt the user to enter the selected quantity for each selected item
                foreach (var sneaker in selectedSneakers)
                {
                    // Show an input dialog for selected quantity
                    string selectedQuantityText = await DisplayPromptAsync("Enter Selected Quantity", $"Enter selected quantity for {sneaker.Name}", "OK", "Cancel", "1", -1, Keyboard.Numeric);

                    // Check if the user entered a selected quantity
                    if (!string.IsNullOrEmpty(selectedQuantityText))
                    {
                        // Parse the selected quantity
                        if (int.TryParse(selectedQuantityText, out int selectedQuantity))
                        {
                            // Add the item to the shopping cart with the specified selected quantity
                            ShoppingCart item = new ShoppingCart
                            {
                                SneakerId = sneaker.SneakerId,
                                Quantity = selectedQuantity // Use the selected quantity entered by the user
                            };
                            _database.UpdateShoppingCart(item);
                        }
                        else
                        {
                            // Show an error message if the entered selected quantity is invalid
                            await DisplayAlert("Error", "Invalid selected quantity. Please enter a valid number.", "OK");
                        }
                    }
                }

                // Display a success message
                await DisplayAlert("Success", "Selected items added to shopping cart.", "OK");
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                Debug.WriteLine($"Error: {ex.Message}");
                await DisplayAlert("Error", $"Failed to add selected items to shopping cart: {ex.Message}", "OK");
            }
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            // Deselect item
            ((ListView)sender).SelectedItem = null;

            // Get selected sneaker
            var selectedSneaker = e.SelectedItem as Sneakers;

            if (selectedSneaker != null)
            {
                // Navigate to the detail page passing the selected sneaker as parameter
                await Navigation.PushAsync(new SneakerDetailPage(selectedSneaker));
            }
        }

    }
}