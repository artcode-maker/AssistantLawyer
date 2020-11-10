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

namespace AssistantLawyer.ViewModels
{
    public class EditContractWindowViewModel : INotifyPropertyChanged
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

        public EditContractWindowViewModel() { }

        public EditContractWindowViewModel(Contract contract, Client client = null) : this()
        {
            Contract = contract;
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
    }
}
