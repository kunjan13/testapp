using SignaturePad.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AuditAppPcl
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class signature : ContentPage
    {
        public signature()
        {
            InitializeComponent();
        }

        private async void OnGetStats(object sender, EventArgs e)
        {
            string base64String;
            var points = padView.Points.ToArray();
            var image = await padView.GetImageStreamAsync(SignatureImageFormat.Png);
            using (var memoryStream = new MemoryStream())
            {
                image.CopyTo(memoryStream);
                var byteArray = memoryStream.ToArray();
                base64String = Convert.ToBase64String(byteArray);
            }
            var pointCount = points.Count();
            var imageSize = image.Length / 1000;
            var linesCount = points.Count(p => p == Point.Zero) + (points.Length > 0 ? 1 : 0);

            image.Dispose();

            await DisplayAlert("Stats", $"The signature has {linesCount} lines or {pointCount} points, and is {imageSize:#,###.0}KB (in memory) when saved as a PNG.", "Cool");
        }
    }
}
