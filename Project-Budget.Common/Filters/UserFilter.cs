using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Budget.Common.Filters
{
    public class UserFilter : GenericFilter
    {
        public string Email { get; set; }
        public string Username { get; set; }
    }
}
