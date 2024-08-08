using LetsPollPeople.Shared.Models;
using LetsPollPeople.UI.Components;
using LetsPollPeople.UI.Swagger;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using System.Security.Claims;

namespace LetsPollPeople.UI.Pages.PageComponent
{
    public class PageComponentBase : ComponentBase
    {
        [Inject]
        protected PollApiClient? _pollApiClient {  get; set; }

        [Inject]
        protected IDialogService? _dialogService { get; set; }

        [Inject]
        protected NavigationManager? _navigationManager { get; set; }

        [Inject]
        protected AuthenticationStateProvider? _authenticationStateProvider {  get; set; }

        

        protected bool IsLoaded { get; set; } = false;

        protected UserModel? User { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            var authState = await _authenticationStateProvider!.GetAuthenticationStateAsync();
            var user = authState.User;
            User = new UserModel();

            if (user != null)
            {
                User.FirstName = user.FindFirst(ClaimTypes.Name)?.Value ?? "";
                User.LastName  = user.FindFirst(ClaimTypes.Surname)?.Value ?? "";
                User.Username  = user.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "";
            }
        }

        protected Task DisplayInformationDialog(string title, string message)
        {
            var parameters = new DialogParameters<MessageDialog>
            {
                { x => x.Title, title },
                { x => x.Content, message }
            };

            var options = new DialogOptions { CloseOnEscapeKey = true };

            return _dialogService!.ShowAsync<MessageDialog>("Simple Dialog", parameters, options);
        }
    }
}
