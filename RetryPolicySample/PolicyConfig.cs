using Polly;
using Polly.Registry;
using System;

namespace RetryPolicySample
{
    public class PolicyConfig
    {
        //this method probably lives on a configuration or startup class in app in real code.
        //Avoid involving 3rd part packages, I would use TimeoutException instead of ConnectionException to demonstrate.
        public static IPolicyRegistry<string> RegisterPolicies() =>

            new PolicyRegistry {

                {
                    "MyRetryPolicy", Policy.Handle<TimeoutException>().WaitAndRetry(
                    retryCount: 3,
                    sleepDurationProvider:c=>TimeSpan.FromSeconds(1),
                    onRetry: (exception, sleepDuration, attemptNumber, context) =>
                        {   
                            // log message.
                            Console.WriteLine($"Retrying in {sleepDuration}.{attemptNumber} / 3, due to {exception.Message}");
                        })

                },
                {
                    "NoPolicy", Policy.NoOpAsync()
                }
                // ... and other policies for the app             
            };
    }
}
