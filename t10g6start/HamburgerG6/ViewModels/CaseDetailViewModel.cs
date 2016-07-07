using HamburgerG6.Services;
using HamburgerG6.Services.SDM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Template10.Services.NavigationService;
using Windows.ApplicationModel;
using Windows.UI.Xaml.Navigation;

namespace HamburgerG6.ViewModels
{
    public class CaseDetailViewModel : ViewModelBase
    {
        #region Private members

        string id;
        string description;
        string customerId;
        string customerDescription;
        string customerOrganization;
        string status;
        string reference;
        string callback;

        HamburgerCase hamburgerCase;
        #endregion

        public CaseDetailViewModel()
        {
            if (DesignMode.DesignModeEnabled)
            {
                Id = "Case Id";
                Description = "Case Description";
                CustomerId = "Customer";
                CustomerDescription = "Customer description";
                CustomerOrganization = "Customer organzation";
                Status = "Opened";
                Reference = "Reference";
                Callback = "Callback";
            }
        }

        #region Public members

        public string Id { get { return id; } set { Set(ref id, value); } }
        public string Description { get { return description; } set { Set(ref description, value); } }
        public string CustomerId { get { return customerId; } set { Set(ref customerId, value); } }
        public string CustomerDescription { get { return customerDescription; } set { Set(ref customerDescription, value); } }
        public string CustomerOrganization { get { return customerOrganization; } set { Set(ref customerOrganization, value); } }
        public string Status { get { return status; } set { Set(ref status, value); } }
        public string Reference { get { return reference; } set { Set(ref reference, value); } }
        public string Callback { get { return callback; } set { Set(ref callback, value); } }

        #endregion

        const string suspendedStateCase = "DisplayedCase";

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
        {
            var sdmService = ServiceManager.Resolve<ISDMService>();
            hamburgerCase = (suspensionState.ContainsKey(suspendedStateCase)) ? suspensionState[suspendedStateCase] as HamburgerCase : sdmService.GetCase(parameter?.ToString());

            Id = hamburgerCase?.Id;
            Description = hamburgerCase?.Description;
            CustomerId = hamburgerCase?.CustomerId;
            CustomerDescription = hamburgerCase?.CustomerDescription;
            CustomerOrganization = hamburgerCase?.CustomerOrganization;
            Status = hamburgerCase?.Status;
            Reference = hamburgerCase?.Reference;
            Callback = hamburgerCase?.Callback;
            await Task.CompletedTask;
        }

        public override async Task OnNavigatedFromAsync(IDictionary<string, object> suspensionState, bool suspending)
        {
            if (suspending)
            {
                if (hamburgerCase == null) suspensionState.Remove(suspendedStateCase);
                else suspensionState[suspendedStateCase] = hamburgerCase;
            }
            await Task.CompletedTask;
        }

        public override async Task OnNavigatingFromAsync(NavigatingEventArgs args)
        {
            args.Cancel = false;
            await Task.CompletedTask;
        }
    }
}
