using System;
using System.ComponentModel.DataAnnotations;

namespace Project_Budget.Model
{
    public class BaseModel : IBaseModel
    {
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        [Key]
        public Guid Id { get; set; }
    }
}
