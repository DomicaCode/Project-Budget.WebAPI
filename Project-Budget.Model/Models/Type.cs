using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Budget.Model.Models
{
    public class Type : BaseModel
    {
        public string Name { get; set; }

        public string Currency { get; set; }
    }
}
