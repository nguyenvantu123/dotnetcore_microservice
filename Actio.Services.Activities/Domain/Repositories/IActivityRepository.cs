using System;
using System.Threading.Tasks;
using Actio.Services.Activities.Domain.Models;

namespace Actio.Services.Activities.Domain.Repositories {
    public interface IActivityRepository {
        Task<Activity> GetAsync (Guid guid);

        Task AddSync (Activity activity);
    }
}