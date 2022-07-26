using UIKit;

namespace Samples.iOS
{
    public class Application
    {
        static void Main(string[] args)
        {
#pragma warning disable CS0618
            UIApplication.Main(args, null, nameof(AppDelegate));
#pragma warning restore CS0618
        }
    }
}
