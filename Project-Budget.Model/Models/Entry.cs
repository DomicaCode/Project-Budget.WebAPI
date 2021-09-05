using Project_Budget.Model.Models.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Budget.Model.Models
{
    public class Entry : BaseModel
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public Guid TypeId { get; set; }

        public Type Type { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }
    }
}
