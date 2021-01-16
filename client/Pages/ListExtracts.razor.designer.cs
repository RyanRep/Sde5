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
    public partial class ListExtractsComponent : ComponentBase
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
        protected RadzenGrid<Sde5.Models.Sde.ListExtract> grid0;

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

        IEnumerable<Sde5.Models.Sde.ListExtract> _getListExtractsResult;
        protected IEnumerable<Sde5.Models.Sde.ListExtract> getListExtractsResult
        {
            get
            {
                return _getListExtractsResult;
            }
            set
            {
                if (!object.Equals(_getListExtractsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getListExtractsResult", NewValue = value, OldValue = _getListExtractsResult };
                    _getListExtractsResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getListExtractsCount;
        protected int getListExtractsCount
        {
            get
            {
                return _getListExtractsCount;
            }
            set
            {
                if (!object.Equals(_getListExtractsCount, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getListExtractsCount", NewValue = value, OldValue = _getListExtractsCount };
                    _getListExtractsCount = value;
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

        protected async System.Threading.Tasks.Task Grid0LoadData(LoadDataArgs args)
        {
            try
            {
                var sdeGetListExtractsResult = await Sde.GetListExtracts(filter:$@"{(string.IsNullOrEmpty(args.Filter)? "true" : args.Filter)}", orderby:$"{args.OrderBy}", top:args.Top, skip:args.Skip, count:args.Top != null && args.Skip != null);
                getListExtractsResult = sdeGetListExtractsResult.Value.AsODataEnumerable();

                getListExtractsCount = sdeGetListExtractsResult.Count;
            }
            catch (System.Exception sdeGetListExtractsException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to load ListExtracts" });
            }
        }
    }
}
