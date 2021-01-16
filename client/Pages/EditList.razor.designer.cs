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
    public partial class EditListComponent : ComponentBase
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
        public dynamic ListId { get; set; }

        Sde5.Models.Sde.List _list;
        protected Sde5.Models.Sde.List list
        {
            get
            {
                return _list;
            }
            set
            {
                if (!object.Equals(_list, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "list", NewValue = value, OldValue = _list };
                    _list = value;
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
            var sdeGetListByListIdResult = await Sde.GetListByListId(listId:ListId);
            list = sdeGetListByListIdResult;
        }

        protected async System.Threading.Tasks.Task Form0Submit(Sde5.Models.Sde.List args)
        {
            try
            {
                var sdeUpdateListResult = await Sde.UpdateList(listId:ListId, list:list);
                DialogService.Close(list);
            }
            catch (System.Exception sdeUpdateListException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to update List" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
