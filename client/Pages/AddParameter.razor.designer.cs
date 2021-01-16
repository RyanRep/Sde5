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
    public partial class AddParameterComponent : ComponentBase
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

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            await Load();
        }
        protected async System.Threading.Tasks.Task Load()
        {
            var sdeGetExtractsResult = await Sde.GetExtracts();
            getExtractsForExtractIdResult = sdeGetExtractsResult.Value.AsODataEnumerable();

            parameter = new Sde5.Models.Sde.Parameter(){};
        }

        protected async System.Threading.Tasks.Task Form0Submit(Sde5.Models.Sde.Parameter args)
        {
            try
            {
                var sdeCreateParameterResult = await Sde.CreateParameter(parameter:parameter);
                DialogService.Close(parameter);
            }
            catch (System.Exception sdeCreateParameterException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to create new Parameter!" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
