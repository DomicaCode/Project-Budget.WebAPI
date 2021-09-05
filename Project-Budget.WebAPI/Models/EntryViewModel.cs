using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Budget.WebAPI.Models
{
    public class EntryViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public double? Price { get; set; }

        [Required]
        public Guid? TypeId { get; set; }
    }
}
