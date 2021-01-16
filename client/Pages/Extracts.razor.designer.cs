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
    public partial class ExtractsComponent : ComponentBase
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
        protected RadzenGrid<Sde5.Models.Sde.Extract> grid0;

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

        IEnumerable<Sde5.Models.Sde.Extract> _getExtractsResult;
        protected IEnumerable<Sde5.Models.Sde.Extract> getExtractsResult
        {
            get
            {
                return _getExtractsResult;
            }
            set
            {
                if (!object.Equals(_getExtractsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getExtractsResult", NewValue = value, OldValue = _getExtractsResult };
                    _getExtractsResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getExtractsCount;
        protected int getExtractsCount
        {
            get
            {
                return _getExtractsCount;
            }
            set
            {
                if (!object.Equals(_getExtractsCount, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getExtractsCount", NewValue = value, OldValue = _getExtractsCount };
                    _getExtractsCount = value;
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
            var dialogResult = await DialogService.OpenAsync<AddExtract>("Add Extract", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid0LoadData(LoadDataArgs args)
        {
            try
            {
                var sdeGetExtractsResult = await Sde.GetExtracts(filter:$@"(contains(Name,""{search}"") or contains(Description,""{search}"") or contains(ExternalCode,""{search}"")) and {(string.IsNullOrEmpty(args.Filter)? "true" : args.Filter)}", orderby:$"{args.OrderBy}", top:args.Top, skip:args.Skip, count:args.Top != null && args.Skip != null);
                getExtractsResult = sdeGetExtractsResult.Value.AsODataEnumerable();

                getExtractsCount = sdeGetExtractsResult.Count;
            }
            catch (System.Exception sdeGetExtractsException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to load Extracts" });
            }
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(Sde5.Models.Sde.Extract args)
        {
            var dialogResult = await DialogService.OpenAsync<EditExtract>("Edit Extract", new Dictionary<string, object>() { {"ExtractId", args.ExtractId} });
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var sdeDeleteExtractResult = await Sde.DeleteExtract(extractId:data.ExtractId);
                    if (sdeDeleteExtractResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception sdeDeleteExtractException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete Extract" });
            }
        }
    }
}
