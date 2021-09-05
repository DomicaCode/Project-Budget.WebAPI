using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Project_Budget.Common;
using Project_Budget.DAL.Context;
using Project_Budget.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Budget.Repository.Repositories
{
    public class EntryRepository : BaseRepository<Entry, ExtendedFilter>, IEntryRepository
    {
        public EntryRepository(BudgetContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<IList<Entry>> GetAllAsync(ExtendedFilter filter)
        {
            return await DbSet
                .Where(x => x.UserId == filter.UserId)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public override async Task<Entry> GetAsync(ExtendedFilter filter)
        {
            if (filter.Id != null)
            {
                return await DbSet
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == filter.Id && x.UserId == filter.UserId)
                    .ConfigureAwait(false);
            }

            return null;
        }
    }
}
