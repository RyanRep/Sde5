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
    public partial class ListsComponent : ComponentBase
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
        protected RadzenGrid<Sde5.Models.Sde.List> grid0;

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

        IEnumerable<Sde5.Models.Sde.List> _getListsResult;
        protected IEnumerable<Sde5.Models.Sde.List> getListsResult
        {
            get
            {
                return _getListsResult;
            }
            set
            {
                if (!object.Equals(_getListsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getListsResult", NewValue = value, OldValue = _getListsResult };
                    _getListsResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getListsCount;
        protected int getListsCount
        {
            get
            {
                return _getListsCount;
            }
            set
            {
                if (!object.Equals(_getListsCount, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getListsCount", NewValue = value, OldValue = _getListsCount };
                    _getListsCount = value;
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
            var dialogResult = await DialogService.OpenAsync<AddList>("Add List", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid0LoadData(LoadDataArgs args)
        {
            try
            {
                var sdeGetListsResult = await Sde.GetLists(filter:$@"(contains(Name,""{search}"")) and {(string.IsNullOrEmpty(args.Filter)? "true" : args.Filter)}", orderby:$"{args.OrderBy}", top:args.Top, skip:args.Skip, count:args.Top != null && args.Skip != null);
                getListsResult = sdeGetListsResult.Value.AsODataEnumerable();

                getListsCount = sdeGetListsResult.Count;
            }
            catch (System.Exception sdeGetListsException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to load Lists" });
            }
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(Sde5.Models.Sde.List args)
        {
            var dialogResult = await DialogService.OpenAsync<EditList>("Edit List", new Dictionary<string, object>() { {"ListId", args.ListId} });
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var sdeDeleteListResult = await Sde.DeleteList(listId:data.ListId);
                    if (sdeDeleteListResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception sdeDeleteListException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete List" });
            }
        }
    }
}
