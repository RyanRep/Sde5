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
    public partial class EditParameterValueComponent : ComponentBase
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
        public dynamic ParameterValueCode { get; set; }

        Sde5.Models.Sde.ParameterValue _parametervalue;
        protected Sde5.Models.Sde.ParameterValue parametervalue
        {
            get
            {
                return _parametervalue;
            }
            set
            {
                if (!object.Equals(_parametervalue, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "parametervalue", NewValue = value, OldValue = _parametervalue };
                    _parametervalue = value;
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
            var sdeGetParameterValueByParameterValueCodeResult = await Sde.GetParameterValueByParameterValueCode(parameterValueCode:$"{ParameterValueCode}");
            parametervalue = sdeGetParameterValueByParameterValueCodeResult;
        }

        protected async System.Threading.Tasks.Task Form0Submit(Sde5.Models.Sde.ParameterValue args)
        {
            try
            {
                var sdeUpdateParameterValueResult = await Sde.UpdateParameterValue(parameterValueCode:$"{ParameterValueCode}", parameterValue:parametervalue);
                DialogService.Close(parametervalue);
            }
            catch (System.Exception sdeUpdateParameterValueException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to update ParameterValue" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
