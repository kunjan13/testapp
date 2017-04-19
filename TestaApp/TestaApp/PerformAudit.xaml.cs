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
using System.Windows.Input;

namespace AuditAppPcl
{
    public partial class PerformAudit : ContentPage
    {
        public IAuditInformation auditInformation;
        public List<Attachement> vm = new List<Attachement>();
        public List<Image> images = new List<Image>();

        public event EventHandler CanExecuteChanged;

        //public List<AttachmentViewModel> attView = new List<AttachmentViewModel>();
        public PerformAudit(IAuditInformation auditInformation)
        {
            this.auditInformation = auditInformation;
            //this.BindingContext = vm;
            //listView.ItemTemplate = new DataTemplate(typeof(ImageCell)); // has context actions defined
            //listView.ItemTemplate.SetBinding(ImageCell.ImageSourceProperty, "path");
            byte[] bytImage;
            //this.BindingContext = new AttachmentViewModel()
            //{
            //    MyImageAsBytes = null
            //};
            
            //listView.ItemTemplate = new DataTemplate(typeof(TextCell));
            //listView.ItemTemplate.SetBinding(TextCell.TextProperty, "StringComment");
            
            //List<Image> images = new List<Image>();
            //this.BindingContext = new AttachmentViewModel();
            InitializeComponent();
            var avm = new AuditViewModel()
            {
                ApplicantName = "ApplicationName",
                CaseUID = "CaseUId",
                CaseSubject = "CaseSubject",
                Plot = "Plot",
                UserName = "UserName",
                InspectionStatus = "Status",
                Inspector = "XYZ",
                BuildingOfficer = "",
                InspectionDate = DateTime.Now.Date,
                AuditAppId = 123,
                Comment = ""
            };            
            //listView.ItemTemplate = new DataTemplate(typeof(TextCell));
            //listView.ItemTemplate.SetBinding(ImageCell.ImageSourceProperty, "Name");
            //listView.ItemsSource = avm.Attachements;
            this.BindingContext = avm;
        }

        public ImageSource CreateImageSource()
        {
            DisplayAlert("test", "Test", "test");
            return null;
        }

        public async void TakePictureGalleryButton_Clicked(object sender,EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Upload", "Picking a photo is not supported.", "OK");
                return;
            }
            var file = await CrossMedia.Current.PickPhotoAsync();
            if(file == null)
            {
                return;
            }
            byte[] bytImage = TestFunction(file);

            var abc = new Attachement()
            {
                Data = bytImage,
                StringComment = ""
            };

            vm.Add(abc);

            SetAtt();
        }

