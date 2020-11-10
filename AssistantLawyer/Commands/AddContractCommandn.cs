//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using AssistantLawyer.Models;
//using System.Collections.ObjectModel;

//namespace AssistantLawyer.Commands
//{
//    public class AddContractCommand : CommandBase
//    {
//        public override bool CanExecute(object parameter)
//        {
//            return parameter != null && parameter is ObservableCollection<Contract>;
//        }

//        public override void Execute(object parameter)
//        {
//            if (parameter is ObservableCollection<Contract> contracts)
//            {
//                var maxCount = contracts?.Max(x => x.ContractID) ?? 0;
//                //cars?.Add(new Inventory { CarId = ++maxCount, Color = "Yellow", Make = "VW", PetName = "Birdie" });

//            }
//        }
//    }
//}
