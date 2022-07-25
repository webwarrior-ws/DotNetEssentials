using System;
using System.Threading.Tasks;

namespace Xamarin.Essentials
{
    public static partial class Launcher
    {
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        static async Task<bool> PlatformCanOpenAsync(Uri uri)
        {
            throw ExceptionUtils.NotSupportedOrImplementedException;
        }

        static Task PlatformOpenAsync(Uri uri)
        {
            throw ExceptionUtils.NotSupportedOrImplementedException;
        }

        static async Task PlatformOpenAsync(OpenFileRequest request)
        {
            throw ExceptionUtils.NotSupportedOrImplementedException;
        }

        static async Task<bool> PlatformTryOpenAsync(Uri uri)
        {
            var canOpen = await PlatformCanOpenAsync(uri);

            if (canOpen)
                throw ExceptionUtils.NotSupportedOrImplementedException;

            return canOpen;
        }
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
    }
}
