using System.Threading.Tasks;

namespace RetryPolicySample.Services
{
    public interface IBoService
    {
        Task<bool> Save(object bo);
    }
}
