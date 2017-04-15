using UIKit;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using AuditAppPcl.CustomUI;
using OneSystemAudit.iOS.CustomUI;
using Foundation;

[assembly: ExportRenderer(typeof(AuditEntry), typeof(AuditEntryRenderer))]
namespace OneSystemAudit.iOS.CustomUI
{
    public class AuditEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                var themeColor = new Color(12, 22, 92);
                var view = e.NewElement as AuditEntry;
                // do whatever you want to the UITextField here!
                Control.BorderStyle = UITextBorderStyle.Line;
                Control.Layer.BorderColor = view.PlaceholderTextColor.ToCGColor();
                Control.Layer.BorderWidth = 1;
                var placeholderColor = new UIStringAttributes()
                {
                    ForegroundColor = view.PlaceholderTextColor.ToUIColor()
                };
                NSAttributedString placeholderString = new NSAttributedString(view.Placeholder, placeholderColor);

                Control.AttributedPlaceholder = placeholderString;
            }
        }
    }
}