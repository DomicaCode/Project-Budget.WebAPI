using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Budget.Model.Models.Authorization
{
    public class Token : IToken
    {
        public string AccessToken { get; set; }
    }
}
