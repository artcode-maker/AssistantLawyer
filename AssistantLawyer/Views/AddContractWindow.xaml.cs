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

namespace AssistantLawyer.Views
{
    /// <summary>
    /// Логика взаимодействия для AddContractWindow.xaml
    /// </summary>
    public partial class AddContractWindow : Window
    {
        public Contract contract;
        public AddContractWindow()
        {
            InitializeComponent();
        }

        public AddContractWindow(Contract contract, Client client = null) : this()
        {
            this.contract = contract;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Category category;
            switch (((ComboBoxItem)(cBoxCategory.SelectedItem)).Tag.ToString())
            {
                case "Civil":
                    category = Category.Civil;
                    break;
                case "Criminal":
                    category = Category.Criminal;
                    break;
                case "Economic":
                    category = Category.Economic;
                    break;
                case "Administrative":
                    category = Category.Administrative;
                    break;
                default:
                    category = Category.Civil;
                    break;
            }
            contract = new Contract
            {
                Notes = txtBoxNotes.Text,
                Subject = txtBoxSubjectContract.Text,
                Category = category,
                Date = (DateTime)DateContract.SelectedDate,
                Client = new Client
                {
                    IsConsultationOnly = false,
                    IsContract = true,
                    Address = txtBoxAddress.Text,
                    Name = txtBoxNameClient.Text,
                    PhoneNumber = txtBoxTelClient.Text
                }
            };
            DialogResult = true;
        }
    }
}
