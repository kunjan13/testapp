using System;

namespace AuditAppPcl.Entities
{
    public class MenuItems : BaseViewModel
    {
        private string name;
        private string icon;
        private bool isselected = false;
        private Type targettype;

        public string Name {
            get
            {
                return name;
            }

            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public string Icon {
            get
            {
                return icon;
            }

            set
            {
                icon = value;
                OnPropertyChanged("Icon");
            }
        }
        public string BackgroundColor {
            get
            {
                if (IsSelected)
                {
                    return "#F3A116";
                }
                else
                {
                    return "White";
                }
            }
        }
        public bool IsSelected {
            get
            {
                return isselected;
            }

            set
            {
                isselected = value;
                OnPropertyChanged("IsSelected");
                OnPropertyChanged("BackgroundColor");
            }
        }
        public Type TargetType
        {
            get
            {
                return targettype;
            }

            set
            {
                targettype = value;
                OnPropertyChanged("Name");
            }
        }
    }
}
