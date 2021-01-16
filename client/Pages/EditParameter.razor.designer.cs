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
    public partial class EditParameterComponent : ComponentBase
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
        public dynamic ParameterId { get; set; }

        Sde5.Models.Sde.Parameter _parameter;
        protected Sde5.Models.Sde.Parameter parameter
        {
            get
            {
                return _parameter;
            }
            set
            {
                if (!object.Equals(_parameter, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "parameter", NewValue = value, OldValue = _parameter };
                    _parameter = value;
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
            var sdeGetParameterByParameterIdResult = await Sde.GetParameterByParameterId(parameterId:ParameterId);
            parameter = sdeGetParameterByParameterIdResult;

            var sdeGetExtractsResult = await Sde.GetExtracts();
            getExtractsForExtractIdResult = sdeGetExtractsResult.Value.AsODataEnumerable();
        }

        protected async System.Threading.Tasks.Task Form0Submit(Sde5.Models.Sde.Parameter args)
        {
            try
            {
                var sdeUpdateParameterResult = await Sde.UpdateParameter(parameterId:ParameterId, parameter:parameter);
                DialogService.Close(parameter);
            }
            catch (System.Exception sdeUpdateParameterException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to update Parameter" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
