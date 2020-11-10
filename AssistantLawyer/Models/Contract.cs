using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssistantLawyer.Models
{
    public class Contract : INotifyPropertyChanged
    {
        [NotMapped]
        public bool IsChanged { get; set; }
        [Key]
        public int ContractID { get; set; }
        public DateTime Date { get; set; }
        public Client Client { get; set; }
        public string Subject { get; set; }
        public string Notes { get; set; }
        public Category? Category { get; set; }

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
