using HamburgerG6.Services;
using HamburgerG6.Services.SDM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.ApplicationModel;
using Windows.UI.Xaml.Navigation;

namespace HamburgerG6.ViewModels
{
    public class CaseListViewModel : ViewModelBase
    {
        #region Private members

        IList<HamburgerCase> cases;
        string selectedCaseId;

        #endregion

        public CaseListViewModel()
        {
            if (DesignMode.DesignModeEnabled)
            {
                cases = new List<HamburgerCase>();
                var hcase = new HamburgerCase
                {
                    Id = "Designtime case id",
                    Description = "Designtime case description",
                    CustomerId = "Designtime customer id",
                    CustomerDescription = "Designtime customer description",
                    CustomerOrganization = "Designtime customer organization",
                    Status = "Designtime case status",
                    Callback = "Designtime case callback",
                    Reference = "Designtime case reference",
                };
                cases.Add(hcase);
            }
        }

        internal void CaseSelected(HamburgerCase selectedCase)
        {
            NavigationService.Navigate(typeof(Views.CaseDetailPage), selectedCase.Id);
        }

        #region Public members

        public IList<HamburgerCase> Cases
        {
             get { return cases; } set { Set(ref cases, value); } 
        }

        public string SelectedCaseId
        {
            get { return selectedCaseId; }
            set { Set(ref selectedCaseId, value); }
        }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
        {
            var sdmService = ServiceManager.Resolve<ISDMService>();
            Cases = sdmService.GetCases();
            
            await Task.CompletedTask;
        }

        #endregion
    }
}
