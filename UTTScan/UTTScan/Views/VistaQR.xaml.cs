using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace UTTScan.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VistaQR : ContentPage
    {
        public VistaQR()
        {
            InitializeComponent();
        }

        private async void btnScannerQR_Clicked(object sender, EventArgs e)
        {
            try
            {
                var scanner = new ZXing.Mobile.MobileBarcodeScanner();
                scanner.TopText = "UTTSCAN";
                var result = await scanner.Scan();
                if (result != null)
                {
                    txtResultado.Text = result.Text;
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message.ToString(), "ok");
            }
        }
    }
}