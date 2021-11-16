using System;
using System.Threading;
using System.Threading.Tasks;
using TeamsChat.TimeoutService.Models;

namespace TeamsChat.TimeoutService
{
    public static class TimeoutManager
    {
        public static async Task<TimeoutReturnModel<TResult>> TimeoutValidator<TResult>(Func<TResult> inputFunction, int timeoutInSeconds)
        {
            TimeoutReturnModel<TResult> result = new TimeoutReturnModel<TResult>();

            Task<TResult> task = Task<TResult>.Factory.StartNew(() => inputFunction());

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
                    result.HasTimeOut = true;
                    return result;
                }
            }
        }
        public static async Task<TimeoutReturnModel<TResult>> TimeoutValidator<TInput, TResult>(Func<TInput, TResult> inputFunction, TInput parameters, int timeoutInSeconds)
        {
            TimeoutReturnModel<TResult> result = new TimeoutReturnModel<TResult>();

            Task<TResult> task = Task<TResult>.Factory.StartNew(() => inputFunction(parameters));

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
                    result.HasTimeOut = true;
                    return result;
                }
            }
        }
    }
}
