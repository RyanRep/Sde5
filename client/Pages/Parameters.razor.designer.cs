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
    public partial class ParametersComponent : ComponentBase
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
        protected RadzenGrid<Sde5.Models.Sde.Parameter> grid0;

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

        IEnumerable<Sde5.Models.Sde.Parameter> _getParametersResult;
        protected IEnumerable<Sde5.Models.Sde.Parameter> getParametersResult
        {
            get
            {
                return _getParametersResult;
            }
            set
            {
                if (!object.Equals(_getParametersResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getParametersResult", NewValue = value, OldValue = _getParametersResult };
                    _getParametersResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getParametersCount;
        protected int getParametersCount
        {
            get
            {
                return _getParametersCount;
            }
            set
            {
                if (!object.Equals(_getParametersCount, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getParametersCount", NewValue = value, OldValue = _getParametersCount };
                    _getParametersCount = value;
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
            var dialogResult = await DialogService.OpenAsync<AddParameter>("Add Parameter", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid0LoadData(LoadDataArgs args)
        {
            try
            {
                var sdeGetParametersResult = await Sde.GetParameters(filter:$@"(contains(Name,""{search}"") or contains(Alias,""{search}"") or contains(Description,""{search}"")) and {(string.IsNullOrEmpty(args.Filter)? "true" : args.Filter)}", orderby:$"{args.OrderBy}", expand:$"Extract", top:args.Top, skip:args.Skip, count:args.Top != null && args.Skip != null);
                getParametersResult = sdeGetParametersResult.Value.AsODataEnumerable();

                getParametersCount = sdeGetParametersResult.Count;
            }
            catch (System.Exception sdeGetParametersException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to load Parameters" });
            }
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(Sde5.Models.Sde.Parameter args)
        {
            var dialogResult = await DialogService.OpenAsync<EditParameter>("Edit Parameter", new Dictionary<string, object>() { {"ParameterId", args.ParameterId} });
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var sdeDeleteParameterResult = await Sde.DeleteParameter(parameterId:data.ParameterId);
                    if (sdeDeleteParameterResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception sdeDeleteParameterException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete Parameter" });
            }
        }
    }
}
