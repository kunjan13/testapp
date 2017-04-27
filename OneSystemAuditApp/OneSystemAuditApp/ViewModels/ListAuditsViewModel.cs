using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using AuditAppPcl.Entities;
using Xamarin.Forms;

namespace AuditAppPcl
{
    public class ListAuditsViewModel : BaseViewModel
    {
        public ICommand DownloadCommand { protected set; get; }

        public ListAuditsViewModel()
        {
            DownloadCommand = new Command(OnDownload);
        }

        ObservableCollection<Audit> audits;
        public ObservableCollection<Audit> Audits
        {
            get { return audits; }
            set
            {
                audits = value;
                OnPropertyChanged("Audits");
            }
        }


        public void OnDownload()
        {

        }

    }
}
