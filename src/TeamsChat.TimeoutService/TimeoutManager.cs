using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using TeamsChat.TimeoutService.Models;

namespace TeamsChat.TimeoutService
{
    public static class TimeoutManager
    {
        public static async Task<TimeoutResponse<TResult>> TimeoutValidator<TResult>(Func<TResult> inputFunction, int timeoutInSeconds)
        {
            Task<TResult> task = Task<TResult>.Factory.StartNew(() => inputFunction());

            return await TimeoutChecker(task, timeoutInSeconds);
        }
        public static async Task<TimeoutResponse<TResult>> TimeoutValidator<TInput, TResult>(Func<TInput, TResult> inputFunction, TInput parameters, int timeoutInSeconds)
        {
            Task<TResult> task = Task<TResult>.Factory.StartNew(() => inputFunction(parameters));

            return await TimeoutChecker(task, timeoutInSeconds);
        }

        private static async Task<TimeoutResponse<TResult>> TimeoutChecker<TResult>(Task<TResult> task, int timeoutInSeconds)
        {
            TimeoutResponse<TResult> result = new TimeoutResponse<TResult>();

            using (var timeoutCancellationTokenSource = new CancellationTokenSource())
            {
                TimeSpan seconds = TimeSpan.FromSeconds(timeoutInSeconds);

                var completedTask = await Task.WhenAny(task, Task.Delay(seconds, timeoutCancellationTokenSource.Token));
                if (completedTask == task)
                {
                    timeoutCancellationTokenSource.Cancel();
                    result.Output = await task;

                    return result;
                }
                else
                {
                    result.Output = default(TResult);
                    result.StatusCode = HttpStatusCode.RequestTimeout;
                    return result;
                }
            }
        }
    }
}
