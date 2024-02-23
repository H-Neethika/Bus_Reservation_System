using Bus_Reservation_System.Models.DTO;

namespace Bus_Reservation_System.Repositories.Abstract
{
    public interface IUserAuthenticationService
    {
        Task<Status> LoginAsync(LoginModel model);
        Task LogoutAsync();
        Task<Status> RegisterAsync(RegistrationModel model);
       
    }
}
