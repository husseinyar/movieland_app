using ETickets.ModelView;

namespace ETickets.Services.UserServic
{
    public interface IUserAuthentication
    {
        Task<Status> LoginAsync(LoginModel model);
        Task<Status> RegiseringAsync(RegistrationModel model);
        Task LogoutAsync();

    }
}
