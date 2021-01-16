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
    public partial class DeliveryParametersComponent : ComponentBase
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
        protected RadzenGrid<Sde5.Models.Sde.DeliveryParameter> grid0;

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

        IEnumerable<Sde5.Models.Sde.DeliveryParameter> _getDeliveryParametersResult;
        protected IEnumerable<Sde5.Models.Sde.DeliveryParameter> getDeliveryParametersResult
        {
            get
            {
                return _getDeliveryParametersResult;
            }
            set
            {
                if (!object.Equals(_getDeliveryParametersResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getDeliveryParametersResult", NewValue = value, OldValue = _getDeliveryParametersResult };
                    _getDeliveryParametersResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getDeliveryParametersCount;
        protected int getDeliveryParametersCount
        {
            get
            {
                return _getDeliveryParametersCount;
            }
            set
            {
                if (!object.Equals(_getDeliveryParametersCount, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getDeliveryParametersCount", NewValue = value, OldValue = _getDeliveryParametersCount };
                    _getDeliveryParametersCount = value;
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
            var dialogResult = await DialogService.OpenAsync<AddDeliveryParameter>("Add Delivery Parameter", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid0LoadData(LoadDataArgs args)
        {
            try
            {
                var sdeGetDeliveryParametersResult = await Sde.GetDeliveryParameters(filter:$@"(contains(Value,""{search}"") or contains(ParameterValueCode,""{search}"")) and {(string.IsNullOrEmpty(args.Filter)? "true" : args.Filter)}", orderby:$"{args.OrderBy}", expand:$"DeliveryExtract,Parameter,ParameterValue", top:args.Top, skip:args.Skip, count:args.Top != null && args.Skip != null);
                getDeliveryParametersResult = sdeGetDeliveryParametersResult.Value.AsODataEnumerable();

                getDeliveryParametersCount = sdeGetDeliveryParametersResult.Count;
            }
            catch (System.Exception sdeGetDeliveryParametersException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to load DeliveryParameters" });
            }
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(Sde5.Models.Sde.DeliveryParameter args)
        {
            var dialogResult = await DialogService.OpenAsync<EditDeliveryParameter>("Edit Delivery Parameter", new Dictionary<string, object>() { {"DeliveryParameterId", args.DeliveryParameterId} });
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var sdeDeleteDeliveryParameterResult = await Sde.DeleteDeliveryParameter(deliveryParameterId:data.DeliveryParameterId);
                    if (sdeDeleteDeliveryParameterResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception sdeDeleteDeliveryParameterException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete DeliveryParameter" });
            }
        }
    }
}
