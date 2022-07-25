using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Xamarin.Essentials.Background
{
    public partial class Background
    {
        internal static void PlatformStart()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                Background.StartJobs();
            else
                throw ExceptionUtils.NotSupportedOrImplementedException;
        }
    }
}
