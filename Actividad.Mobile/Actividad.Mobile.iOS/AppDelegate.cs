using Foundation;
using UIKit;
using Xamarin;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace Actividad.Mobile.iOS
{
    [Register("AppDelegate")]
    public class AppDelegate : FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication aplicacion, NSDictionary opciones)
        {
            Forms.Init();

            FormsMaps.Init();

            this.LoadApplication(new App());

            return base.FinishedLaunching(aplicacion, opciones);
        }
    }
}
