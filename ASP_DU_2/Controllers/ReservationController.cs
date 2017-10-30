using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_DU_2.Model.Services;
using ASP_DU_2.Model;

namespace ASP_DU_2.Controllers
{
    public class ReservationController : Controller
    {
        IReservationService _reservationService;
        IRoomService _roomService;
        ICustomerService _customerService;


        public ReservationController(IReservationService reservation, IRoomService rooms ,ICustomerService customer)
        {
            _reservationService = reservation;
            _roomService = rooms;
            _customerService = customer;
        }

        /// <summary>
        /// Akce Indexu
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View(_roomService.GetAll());
        }

        /// <summary>
        /// Akce Zobrazeni detailu Reservace
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public IActionResult ReservationDetail(int id)
        {
            Room selectedRoom;

            try
            {
                selectedRoom = _roomService.GetById(id);
            }
            catch (InvalidOperationException)
            {
                return NotFound(new { Message = "Detail of Room not found" });
            }

            return View(new ModelKeeper() { room = selectedRoom });
        }

        /// <summary>
        /// Poslani dat detailu Rezervace na view zalozeni rezervace
        /// </summary>
        /// <param name="DataFromReservationDetail"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult ReservationDetail(ModelKeeper DataFromReservationDetail)
        {
            Room selectedRoom = _roomService.GetById(DataFromReservationDetail.room.Id);
            DataFromReservationDetail.room = selectedRoom;
            return View("ReservationCreate", DataFromReservationDetail);
        }

        /// <summary>
        /// Ulozeni dat do databze a presmerovani na Index
        /// </summary>
        /// <param name="DataFromReservationCreate"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult ReservationCreate(ModelKeeper DataFromReservationCreate)
        {
            //ulozeni zakaznika do DB
            _customerService.Create(DataFromReservationCreate.customer);
            //Priradim Customera Reservaci
            DataFromReservationCreate.reservation.CurrentCustomer = DataFromReservationCreate.customer;
            //Priradim Room Reservaci
            DataFromReservationCreate.reservation.CurrentRoom = _roomService.GetById(DataFromReservationCreate.room.Id);
            //Vytvorim Reservaci v DB
            _reservationService.Create(DataFromReservationCreate.reservation);
            //Priradim Reservace Roomu
            DataFromReservationCreate.room.Reservations.Add(DataFromReservationCreate.reservation);
            return RedirectToAction("Index"); 
        }
    }
}
