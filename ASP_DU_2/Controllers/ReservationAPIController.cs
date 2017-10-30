using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASP_DU_2.Model;
using ASP_DU_2.Model.Services;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP_DU_2.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ReservationAPIController : Controller
    {
        IReservationService _reservationService;
        IRoomService _roomService;

        public ReservationAPIController(IReservationService reservation, IRoomService rooms)
        {
            _reservationService = reservation;
            _roomService = rooms;
        }

        /// <summary>
        /// Vrati Room podle Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [Route("GetRoom/{Id}")]
        [HttpGet]
        public Room GetRoom(int Id)
        {
            return _roomService.GetById(Id);
        }

        /// <summary>
        /// Vrati seznamu roomu a jejich volnejch hodin
        /// </summary>
        /// <param name="Date"></param>
        /// <returns></returns>
        [Route("GetRooms/{Date}")]
        [HttpGet]
        public List<RoomAPIView> GetRooms(string Date)
        {
            DateTime ParsedDate = DateTime.Parse(Date);
            return _roomService.GetRoomsFreeHours(ParsedDate);

        }

        /// <summary>
        /// Testovaci metoda
        /// </summary>
        /// <returns></returns>
        //[Route("neco/{args?}")]
        //[HttpGet]
        //public string neco()
        //{
        //    return "Neco";
        //}
    }
}
