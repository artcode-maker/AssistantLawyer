using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using AssistantLawyer.Models;
using AssistantLawyer.Repository;
using AssistantLawyer.Commands;
using System.Collections.ObjectModel;
using AssistantLawyer.Views;
using AssistantLawyer.ViewModels;

namespace AssistantLawyer.Views
{
    /// <summary>
    /// Логика взаимодействия для AddContractWindow.xaml
    /// </summary>
    public partial class EditContractWindow : Window, INotifyPropertyChanged
    {
        private Contract contract;
        public Contract Contract
        {
            get => contract;
            set
            {
                contract = value;
                OnPropertyChanged("Contract");
            }
        }
        public EditContractWindow()
        {
            InitializeComponent();
        }
        public EditContractWindow(Contract contract) : this()
        {
            Contract = contract;
            this.DataContext = Contract;
            switch (Contract.Category)
            {
                case Category.Civil:
                    Civil.IsSelected = true;
                    break;
                case Category.Criminal:
                    Criminal.IsSelected = true;
                    break;
                case Category.Economic:
                    Economic.IsSelected = true;
                    break;
                case Category.Administrative:
                    Administrative.IsSelected = true;
                    break;
                default:
                    Civil.IsSelected = true;
                    break;
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
            DialogResult = true;
        }
    }
}