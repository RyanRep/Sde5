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
    public partial class ParameterValuesComponent : ComponentBase
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
        protected RadzenGrid<Sde5.Models.Sde.ParameterValue> grid0;

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

        IEnumerable<Sde5.Models.Sde.ParameterValue> _getParameterValuesResult;
        protected IEnumerable<Sde5.Models.Sde.ParameterValue> getParameterValuesResult
        {
            get
            {
                return _getParameterValuesResult;
            }
            set
            {
                if (!object.Equals(_getParameterValuesResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getParameterValuesResult", NewValue = value, OldValue = _getParameterValuesResult };
                    _getParameterValuesResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getParameterValuesCount;
        protected int getParameterValuesCount
        {
            get
            {
                return _getParameterValuesCount;
            }
            set
            {
                if (!object.Equals(_getParameterValuesCount, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getParameterValuesCount", NewValue = value, OldValue = _getParameterValuesCount };
                    _getParameterValuesCount = value;
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
            var dialogResult = await DialogService.OpenAsync<AddParameterValue>("Add Parameter Value", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid0LoadData(LoadDataArgs args)
        {
            try
            {
                var sdeGetParameterValuesResult = await Sde.GetParameterValues(filter:$@"(contains(ParameterValueCode,""{search}"") or contains(name,""{search}"") or contains(Description,""{search}"")) and {(string.IsNullOrEmpty(args.Filter)? "true" : args.Filter)}", orderby:$"{args.OrderBy}", top:args.Top, skip:args.Skip, count:args.Top != null && args.Skip != null);
                getParameterValuesResult = sdeGetParameterValuesResult.Value.AsODataEnumerable();

                getParameterValuesCount = sdeGetParameterValuesResult.Count;
            }
            catch (System.Exception sdeGetParameterValuesException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to load ParameterValues" });
            }
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(Sde5.Models.Sde.ParameterValue args)
        {
            var dialogResult = await DialogService.OpenAsync<EditParameterValue>("Edit Parameter Value", new Dictionary<string, object>() { {"ParameterValueCode", args.ParameterValueCode} });
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var sdeDeleteParameterValueResult = await Sde.DeleteParameterValue(parameterValueCode:$"{data.ParameterValueCode}");
                    if (sdeDeleteParameterValueResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception sdeDeleteParameterValueException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete ParameterValue" });
            }
        }
    }
}
