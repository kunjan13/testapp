using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Media;

using Xamarin.Forms;
using Plugin.Media.Abstractions;
using AuditAppPcl.Manager.Contracts;

namespace AuditAppPcl
{
    public partial class PerformAudit : ContentPage
    {
        public IAuditInformation auditInformation;
        public PerformAudit(IAuditInformation auditInformation)
        {
            this.auditInformation = auditInformation;
            InitializeComponent();
        }

        public async void TakePictureButton_Clicked(object sender,EventArgs e)
        {
            //await DisplayAlert("No Camera", "No Camera Available", "OK");
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", "No Camera Available", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
            {
                //Directory= ""
                SaveToAlbum = true,
                Name = "test1212.jpg"
            });

            if (file == null)
            {
                return;
            }

            //Image1.Source = ImageSource.FromStream(() => file.GetStream());
        }
    }
}
