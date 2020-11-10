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
    public class ClientsRepository //: IRepository<Client>
    {
        AssistantLawyerEntities context;
        public ClientsRepository()
        {
            context = new AssistantLawyerEntities();
        }
        public void Create(Client item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Client Get(Client client)
        {
            List<Client> l = new List<Client>();
            l = context.Clients.Select(c => c).ToList();
            return l.Where(c => c.CientID == client.CientID).FirstOrDefault();
        }

        public ObservableCollection<Client> GetAll()
        {
            context.Clients.Load();
            return context.Clients.Local;
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Client item)
        {
            throw new NotImplementedException();
        }
    }
}