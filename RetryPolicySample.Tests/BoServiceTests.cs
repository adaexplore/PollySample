using Moq;
using RetryPolicySample.Repositories;
using RetryPolicySample.Services;
using System;
using System.Threading.Tasks;
using Polly;
using Xunit;

namespace RetryPolicySample.Tests
{

    public class BoServiceTests
    {
        [Fact]
        public void Save_With_RetryPolicy_Handles_TimeoutException_Success()
        {

            var policies = PolicyConfig.RegisterPolicies();

            var repoMock = new Mock<IBoRepository>();

            repoMock.SetupSequence(db => db.SaveAsync(It.IsAny<object>()))
                .Throws<TimeoutException>()
                .Returns(Task.FromResult(true));

            var service = new BoService(repoMock.Object, policies);

            // Act
            var returned = service.Save("bo");
            //Assert
            Assert.True(returned.Result);
        }
    }
}


