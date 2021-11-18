using Polly;
using Polly.Registry;
using RetryPolicySample.Repositories;
using System.Threading.Tasks;

namespace RetryPolicySample.Services
{
    public class BoService : IBoService
    {
        private readonly ISyncPolicy _iSyncPolicy;
        private readonly IBoRepository _boRepository;
        public BoService(IBoRepository boRepository, IReadOnlyPolicyRegistry<string> policyRegistry)
        {
            _boRepository = boRepository;
            _iSyncPolicy = policyRegistry.Get<ISyncPolicy>("MyRetryPolicy");          
        }

        public async Task<bool> Save(object bo)
        {
            return await _iSyncPolicy.Execute(() => _boRepository.SaveAsync(bo));
        }
    }
}
