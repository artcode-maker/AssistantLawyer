using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Controls;
using System.Drawing.Printing;
using Spire.Xls;
using System.Linq.Expressions;

namespace AssistantLawyer.Models
{
    public class RegistrationBook
    {
        public ObservableCollection<Contract> Contracts { get; set; }

        public void OpenRegBook()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Файлы Excel(*.xlsx)|*.xlsx|Все файлы(*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                string filename = openFileDialog.FileName;
                Excel.Application application = new Excel.Application();
                Excel.Workbook xlWorkbook = application.Workbooks.Open(filename);
                Excel._Worksheet xlWorksheet = application.ActiveSheet;
                Excel.Range xlRange = xlWorksheet.UsedRange;
                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;

                for (int i = 1; i <= rowCount; i++)
                {
                    for (int j = 1; j <= colCount; j++)
                    {
                        MessageBox.Show(xlWorksheet.Cells[i, j].ToString());
                    }
                }
                return;
            }
        }

        public void SaveRegBook()
        {
            string nameBook = "Книга регистрации договоров на оказание юридической помощи";
            Excel.Application application = new Excel.Application();
            application.Workbooks.Add();
            Excel._Worksheet worksheet = application.ActiveSheet;
            worksheet.Cells[1, "B"] = nameBook;
            worksheet.Cells[2, "A"] = "Номер регистрации";
            worksheet.Cells[2, "B"] = "Клиент или иное лицо, действующее в его интересах";
            worksheet.Cells[2, "C"] = "Дата заключения договора на оказание юридической помощи";
            worksheet.Cells[2, "D"] = "Предмет договора на оказание юридической помощи";
            worksheet.Cells[2, "E"] = "Примечание";
            int row = 2;
            foreach (Contract contract in Contracts)
            {
                row++;
                worksheet.Cells[row, "A"] = contract.ContractID;
                worksheet.Cells[row, "B"] = contract.Client.Name;
                worksheet.Cells[row, "C"] = contract.Date.ToShortDateString();
                worksheet.Cells[row, "D"] = contract.Subject;
                worksheet.Cells[row, "E"] = contract.Notes;
            }
            worksheet.Range["A1"].AutoFormat(Excel.XlRangeAutoFormat.xlRangeAutoFormatClassic2);
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Файлы Excel(*.xlsx)|*.xlsx|Все файлы(*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                string filename = saveFileDialog.FileName;
                worksheet.SaveAs(filename);
                application.Quit();
                MessageBox.Show($"Книга регистрации договоров сохранена по адресу:\n{filename}");
                return;
            }
            else return;
        }

        public void PrintRegBook()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Файлы Excel(*.xlsx)|*.xlsx|Все файлы(*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                string filename = openFileDialog.FileName;
                Workbook workbook = new Workbook();
                workbook.LoadFromFile(filename);
                PrintDialog dialog = new PrintDialog();
                dialog.UserPageRangeEnabled = true;
                PageRange rang = new PageRange(1, 3);
                dialog.PageRange = rang;
                PageRangeSelection seletion = PageRangeSelection.UserPages;
                dialog.PageRangeSelection = seletion;
                PrintDocument pd = workbook.PrintDocument;
                if (dialog.ShowDialog() == true)
                {
                    pd.Print();
                    return;
                }
                else return;
            }
        }
    }
}
