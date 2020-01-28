using System;
using System.Threading.Tasks;
using AppKit;
using Foundation;

namespace Xamarin.Essentials
{
    public static partial class Launcher
    {
        static Task<bool> PlatformCanOpenAsync(Uri uri) =>
            Task.FromResult(NSWorkspace.SharedWorkspace.UrlForApplication(new NSUrl(uri.AbsoluteUri)) != null);

        static Task PlatformOpenAsync(Uri uri) =>
            Task.FromResult(NSWorkspace.SharedWorkspace.OpenUrl(new NSUrl(uri.AbsoluteUri)));

        static Task PlatformOpenAsync(OpenFileRequest request) =>
            throw new FeatureNotSupportedException();

        static async Task<bool> PlatformTryOpenAsync(Uri uri)
        {
            var canOpen = await PlatformCanOpenAsync(uri).ConfigureAwait(false);

            if (canOpen)
                await PlatformOpenAsync(uri).ConfigureAwait(false);

            return canOpen;
        }
    }
}
