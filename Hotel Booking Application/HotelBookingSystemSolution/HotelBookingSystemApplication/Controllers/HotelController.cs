using HotelBookingSystemApplication.Interfaces;
using HotelBookingSystemApplication.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystemApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;

        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }
        [HttpPost("AddHotel")]
        public ActionResult AddHotel(HotelDTO hotelDTO)
        {
            var hotel = _hotelService.AddHotel(hotelDTO);
            if (hotel != null)
            {
                return Ok("Hotel added sucessfully");
            }
            return BadRequest("Hotel not added");
        }

        [HttpDelete("Delete hotel")]
        public ActionResult RemoveHotel(int id)
        {
            var hotel = _hotelService.DeleteHotel(id);
            if (hotel != null)
            {
                return Ok("Hotel deleted sucessfully");
            }
            return BadRequest("Invalid hotel id");
        }

        [HttpGet("Get hotel")]
        public ActionResult GetHotel()
        {
            var hotel = _hotelService.GetHotel();
            if (hotel != null)
            {
                return Ok(hotel);
            }
            return BadRequest("No hotel has added");
        }

        [HttpPost("Update hotel")]
        public ActionResult UpdateHotelDetails(int id, HotelDTO hotelDTO)
        {
            var hotel = _hotelService.UpdateHotel(id, hotelDTO);
            if(hotel != null)
            {
                return Ok(hotel);
            }
            return BadRequest("Invalid hotel id");
        }
    }
}
