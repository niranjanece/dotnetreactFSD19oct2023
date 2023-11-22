using HotelBookingSystemApplication.Interfaces;
using HotelBookingSystemApplication.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystemApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }
        [HttpPost("AddRoom")]
        public ActionResult AddRoom(RoomDTO roomDTO)
        {
            var room = _roomService.AddRoom(roomDTO);
            if(room != null)
            {
                return Ok("Room added sucessfully");
            }
            return BadRequest("Rooms not added");
        }

        [HttpDelete("DeleteRoom")]
        public ActionResult DeleteRoom(int id)
        {
            bool room = _roomService.RemoveRoom(id);
            if(room != false)
            {
                return Ok("Room deleted sucessfully");
            }
            return BadRequest("Invalid room id");
        }

        [HttpGet("GetRoom")]
        public ActionResult GetRoom(int hotelid)
        {
            var room = _roomService.GetRoom(hotelid);
            if(room != null)
            {
                return Ok(room);
            }
            return BadRequest("No rooms to display");
        }

        [HttpPost("UpdateRoom")]
        public ActionResult UpdateRoom(int Roomid,RoomDTO roomDTO)
        {
            var room = _roomService.UpdateRoom(Roomid,roomDTO);
            if(room != null )
            {
                return Ok("Updated sucessfully");
            }
            return BadRequest("Update is failed");
        }
    }
}
