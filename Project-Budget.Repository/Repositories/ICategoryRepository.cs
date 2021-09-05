using Project_Budget.Common;
using Project_Budget.Common.Filters;
using Project_Budget.Model.Models;
using Project_Budget.Model.Models.Membership;
using System.Threading.Tasks;

namespace Project_Budget.Repository.Repositories
{
    public interface ICategoryRepository : IBaseRepository<Category, GenericFilter>
    {
    }
}