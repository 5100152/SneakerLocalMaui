using System;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;
using SneakerLocalMaui.Models;
using SneakerLocalMaui.Services;
using SneakerLocalMaui;
using System.Diagnostics;



namespace SneakerLocalMaui
{
    public partial class MainPage : ContentPage
    {
        private SneakerLocalDatabase _database;
        private Customers _currentCustomer;
        private ObservableCollection<Sneakers> _sneakers;



        public Customers CurrentCustomer
        {
            get { return _currentCustomer; }
            set
            {
                _currentCustomer = value;
                OnPropertyChanged();
            }
        }


        public MainPage()
        {
            InitializeComponent();
            _database = new SneakerLocalDatabase();
            BindingContext = this;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadData();
        }

        private void ReloadButton_Clicked(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            // Load customer, shopping cart, and transactions data from the database
            Customers customer = _database.GetSavedCustomer();
            CurrentCustomer = customer;
        }

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                // Save current customer data in the database
                _database.SaveCustomer(CurrentCustomer);

                // Navigate to the ShoppingPage
                await Navigation.PushAsync(new ShoppingPage());
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                await DisplayAlert("Error", $"Failed to navigate to shopping page: {ex.Message}", "OK");
            }
        }
    }
    }