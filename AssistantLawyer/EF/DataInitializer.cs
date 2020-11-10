using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssistantLawyer.Models;

namespace AssistantLawyer.EF
{
    public class DataInitializer : CreateDatabaseIfNotExists<AssistantLawyerEntities> //DropCreateDatabaseAlways<AssistantLawyerEntities>
    {
        protected override void Seed(AssistantLawyerEntities context)
        {
            List <Contract> contracts = new List<Contract>
            {
                new Contract()
                {
                    Category = Category.Civil,
                    Date = new DateTime(2020, 07, 15),
                    Subject = "Представление интересов истца в суде Центрального района г.Минска по гражданскому делу",
                    Notes = "",
                    Client = new Client
                    {
                        IsConsultationOnly = false,
                        IsContract = true,
                        Name = "Иванов Николай Васильевич",
                        Address = "г.Минск, ул. Советская, д.15, кв.6",
                        PhoneNumber = "1294537"
                    }
                },
                new Contract()
                {
                    Category = Category.Criminal,
                    Date = new DateTime(2020, 07, 16),
                    Subject = "Участие по уголовному делу на стадии предварительного расследования",
                    Notes = "",
                    Client = new Client
                    {
                        IsConsultationOnly = false,
                        IsContract = true,
                        Name = "Петров Федор Николаевич",
                        Address = "г.Минск, ул. Первомайская, д.7, кв.31",
                        PhoneNumber = "4538547"
                    }
                },
                new Contract()
                {
                    Category = Category.Civil,
                    Date = new DateTime(2020, 07, 18),
                    Subject = "Представление интересов истца в суде Фрунзенского района г.Минска по гражданскому делу",
                    Notes = "",
                    Client = new Client
                    {
                        IsConsultationOnly = false,
                        IsContract = true,
                        Name = "Васильев Петр Иванович",
                        Address = "г.Минск, ул. Узденская, д.27, кв.42",
                        PhoneNumber = "6374321"
                    }
                }
            };
            contracts.ForEach(x => context.Contracts.AddOrUpdate(c => new { c.Category, c.Date, c.Subject, c.Notes }, x));
            List<Client> clients = new List<Client>
            {
                new Client 
                {
                    IsConsultationOnly = true,
                    IsContract = false,
                    Name = "Калистратов Никита Валерьевич",
                    Address = "г.Минск, ул. Славная, д.11, кв.18",
                    PhoneNumber = "4839271"
                },
                new Client
                {
                    IsConsultationOnly = true,
                    IsContract = false,
                    Name = "Вознесенский Кирилл Иосифович",
                    Address = "г.Минск, ул. Первая, д.3, кв.29",
                    PhoneNumber = "3949120"
                },
                new Client
                {
                    IsConsultationOnly = true,
                    IsContract = false,
                    Name = "Чёрный Андрей Викторович",
                    Address = "г.Минск, ул. Набережная, д.54, кв.33",
                    PhoneNumber = "2263953"
                }
            };
            clients.ForEach(x => context.Clients.AddOrUpdate(c => new { c.Name, c.Address, c.PhoneNumber }, x));
            context.SaveChanges();
        }
    }
}
