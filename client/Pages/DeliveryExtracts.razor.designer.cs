using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;
using Sde5.Models.Sde;
using Sde5.Client.Pages;

namespace Sde5.Pages
{
    public partial class DeliveryExtractsComponent : ComponentBase
    {
        [Parameter(CaptureUnmatchedValues = true)]
        public IReadOnlyDictionary<string, dynamic> Attributes { get; set; }

        public void Reload()
        {
            InvokeAsync(StateHasChanged);
        }

        public void OnPropertyChanged(PropertyChangedEventArgs args)
        {
        }

        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected NavigationManager UriHelper { get; set; }

        [Inject]
        protected DialogService DialogService { get; set; }

        [Inject]
        protected TooltipService TooltipService { get; set; }

        [Inject]
        protected ContextMenuService ContextMenuService { get; set; }

        [Inject]
        protected NotificationService NotificationService { get; set; }

        [Inject]
        protected SdeService Sde { get; set; }
        protected RadzenGrid<Sde5.Models.Sde.DeliveryExtract> grid0;

        string _search;
        protected string search
        {
            get
            {
                return _search;
            }
            set
            {
                if (!object.Equals(_search, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "search", NewValue = value, OldValue = _search };
                    _search = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<Sde5.Models.Sde.DeliveryExtract> _getDeliveryExtractsResult;
        protected IEnumerable<Sde5.Models.Sde.DeliveryExtract> getDeliveryExtractsResult
        {
            get
            {
                return _getDeliveryExtractsResult;
            }
            set
            {
                if (!object.Equals(_getDeliveryExtractsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getDeliveryExtractsResult", NewValue = value, OldValue = _getDeliveryExtractsResult };
                    _getDeliveryExtractsResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getDeliveryExtractsCount;
        protected int getDeliveryExtractsCount
        {
            get
            {
                return _getDeliveryExtractsCount;
            }
            set
            {
                if (!object.Equals(_getDeliveryExtractsCount, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getDeliveryExtractsCount", NewValue = value, OldValue = _getDeliveryExtractsCount };
                    _getDeliveryExtractsCount = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            await Load();
        }
        protected async System.Threading.Tasks.Task Load()
        {
            if (string.IsNullOrEmpty(search)) {
                search = "";
            }
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddDeliveryExtract>("Add Delivery Extract", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid0LoadData(LoadDataArgs args)
        {
            try
            {
                var sdeGetDeliveryExtractsResult = await Sde.GetDeliveryExtracts(filter:$@"(contains(Name,""{search}"") or contains(Description,""{search}"")) and {(string.IsNullOrEmpty(args.Filter)? "true" : args.Filter)}", orderby:$"{args.OrderBy}", expand:$"Extract", top:args.Top, skip:args.Skip, count:args.Top != null && args.Skip != null);
                getDeliveryExtractsResult = sdeGetDeliveryExtractsResult.Value.AsODataEnumerable();

                getDeliveryExtractsCount = sdeGetDeliveryExtractsResult.Count;
            }
            catch (System.Exception sdeGetDeliveryExtractsException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to load DeliveryExtracts" });
            }
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(Sde5.Models.Sde.DeliveryExtract args)
        {
            var dialogResult = await DialogService.OpenAsync<EditDeliveryExtract>("Edit Delivery Extract", new Dictionary<string, object>() { {"DeliveryExtractId", args.DeliveryExtractId} });
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var sdeDeleteDeliveryExtractResult = await Sde.DeleteDeliveryExtract(deliveryExtractId:data.DeliveryExtractId);
                    if (sdeDeleteDeliveryExtractResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception sdeDeleteDeliveryExtractException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete DeliveryExtract" });
            }
        }
    }
}
