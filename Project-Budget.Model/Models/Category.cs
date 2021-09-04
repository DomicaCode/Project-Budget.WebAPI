using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Budget.Model.Models
{
    [Table("Category")]
    public class Category : BaseModel
    {
        public string Name { get; set; }

    }
}
