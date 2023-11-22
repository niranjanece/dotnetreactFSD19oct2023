using HotelBookingSystemApplication.Models.DTOs;

namespace HotelBookingSystemApplication.Interfaces
{
    public interface ITokenService
    {
        string GetToken(UserLoginDTO user);
    }
}