        public async void TakePictureButton_Clicked(object sender, EventArgs e)
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
                Name = "test" + (images.Count + 1) + ".jpg"
            });

            if (file == null)
            {
                return;
            }

            StackLayout objStackLayout = new StackLayout();

            byte[] bytImage = TestFunction(file);


            //this.BindingContext = new AttachmentViewModel()
            //{
            //    MyImageAsBytes = bytImage,
            //    Comment = ""
            //};

            //var abc = new AttachmentViewModel()
            //{
            //    MyImageAsBytes = bytImage,
            //    Comment = ""
            //};
            var abc = new Attachement()
            {
                Data = bytImage,
                StringComment = ""
            };

            vm.Add(abc);

            SetAtt();
            //Image objImage = new Image();
            //objImage.SetBinding(Image.SourceProperty, "MyImageAsBytes", converter: new MyByteToImageSourceConverter());
            //objImage.HeightRequest = 250;
            //images.Add(objImage);

            //objStackLayout.Children.Add(objImage);

            //layout.Children.Add(objStackLayout);

            //var newAttachment = new Attachement();
            //newAttachment.Data = TestFunction(file);
            //newAttachment.Comments = "";
            //ImageSource.FromStream(() => file.GetStream());
            //Image1.Source = ImageSource.FromStream(() => file.GetStream());
        }

        
        private void SetAtt()
        {
            //var j = 0;
            //for (var i = 2; i < vm.Count; i = i+2)
            //{
            //    var tempElement = (Entry)layout.Children.ElementAt(i);
            //    vm[j].StringComment = tempElement.Text;
            //    j++;
            //}
            //for (var i =1; i < vm.Count;i++)
            //{
            //    layout.Children.RemoveAt(i);
            //}
            StackLayout objStackLayout = new StackLayout();
            objStackLayout.Orientation = StackOrientation.Vertical;
            var id = 0;
            var count = layout.Children.Count - 1;
            for(var i = count; i <= vm.Count; i++)
            {
                var att = vm[i - 1];
                att.Name = id.ToString();
                var objImageSource = ImageSource.FromStream(() => new MemoryStream(att.Data));
                Image abc = new Image();
                abc.HeightRequest = 250;
                abc.Source = objImageSource;
                Entry commentEntry = new Entry();
                commentEntry.WidthRequest = 200;
                commentEntry.Text = att.StringComment;
                //commentEntry.HorizontalTextAlignment = TextAlignment.Center;
                //commentEntry.HorizontalOptions = LayoutOptions.End;
                Button btn = new Button();
                btn.Clicked += DeleteImg;
                btn.CommandParameter = i - 1;
                //btn.HorizontalOptions = LayoutOptions.Center;
                //btn.VerticalOptions = LayoutOptions.Center;
                btn.Text = "Delete";
                btn.TextColor = Color.White;
                btn.WidthRequest = 150;
                btn.HeightRequest = 50;
                btn.FontSize = 20;
                btn.BackgroundColor = Color.Black;

                //btn.Command = 
                //btn.CommandParameter = "";
                objStackLayout.Children.Add(abc);
                objStackLayout.Children.Add(commentEntry);
                objStackLayout.Children.Add(btn);
            }
            //foreach (var att in vm)
            //{
            //    //Image objImageSource = new Image();
            //    att.Name = id.ToString();
            //    var objImageSource = ImageSource.FromStream(() => new MemoryStream(att.Data));
            //    Image abc = new Image();
            //    abc.HeightRequest = 250;
            //    abc.Source = objImageSource;
            //    Entry commentEntry = new Entry();
            //    commentEntry.WidthRequest = 200;
            //    commentEntry.Text = att.StringComment;
            //    objStackLayout.Children.Add(abc);
            //    objStackLayout.Children.Add(commentEntry);
            //}
            layout.Children.Add(objStackLayout);
        }

        public void DeleteImg(object sender, EventArgs e)
        {
            //DisplayAlert(e.ToString(), "TEST", "TEST");
            layout.Children.RemoveAt(Convert.ToInt32(((Xamarin.Forms.Button)sender).CommandParameter) + 2);
            vm.RemoveAt(Convert.ToInt32(((Xamarin.Forms.Button)sender).CommandParameter));
            var j = 0;
            for (var i = 2; i < layout.Children.Count; i++)
            {
                var tempElement = (StackLayout)layout.Children.ElementAt(i);
                vm[j].StringComment = ((Entry) tempElement.Children.ElementAt(1)).Text;
                j++;
            }
            for (var i = layout.Children.Count - 1; i >= 2; i--)
            {
                layout.Children.RemoveAt(i);
            }
            var id = 0;
            for (var i = 0; i < vm.Count; i++)
            {
                StackLayout objStackLayout = new StackLayout();
                objStackLayout.Orientation = StackOrientation.Vertical;
                var att = vm[i];
                att.Name = id.ToString();
                var objImageSource = ImageSource.FromStream(() => new MemoryStream(att.Data));
                Image abc = new Image();
                abc.HeightRequest = 250;
                abc.Source = objImageSource;
                Entry commentEntry = new Entry();
                commentEntry.WidthRequest = 200;
                commentEntry.Text = att.StringComment;
                Button btn = new Button();
                btn.Clicked += DeleteImg;
                btn.CommandParameter = i;
                btn.Text = "Delete";
                btn.TextColor = Color.White;
                btn.WidthRequest = 150;
                btn.HeightRequest = 50;
                btn.FontSize = 20;
                btn.BackgroundColor = Color.Black;

                //btn.Command = 
                //btn.CommandParameter = "";
                objStackLayout.Children.Add(abc);
                objStackLayout.Children.Add(commentEntry);
                objStackLayout.Children.Add(btn);
                layout.Children.Add(objStackLayout);
            }
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

    //public class DeleteButtonClick : ICommand
    //{
    //    public event EventHandler CanExecuteChanged;

    //    public bool CanExecute(object parameter)
    //    {
    //        return true;
    //    }

    //    public void Execute(object parameter)
    //    {
    //        //throw new NotImplementedException();
    //    }
    //}
}
