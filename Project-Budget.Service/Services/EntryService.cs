using Project_Budget.Common;
using Project_Budget.Model.Models;
using Project_Budget.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project_Budget.Service.Services
{
    public class EntryService : IEntryService
    {
        public EntryService(IEntryRepository entryRepository)
        {
            EntryRepository = entryRepository;
        }

        public IEntryRepository EntryRepository { get; }

        public async Task<bool> AddAsync(Entry model)
        {
            return await EntryRepository.InsertAsync(model).ConfigureAwait(false);
        }


        public async Task<bool> DeleteAsync(Guid entryId)
        {
            return await EntryRepository.DeleteAsync(entryId).ConfigureAwait(false);
        }


        public async Task<bool> EditAsync(Entry model)
        {
            return await EntryRepository.EditAsync(model).ConfigureAwait(false);
        }

        public async Task<IList<Entry>> GetAllAsync(ExtendedFilter filter)
        {

            return await EntryRepository.GetAllAsync(filter).ConfigureAwait(false);
        }

        public async Task<Entry> GetAsync(ExtendedFilter filter)
        {
            return await EntryRepository
                .GetAsync(filter)
                .ConfigureAwait(false);
        }
    }
}
