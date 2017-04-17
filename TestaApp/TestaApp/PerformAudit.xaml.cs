using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Media;

using Xamarin.Forms;
using Plugin.Media.Abstractions;
using AuditAppPcl.Manager.Contracts;
using AuditAppPcl.Entities;
using System.IO;

namespace AuditAppPcl
{
    public partial class PerformAudit : ContentPage
    {
        public IAuditInformation auditInformation;
        public List<Attachement> vm = new List<Attachement>();
        public PerformAudit(IAuditInformation auditInformation)
        {
            this.auditInformation = auditInformation;
            //this.BindingContext = vm;
            listView.ItemTemplate = new DataTemplate(typeof(ImageCell)); // has context actions defined
            listView.ItemTemplate.SetBinding(ImageCell.ImageSourceProperty, "path");
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

            var newAttachment = new Attachement();
            newAttachment.Data = TestFunction(file);
            newAttachment.Comments = "";
                //ImageSource.FromStream(() => file.GetStream());
            //Image1.Source = ImageSource.FromStream(() => file.GetStream());
        }

        private byte[] TestFunction(MediaFile file)
        {
            using (var memoryStream = new MemoryStream())
            {
                file.GetStream().CopyTo(memoryStream);
                file.Dispose();
                return memoryStream.ToArray();
            }
        }
    }
}
