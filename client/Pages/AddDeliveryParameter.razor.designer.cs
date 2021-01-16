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
    public partial class AddDeliveryParameterComponent : ComponentBase
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

        IEnumerable<Sde5.Models.Sde.DeliveryExtract> _getDeliveryExtractsForDeliveryExtractIdResult;
        protected IEnumerable<Sde5.Models.Sde.DeliveryExtract> getDeliveryExtractsForDeliveryExtractIdResult
        {
            get
            {
                return _getDeliveryExtractsForDeliveryExtractIdResult;
            }
            set
            {
                if (!object.Equals(_getDeliveryExtractsForDeliveryExtractIdResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getDeliveryExtractsForDeliveryExtractIdResult", NewValue = value, OldValue = _getDeliveryExtractsForDeliveryExtractIdResult };
                    _getDeliveryExtractsForDeliveryExtractIdResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<Sde5.Models.Sde.Parameter> _getParametersForParameterIdResult;
        protected IEnumerable<Sde5.Models.Sde.Parameter> getParametersForParameterIdResult
        {
            get
            {
                return _getParametersForParameterIdResult;
            }
            set
            {
                if (!object.Equals(_getParametersForParameterIdResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getParametersForParameterIdResult", NewValue = value, OldValue = _getParametersForParameterIdResult };
                    _getParametersForParameterIdResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<Sde5.Models.Sde.ParameterValue> _getParameterValuesForParameterValueCodeResult;
        protected IEnumerable<Sde5.Models.Sde.ParameterValue> getParameterValuesForParameterValueCodeResult
        {
            get
            {
                return _getParameterValuesForParameterValueCodeResult;
            }
            set
            {
                if (!object.Equals(_getParameterValuesForParameterValueCodeResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getParameterValuesForParameterValueCodeResult", NewValue = value, OldValue = _getParameterValuesForParameterValueCodeResult };
                    _getParameterValuesForParameterValueCodeResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        Sde5.Models.Sde.DeliveryParameter _deliveryparameter;
        protected Sde5.Models.Sde.DeliveryParameter deliveryparameter
        {
            get
            {
                return _deliveryparameter;
            }
            set
            {
                if (!object.Equals(_deliveryparameter, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "deliveryparameter", NewValue = value, OldValue = _deliveryparameter };
                    _deliveryparameter = value;
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
            var sdeGetDeliveryExtractsResult = await Sde.GetDeliveryExtracts();
            getDeliveryExtractsForDeliveryExtractIdResult = sdeGetDeliveryExtractsResult.Value.AsODataEnumerable();

            var sdeGetParametersResult = await Sde.GetParameters();
            getParametersForParameterIdResult = sdeGetParametersResult.Value.AsODataEnumerable();

            var sdeGetParameterValuesResult = await Sde.GetParameterValues();
            getParameterValuesForParameterValueCodeResult = sdeGetParameterValuesResult.Value.AsODataEnumerable();

            deliveryparameter = new Sde5.Models.Sde.DeliveryParameter(){};
        }

        protected async System.Threading.Tasks.Task Form0Submit(Sde5.Models.Sde.DeliveryParameter args)
        {
            try
            {
                var sdeCreateDeliveryParameterResult = await Sde.CreateDeliveryParameter(deliveryParameter:deliveryparameter);
                DialogService.Close(deliveryparameter);
            }
            catch (System.Exception sdeCreateDeliveryParameterException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to create new DeliveryParameter!" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
