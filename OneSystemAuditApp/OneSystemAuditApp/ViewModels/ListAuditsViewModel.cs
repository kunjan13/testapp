using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using AuditAppPcl.Entities;
using Xamarin.Forms;
using System.Linq;
using System.Collections.Generic;

namespace AuditAppPcl
{
    public class ListAuditsViewModel : BaseViewModel
    {
        private string caseNumber;
        private string applicantName;
        private string selectedInspectionStatus;
        private string inspector;
        ObservableCollection<Audit> audits;
        ObservableCollection<Audit> serverAudits;
        ObservableCollection<string> inspectionStatuses;

        private string inspectionDateSortImage = "ic_sort";
        private string inspectionStatusSortImage = "ic_sort";

        public ICommand SearchCommand { protected set; get; }

        public ICommand SortCommand { protected set; get; }

        public ICommand ClearSearchCommand { protected set; get; }

        public ListAuditsViewModel()
        {
            var myAudits = GetAudits();
            Audits = new ObservableCollection<Audit>(myAudits);
            InspectionStatuses = new ObservableCollection<string>() { "", "data1", "data2", "data3" };
            ServerAudits = Audits;
            SearchCommand = new Command(OnSearch);
            ClearSearchCommand = new Command(OnClearSearch);
            SortCommand = new Command<string>(SortData);
        }

        public async void SortData(string columnName)
        {
            var action = await Application.Current.MainPage.DisplayActionSheet("Select Sort Order for Audit Date", "Cancel", null, "Sort Ascending", "Sort Descending");
            if (action == "Sort Ascending" && columnName == "InspectionDate")
            {
                Audits = new ObservableCollection<Audit>(Audits.OrderBy(x => x.InspectionDate).ToList());
                InspectionDateSortImage = "ic_sort_ASC";
            }
            if (action == "Sort Descending" && columnName == "InspectionDate")
            {
                Audits = new ObservableCollection<Audit>(Audits.OrderByDescending(x => x.InspectionDate).ToList());
                InspectionDateSortImage = "ic_sort";
            }
            if (action == "Sort Ascending" && columnName == "InspectionStatus")
            {
                Audits = new ObservableCollection<Audit>(Audits.OrderBy(x => x.InspectionStatus).ToList());
                InspectionStatusSortImage = "ic_sort_ASC";
            }
            if (action == "Sort Descending" && columnName == "InspectionStatus")
            {
                Audits = new ObservableCollection<Audit>(Audits.OrderByDescending(x => x.InspectionStatus).ToList());
                InspectionStatusSortImage = "ic_sort";
            }
        }

        private void OnClearSearch()
        {
            throw new NotImplementedException();
        }

        private void OnSearch()
        {
            var myAudits = GetAudits();
            var searchAuditList = new ObservableCollection<Audit>(myAudits);
            IEnumerable<Audit> filteredAudits = searchAuditList;
            if (!string.IsNullOrEmpty(caseNumber))
            {
                filteredAudits = filteredAudits.Where(x => x.ParentID.Contains(caseNumber));
            }
            if (!string.IsNullOrEmpty(selectedInspectionStatus))
            {
                filteredAudits = filteredAudits.Where(x => x.InspectionStatus == selectedInspectionStatus);
            }
            if (!string.IsNullOrEmpty(ApplicantName))
            {
                filteredAudits = filteredAudits.Where(x => x.ApplicantName.Contains(ApplicantName));
            }
            if (!string.IsNullOrEmpty(Inspector))
            {
                filteredAudits = filteredAudits.Where(x => x.Inspector.Contains(Inspector));
            }

            this.Audits = new ObservableCollection<Audit>(filteredAudits.ToList());
        }

        public ObservableCollection<Audit> Audits
        {
            get { return audits; }
            set
            {
                audits = value;
                OnPropertyChanged(nameof(Audits));
            }
        }

        public string CaseNumber
        {
            get
            {
                return caseNumber;
            }

            set
            {
                caseNumber = value;
                OnPropertyChanged("CaseNumber");
            }
        }

        public string ApplicantName
        {
            get
            {
                return applicantName;
            }

            set
            {
                applicantName = value;
                OnPropertyChanged("ApplicantName");
            }
        }

        public string SelectedInspectionStatus
        {
            get
            {
                return selectedInspectionStatus;
            }

            set
            {
                selectedInspectionStatus = value;
                OnPropertyChanged("SelectedInspectionStatus");
            }
        }

        public string Inspector
        {
            get
            {
                return inspector;
            }

            set
            {
                inspector = value;
                OnPropertyChanged("Inspector");
            }
        }

        public ObservableCollection<string> InspectionStatuses
        {
            get
            {
                return inspectionStatuses;
            }

            set
            {
                inspectionStatuses = value;
                OnPropertyChanged("InspectionStatuses");
            }
        }

        public ObservableCollection<Audit> ServerAudits
        {
            get
            {
                return serverAudits;
            }

            set
            {
                serverAudits = value;
            }
        }

        public string InspectionDateSortImage
        {
            get
            {
                return inspectionDateSortImage;
            }

            set
            {
                inspectionDateSortImage = value;
                OnPropertyChanged("InspectionDateSortImage");
            }
        }

        public string InspectionStatusSortImage
        {
            get
            {
                return inspectionStatusSortImage;
            }

            set
            {
                inspectionStatusSortImage = value;
                OnPropertyChanged("InspectionStatusSortImage");
            }
        }

        private List<Audit> GetAudits()
        {
            var audits = new List<Audit>();
            audits.Add(new Audit() { ApplicantName = "Jignesh", InspectionDate = DateTime.Now, DisplayInspectionDate = DateTime.Now.ToString("dd.mm.yyy"), ItemID = "12312", InspectionStatus = "Assign to self", InspectionType = "Assign to self", ParentID = "123456" });
            audits.Add(new Audit() { ApplicantName = "Kunjan", InspectionDate = DateTime.Now.AddDays(-1), DisplayInspectionDate = DateTime.Now.AddDays(-1).ToString("dd.mm.yyy"), ItemID = "12312", InspectionStatus = "Assign to self", InspectionType = "Assign to self", ParentID = "468469" });
            audits.Add(new Audit() { ApplicantName = "Suresh", ItemID = "12312", InspectionDate = DateTime.Now, DisplayInspectionDate = DateTime.Now.ToString("dd.mm.yyy"), InspectionStatus = "Assign to self", InspectionType = "Assign to self", ParentID = "585256" });
            audits.Add(new Audit() { ApplicantName = "Kaushal", ItemID = "12312", InspectionDate = DateTime.Now.AddDays(-4), DisplayInspectionDate = DateTime.Now.AddDays(-4).ToString("dd.mm.yyy"), InspectionStatus = "Assign to self", InspectionType = "Assign to self", ParentID = "87982" });
            audits.Add(new Audit() { ApplicantName = "Sampra", ItemID = "12312", InspectionDate = DateTime.Now.AddDays(-10), DisplayInspectionDate = DateTime.Now.AddDays(-10).ToString("dd.mm.yyy"), InspectionStatus = "Assign to self", InspectionType = "Assign to self", ParentID = "68469" });
            return audits.OrderByDescending(x => x.InspectionDate).ToList();
            //return Task.Run(async () => await auditServiceManager.GetAudits()).Result;
        }

    }
}
