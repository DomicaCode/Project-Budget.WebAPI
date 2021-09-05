using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Budget.Common.Filters
{
    public class CategoryFilter : GenericFilter
    {
        public Guid UserId { get; set; }
    }
}
