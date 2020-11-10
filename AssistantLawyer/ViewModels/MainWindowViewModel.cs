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

namespace AssistantLawyer.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private ContractsRepository context = new ContractsRepository();
        private ObservableCollection<Client> clients;

        private Contract selectedContract;
        public Contract SelectedContract
        {
            get => selectedContract;
            set
            {
                selectedContract = value;
                OnPropertyChanged("SelectedContract");
            }
        }

        public MainWindowViewModel()
        {
            clients = context.GetAllClients();
        }
        private RegistrationBook registrationBook;
        public MainWindowViewModel(RegistrationBook registrationBook) : this()
        {
            this.registrationBook = registrationBook;
        }
        public bool IsChanged { get; set; }
        public RegistrationBook RegistrationBook
        {
            get
            {
                if (registrationBook == null)
                {
                    registrationBook = new RegistrationBook { Contracts = context.GetAll() };
                }
                return registrationBook;
            }
            set
            {
                registrationBook = value;
                OnPropertyChanged("RegistrationBook");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (propertyName != nameof(IsChanged))
            {
                IsChanged = true;
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(string.Empty));
        }

        private RelayCommandT<Contract> _addContractCommand = null;
        public RelayCommandT<Contract> AddContractCommand
        {
            get
            {
                return _addContractCommand ?? 
                    (_addContractCommand = new RelayCommandT<Contract>(obj => 
                    {
                        try
                        {
                            AddContractWindow contractWindow = new AddContractWindow();
                            if (contractWindow.ShowDialog() == true)
                            {
                                var maxCountClient = RegistrationBook.Contracts?.Max(x => x.ContractID) ?? 0;
                                var maxCountContract = RegistrationBook.Contracts?.Max(x => x.ContractID) ?? 0;
                                Contract contract = contractWindow.contract;
                                contract.Client.CientID = ++maxCountClient;
                                contract.ContractID = ++maxCountContract;
                                RegistrationBook.Contracts.Add(contract);
                                context.Save();
                                contractWindow.Close();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }));
            }
        }

        private RelayCommandT<Contract> _deleteContractCommand = null;
        public RelayCommandT<Contract> DeleteContractCommand
        {
            get
            {
                return _deleteContractCommand ??
                    (_deleteContractCommand = new RelayCommandT<Contract>(obj =>
                    {
                        try
                        {
                            if (SelectedContract == null)
                            {
                                MessageBox.Show("Выберите элемент");
                                return;
                            }
                            MessageBoxResult result = MessageBox.Show("Вы уверены?", "Удалить запись", MessageBoxButton.YesNo);
                            if (result == MessageBoxResult.Yes)
                            {
                                Contract contract = SelectedContract as Contract;
                                context.Delete(contract);
                                context.Save();
                                SelectedContract = null;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }));
            }
        }

        private RelayCommandT<Contract> _editContractCommand = null;
        public RelayCommandT<Contract> EditContractCommand
        {
            get
            {
                return _editContractCommand ??
                    (_editContractCommand = new RelayCommandT<Contract>(obj =>
                    {
                        try
                        {
                            if (SelectedContract == null)
                            {
                                MessageBox.Show("Выберите элемент");
                                return;
                            }
                            EditContractWindow contractWindow = new EditContractWindow(SelectedContract);
                            if (contractWindow.ShowDialog() == true)
                            {
                                context.Save();
                                contractWindow.Close();
                                SelectedContract = null;
                            }
                            else SelectedContract = null;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }));
            }
        }


        private RelayCommandT<Contract> _saveFileBookCommand = null;
        public RelayCommandT<Contract> SaveFileBookCommand
        {
            get
            {
                return _saveFileBookCommand ??
                    (_saveFileBookCommand = new RelayCommandT<Contract>(obj =>
                    {
                        try
                        {
                            RegistrationBook.SaveRegBook();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }));
            }
        }

        private RelayCommandT<Contract> _printFileBookCommand = null;
        public RelayCommandT<Contract> PrintFileBookCommand
        {
            get
            {
                return _printFileBookCommand ??
                    (_printFileBookCommand = new RelayCommandT<Contract>(obj =>
                    {
                        try
                        {
                            RegistrationBook.PrintRegBook();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }));
            }
        }

        private RelayCommandT<Contract> _clientsCommand = null;
        public RelayCommandT<Contract> ClientsCommand
        {
            get
            {
                return _clientsCommand ??
                    (_clientsCommand = new RelayCommandT<Contract>(obj =>
                    {
                        try
                        {
                            ClientsWindow clientsWindow = new ClientsWindow(clients);
                            if (clientsWindow.ShowDialog() == true)
                            {
                                context.Save();
                                clientsWindow.Close();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }));
            }
        }

        private RelayCommandT<Contract> _categoryCommand = null;
        public RelayCommandT<Contract> CategoryCommand
        {
            get
            {
                return _categoryCommand ??
                    (_categoryCommand = new RelayCommandT<Contract>(obj =>
                    {
                        try
                        {
                            CategoryWindow categoryWindow = new CategoryWindow(RegistrationBook);
                            if (categoryWindow.ShowDialog() == true)
                            {
                                categoryWindow.Close();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }));
            }
        }

        private RelayCommandT<Contract> _openRegBookCommand = null;
        public RelayCommandT<Contract> OpenRegBookCommand
        {
            get
            {
                return _openRegBookCommand ??
                    (_openRegBookCommand = new RelayCommandT<Contract>(obj =>
                    {
                        try
                        {
                            RegistrationBook.OpenRegBook();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }));
            }
        }

        private RelayCommandT<Contract> _licenseCommand = null;
        public RelayCommandT<Contract> LicenseCommand
        {
            get
            {
                return _licenseCommand ??
                    (_licenseCommand = new RelayCommandT<Contract>(obj =>
                    {
                        try
                        {
                            MessageBox.Show("Программа распространяется бесплатно при условии проставления " +
                                "оценки 9 или 10 по СВПП",
                                "Лицензия", MessageBoxButton.OK, MessageBoxImage.Information,
                                MessageBoxResult.OK);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }));
            }
        }

        private RelayCommandT<Contract> _aboutCommand = null;
        public RelayCommandT<Contract> AboutCommand
        {
            get
            {
                return _aboutCommand ??
                    (_aboutCommand = new RelayCommandT<Contract>(obj =>
                    {
                        try
                        {
                            MessageBox.Show("Программное средство по учету договоров на оказание юридической помощи.",
                                "О программе", MessageBoxButton.OK, MessageBoxImage.Information,
                                MessageBoxResult.OK);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }));
            }
        }

        private RelayCommandT<Contract> _authorCommand = null;
        public RelayCommandT<Contract> AuthorCommand
        {
            get
            {
                return _authorCommand ??
                    (_authorCommand = new RelayCommandT<Contract>(obj =>
                    {
                        try
                        {
                            MessageBox.Show("Пусть это останется нашим маленьким секретом :)",
                                "Об авторе", MessageBoxButton.OK, MessageBoxImage.Information,
                                MessageBoxResult.OK);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }));
            }
        }

        static TimerCallback timerCallback = new TimerCallback(PrintTime);
        readonly Timer timer = new Timer(timerCallback, null, 0, 500);
        private static void PrintTime(object state)
        {
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background,
                (ThreadStart)delegate ()
                {
                    MainWindow my = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
                    my.StatusBar.Text = DateTime.Now.ToLongTimeString();
                }
                );
        }
    }
}
