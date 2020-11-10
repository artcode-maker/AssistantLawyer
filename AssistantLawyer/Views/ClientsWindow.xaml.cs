using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using AssistantLawyer.Models;
using AssistantLawyer.Repository;
using AssistantLawyer.Commands;
using System.Collections.ObjectModel;
using System.Windows.Input;
using AssistantLawyer.Views;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;

using Microsoft.Win32;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.Remoting.Messaging;
using System.Windows.Threading;
using System.CodeDom;

namespace AssistantLawyer.Views
{
    /// <summary>
    /// Логика взаимодействия для ClientsWindow.xaml
    /// </summary>
    public partial class ClientsWindow : Window, INotifyPropertyChanged
    {
        private ObservableCollection<Client> clients;
        public ClientsWindow()
        {
            InitializeComponent();
        }

        public ClientsWindow(ObservableCollection<Client> clients) :this()
        {
            Clients = clients;
            dg1.ItemsSource = Clients.Select(c => c).Where(c => c.IsContract).ToList();
            dg2.ItemsSource = Clients.Select(c => c).Where(c => c.IsConsultationOnly).ToList();
        }

        public ObservableCollection<Client> Clients
        {
            get => clients; 
            set
            {
                clients = value;
                OnPropertyChanged("Clients");
            }
        }

        public bool IsChanged { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (propertyName != nameof(IsChanged))
            {
                IsChanged = true;
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(string.Empty));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Clients.Add(new Client
            {
                IsConsultationOnly = true,
                IsContract = false,
                Name = txtBoxNameClient.Text,
                Address = txtBoxAddress.Text,
                PhoneNumber = txtBoxTelClient.Text
            });
            MessageBox.Show("Новый клиент добавлен!");
            DialogResult = true;
        }
    }
}
