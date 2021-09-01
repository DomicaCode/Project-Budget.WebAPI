using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Budget.Common
{
    public class GenericFilter : IGenericFilter
    {
        public string Abrv { get; set; }
        public Guid? Id { get; set; }

        public string Name { get; set; }
    }
}
