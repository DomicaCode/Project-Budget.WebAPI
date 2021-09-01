using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Budget.Model.Models.Membership
{
    [Table("User")]
    public class User : BaseModel
    {
        public string Email { get; set; }

        public string HashedPassword { get; set; }

        [NotMapped]
        public string Password { get; set; }

        public string PasswordSalt { get; set; }

        public string Username { get; set; }

    }
}
