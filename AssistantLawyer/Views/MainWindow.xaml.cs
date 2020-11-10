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
using System.Windows.Navigation;
using System.Windows.Shapes;
using AssistantLawyer.EF;
using AssistantLawyer.Models;
using AssistantLawyer.ViewModels;
using AssistantLawyer.Views;
using AssistantLawyer.Commands;
using AssistantLawyer.Repository;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Messaging;

namespace AssistantLawyer.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        void CloseCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }
        void CanExecuteHandler(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
}
