using UIKit;
using Xamarin.Forms.Platform.iOS;
using AuditAppPcl.CustomUI;
using Xamarin.Forms;
using OneSystemAudit.iOS.CustomUI;

[assembly: ExportRenderer(typeof(AuditTabbedPage), typeof(AuditTabbedPageRenderer))]
namespace OneSystemAudit.iOS.CustomUI
{
    public class AuditTabbedPageRenderer : TabbedRenderer
    {
        public AuditTabbedPageRenderer()
        {
            TabBar.BarTintColor = UIColor.FromRGB(1, 60, 63);
            //TabBar.BackgroundColor = UIColor.Green;
        }

        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);
            
            // Set Text Font for unselected tab states
            UITextAttributes normalTextAttributes = new UITextAttributes();            
            normalTextAttributes.Font = UIFont.FromName("ChalkboardSE-Light", 19.0F); // unselected

            UITabBarItem.Appearance.TitlePositionAdjustment = new UIOffset(-15, 0);
            UITabBarItem.Appearance.SetTitleTextAttributes(normalTextAttributes, UIControlState.Normal);
        }
    }
}