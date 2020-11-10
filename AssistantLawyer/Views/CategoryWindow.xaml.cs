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
    /// Логика взаимодействия для CategoryWindow.xaml
    /// </summary>
    public partial class CategoryWindow : Window, INotifyPropertyChanged
    {
        RegistrationBook registrationBook;
        public CategoryWindow()
        {
            InitializeComponent();
        }

        public CategoryWindow(RegistrationBook registrationBook) : this()
        {
            RegistrationBook = registrationBook;
            lst0.ItemsSource = RegistrationBook.Contracts.
                Select(c => c).
                Where(c => c.Category == Category.Civil).ToList();
            lst1.ItemsSource = RegistrationBook.Contracts.
                Select(c => c).
                Where(c => c.Category == Category.Criminal).ToList();
            lst2.ItemsSource = RegistrationBook.Contracts.
                Select(c => c).
                Where(c => c.Category == Category.Economic).ToList();
            lst3.ItemsSource = RegistrationBook.Contracts.
                Select(c => c).
                Where(c => c.Category == Category.Administrative).ToList();
        }

        public RegistrationBook RegistrationBook
        {
            get => registrationBook; 
            set
            {
                registrationBook = value;
                OnPropertyChanged("RegistrationBook");
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
    }
}
