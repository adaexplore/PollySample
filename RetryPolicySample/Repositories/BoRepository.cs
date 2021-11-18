using System.Threading.Tasks;

namespace RetryPolicySample.Repositories
{
    public class BoRepository : IBoRepository
    {

       
        Task<bool> IBoRepository.SaveAsync(object bo)
        {
            //Avoid involving 3rd part packages, I would use TimeoutException instead of ConnectionException to demonstrate.
            throw new System.TimeoutException();
        }
        public void Dispose()
        {
        }
    }
}
