using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Project_Budget.Common.Filters;
using Project_Budget.DAL.Context;
using Project_Budget.Model.Models.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Budget.Repository.Repositories
{
    public class UserRepository : BaseRepository<User, UserFilter>, IUserRepository
    {
        public UserRepository(BudgetContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override async Task<User> GetAsync(UserFilter filter)
        {
            User result = default;

            if (filter.Id != null)
            {
                result = await DbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == filter.Id).ConfigureAwait(false);
            }

            if (filter.Username != null)
            {
                result = await DbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Username == filter.Username).ConfigureAwait(false);
            }

            if (filter.Email != null)
            {
                result = await DbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Email == filter.Email).ConfigureAwait(false);
            }

            return result;
        }
    }
}
