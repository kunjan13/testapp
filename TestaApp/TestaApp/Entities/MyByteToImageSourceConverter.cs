using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AuditAppPcl.Entities
{
    public class MyByteToImageSourceConverter: IValueConverter
    {
        public object Convert(object pobjValue, Type pobjTargetType, object pobjParameter, System.Globalization.CultureInfo pobjCulture)
        {
            ImageSource objImageSource;
            //
            if (pobjValue != null)
            {
                byte[] bytImageData = (byte[])pobjValue;
                //
                objImageSource = ImageSource.FromStream(() => new MemoryStream(bytImageData));
            }
            else
            {
                objImageSource = null;
            }
            //
            return objImageSource;
        }

        public object ConvertBack(object pobjValue, Type pobjTargetType, object pobjParameter, System.Globalization.CultureInfo pobjCulture)
        {
            throw new NotImplementedException();
        }
    }
}
