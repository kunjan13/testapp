using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AuditAppPcl.Entities
{
    public class AttachmentViewModel: Xamarin.Forms.View
    {
        //public Image Img { get; set; }

        public static readonly BindableProperty MyImageAsBytesProperty = BindableProperty.Create<AttachmentViewModel, byte[]>(p => p.MyImageAsBytes, default(byte[]));

        public byte[] MyImageAsBytes
        {
            get { return (byte[])GetValue(MyImageAsBytesProperty); }
            set { SetValue(MyImageAsBytesProperty, value); }
        }

        public string Comment
        {
            get;
            set;
        }
    }
}
