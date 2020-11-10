using AssistantLawyer.EF;
using AssistantLawyer.Interfaces;
using AssistantLawyer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using System.Collections.ObjectModel;

namespace AssistantLawyer.Repository
{
    public class ContractsRepository //: IRepository<Contract>
    {
        AssistantLawyerEntities context;
        public ContractsRepository()
        {
            context = new AssistantLawyerEntities();
        }
        public void Create(Contract item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Contract contact)
        {
            context.Contracts.Remove(contact);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Contract Get(int id)
        {
            throw new NotImplementedException();
        }

        public Client GetClient(Client client)
        {
            List<Client> l = new List<Client>();
            l = context.Contracts.Select(c => c.Client).ToList();
            return l.Where(c => c.CientID == client.CientID).FirstOrDefault();
        }

        public ObservableCollection<Contract> GetAll()
        {
            //context.Contracts.Load();
            //ObservableCollection<Contract> _contracts = context.Contracts.Local;
            //Mapper.Initialize(cfg =>
            //{
            //    cfg.CreateMap<Station, StationViewModel>();
            //    cfg.CreateMap<Train, TrainViewModel>();
            //});
            //var stations = Mapper.Map<ObservableCollection<StationViewModel>>(_contracts);
            //return stations;

            //context.Clients.Load();
            context.Contracts.Load();
            return context.Contracts.Local;
        }

        public ObservableCollection<Client> GetAllClients()
        {
            context.Clients.Load();
            return context.Clients.Local;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Contract item)
        {
            throw new NotImplementedException();
        }
    }
}
