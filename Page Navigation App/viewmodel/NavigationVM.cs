using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Page_Navigation_App.utilities;
using System.Windows.Input;

namespace Page_Navigation_App.viewmodel
{
    class NavigationVM : ViewModelBase
    {
        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }

        public ICommand HomeCommand { get; set; }
        public ICommand CustomersCommand { get; set; }
        public ICommand ProductsCommand { get; set; }
        public ICommand OrdersCommand { get; set; }
        public ICommand TransactionsCommand { get; set; }
        public ICommand ShipmentsCommand { get; set; }
        public ICommand SettingsCommand { get; set; }

        private void Home(object obj) => CurrentView = new HomeVM();
        private void Customers(object obj) => CurrentView = new CustomersVM();
        private void Products(object obj) => CurrentView = new ProductsVM();
        private void Order(object obj) => CurrentView = new OrderVM();
        private void Transactions(object obj) => CurrentView = new TransactionsVM();
        private void Shipments(object obj) => CurrentView = new ShipmentsVM();
        private void Settings(object obj) => CurrentView = new SettingsVM();

        public NavigationVM()
        {
            HomeCommand = new RelayCommand(Home);
            CustomersCommand = new RelayCommand(Customers);
            ProductsCommand = new RelayCommand(Products);
            OrdersCommand = new RelayCommand(Order);
            TransactionsCommand = new RelayCommand(Transactions);
            ShipmentsCommand = new RelayCommand(Shipments);
            SettingsCommand = new RelayCommand(Settings);
          
            // Startup Page
            CurrentView = new HomeVM();
        }

    }
}
