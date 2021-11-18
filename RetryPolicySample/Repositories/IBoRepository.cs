using System;
using System.Threading.Tasks;

namespace RetryPolicySample.Repositories
{
    public interface IBoRepository : IDisposable
    {
        Task<bool> SaveAsync(object bo);
    }
}
