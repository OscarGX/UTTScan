using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UTTScan.ViewModels;
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
                //var scanner = new ZXing.Mobile.MobileBarcodeScanner();
                //scanner.TopText = "UTTSCAN";
                // var result = await scanner.Scan();
                if (true)
                {
                    Uri requestUri = new Uri("http://utttproyect-001-site1.itempurl.com/api/control-acceso");
                    var fecha = DateTime.Now;
                    var client = new HttpClient();
                    ControlAcceso ctracceso = new ControlAcceso {

                        Fecha = fecha,
                        Dia = fecha.Day,
                        Mes = fecha.Month,
                        Anio = fecha.Year,
                        Mintos = fecha.Minute,
                        Hora = fecha.Hour,
                        FkAlumno = int.Parse("18300181")
                        
                    };
                    var json = JsonConvert.SerializeObject(ctracceso);
                    var contentjson = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(requestUri, contentjson);
                    if(response.StatusCode == HttpStatusCode.OK ){
                        await DisplayAlert("ok", "Acceso Concedido", "ok");
                    }
                    else
                    {
                        await DisplayAlert("ok No", "No tienes acceso", "ok");
                    }
                    // txtResultado.Text = result.Text;
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message.ToString(), "ok");
            }
        }
    }
}