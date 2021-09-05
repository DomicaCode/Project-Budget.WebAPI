using AutoMapper;
using Project_Budget.Common;
using Project_Budget.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Budget.Repository.Repositories
{
    public class TypeRepository : BaseRepository<Model.Models.Type, GenericFilter>, ITypeRepository
    {
        public TypeRepository(BudgetContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
