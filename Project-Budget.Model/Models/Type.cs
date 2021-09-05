using Project_Budget.Model.Models.Membership;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Budget.Model.Models
{
    public class Type : BaseModel
    {
        public string Name { get; set; }

        public string Currency { get; set; }

        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
