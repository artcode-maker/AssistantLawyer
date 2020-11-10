using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Infrastructure.Interception;
using AssistantLawyer.Models;
using System.Configuration;

namespace AssistantLawyer.EF
{
    public partial class AssistantLawyerEntities : DbContext
    {
        public AssistantLawyerEntities() : base("AssistantLawyerConnection")
        {
            Database.SetInitializer(new DataInitializer());
        }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Contract> Contracts { get; set; }
    }
}
