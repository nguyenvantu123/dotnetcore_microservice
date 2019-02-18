using System;
using System.Collections;
using System.Threading.Tasks;

namespace Actio.Services.Activities.Domain.Repositories
{
    public interface ICategoryRepository
    {
         Task<Category> GetAsync(Guid guid);
         
         Task<IEnumerable> BrowseAsync(Guid guid);

         Task AddAsync(Category category);
    }
}