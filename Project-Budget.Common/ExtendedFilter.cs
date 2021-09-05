using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Budget.Common
{
    public class ExtendedFilter : GenericFilter, IExtendedFilter
    {
        public Guid UserId { get; set; }
    }
}
