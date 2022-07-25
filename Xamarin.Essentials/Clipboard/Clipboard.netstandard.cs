using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Xamarin.Essentials
{
    public static partial class Clipboard
    {
        static readonly Gdk.Atom clipboardAtom = Gdk.Atom.Intern("CLIPBOARD", false);

        static Task PlatformSetTextAsync(string text)
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                throw ExceptionUtils.NotSupportedOrImplementedException;

            var clipboard = Gtk.Clipboard.Get(clipboardAtom);
            clipboard.Text = text;
            return Task.FromResult(0);
        }

        static bool PlatformHasText
        {
            get
            {
                if (!RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                    throw ExceptionUtils.NotSupportedOrImplementedException;

                var clipboard = Gtk.Clipboard.Get(clipboardAtom);
                return clipboard.WaitIsTextAvailable();
            }
        }

        static Task<string> PlatformGetTextAsync()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                throw ExceptionUtils.NotSupportedOrImplementedException;

            var clipboard = Gtk.Clipboard.Get(clipboardAtom);
            return Task.FromResult(clipboard.WaitForText());
        }

        static void StartClipboardListeners()
            => throw ExceptionUtils.NotSupportedOrImplementedException;

        static void StopClipboardListeners()
            => throw ExceptionUtils.NotSupportedOrImplementedException;
    }
}
