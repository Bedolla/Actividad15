using Windows.Services.Maps;
using Xamarin;

namespace Actividad.Mobile.UWP
{
    public sealed partial class MainPage
    {
        private const string Token = "2iu5uSLrMgqrEq8OLKZb~kyoKPRahGFeV1-krcYe6rQ~Anio9dUecUuoYtl4ADORU-TqR2jr0_sRxsNcZQ35S3aFzu5roYUhTcvFmA_-Nn3x";

        public MainPage()
        {
            this.InitializeComponent();

            FormsMaps.Init(MainPage.Token);

            MapService.ServiceToken = MainPage.Token;

            this.LoadApplication(new Mobile.App());
        }
    }
}
