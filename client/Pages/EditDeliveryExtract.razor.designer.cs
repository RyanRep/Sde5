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
    public partial class EditDeliveryExtractComponent : ComponentBase
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

        [Parameter]
        public dynamic DeliveryExtractId { get; set; }

        Sde5.Models.Sde.DeliveryExtract _deliveryextract;
        protected Sde5.Models.Sde.DeliveryExtract deliveryextract
        {
            get
            {
                return _deliveryextract;
            }
            set
            {
                if (!object.Equals(_deliveryextract, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "deliveryextract", NewValue = value, OldValue = _deliveryextract };
                    _deliveryextract = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<Sde5.Models.Sde.Extract> _getExtractsForExtractIdResult;
        protected IEnumerable<Sde5.Models.Sde.Extract> getExtractsForExtractIdResult
        {
            get
            {
                return _getExtractsForExtractIdResult;
            }
            set
            {
                if (!object.Equals(_getExtractsForExtractIdResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getExtractsForExtractIdResult", NewValue = value, OldValue = _getExtractsForExtractIdResult };
                    _getExtractsForExtractIdResult = value;
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
            var sdeGetDeliveryExtractByDeliveryExtractIdResult = await Sde.GetDeliveryExtractByDeliveryExtractId(deliveryExtractId:DeliveryExtractId);
            deliveryextract = sdeGetDeliveryExtractByDeliveryExtractIdResult;

            var sdeGetExtractsResult = await Sde.GetExtracts();
            getExtractsForExtractIdResult = sdeGetExtractsResult.Value.AsODataEnumerable();
        }

        protected async System.Threading.Tasks.Task Form0Submit(Sde5.Models.Sde.DeliveryExtract args)
        {
            try
            {
                var sdeUpdateDeliveryExtractResult = await Sde.UpdateDeliveryExtract(deliveryExtractId:DeliveryExtractId, deliveryExtract:deliveryextract);
                DialogService.Close(deliveryextract);
            }
            catch (System.Exception sdeUpdateDeliveryExtractException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to update DeliveryExtract" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
