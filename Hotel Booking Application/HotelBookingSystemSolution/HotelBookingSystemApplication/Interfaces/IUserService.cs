using HotelBookingSystemApplication.Models.DTOs;

namespace HotelBookingSystemApplication.Interfaces
{
    public interface IUserService
    {
        UserLoginDTO Login (UserLoginDTO login);
        UserRegisterDTO Register (UserRegisterDTO register);
    }
}
