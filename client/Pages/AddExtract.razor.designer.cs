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
    public partial class AddExtractComponent : ComponentBase
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

        Sde5.Models.Sde.Extract _extract;
        protected Sde5.Models.Sde.Extract extract
        {
            get
            {
                return _extract;
            }
            set
            {
                if (!object.Equals(_extract, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "extract", NewValue = value, OldValue = _extract };
                    _extract = value;
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
            extract = new Sde5.Models.Sde.Extract(){};
        }

        protected async System.Threading.Tasks.Task Form0Submit(Sde5.Models.Sde.Extract args)
        {
            try
            {
                var sdeCreateExtractResult = await Sde.CreateExtract(extract:extract);
                DialogService.Close(extract);
            }
            catch (System.Exception sdeCreateExtractException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to create new Extract!" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
