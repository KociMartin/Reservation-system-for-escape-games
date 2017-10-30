using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_DU_2.Model.Services
{
    public interface IRoomService
    {
        List<Room> GetAll();
        Room GetById(int id);
        List<RoomAPIView> GetRoomsFreeHours(DateTime Date);
    }


    public class RoomService : IRoomService
    {
        DatabaseContext _dbContext;

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="dbContext"></param>
        public RoomService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Vraci vsechny Roomy
        /// </summary>
        /// <returns></returns>
        public List<Room> GetAll()
        {
            return _dbContext.Rooms.ToList();
        }

        /// <summary>
        /// Vyhleda Room podle Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Room GetById(int id)
        {
            var promena = _dbContext.Rooms.Single(room => room.Id == id);
            return promena;
        }

        /// <summary>
        /// K mistnostem pridam volny hodiny pomoci tridy. pro API
        /// </summary>
        /// <param name="Date"></param>
        /// <returns></returns>
        public List<RoomAPIView> GetRoomsFreeHours(DateTime Date)
        {
            List<RoomAPIView> FreeHoursList = new List<RoomAPIView>();
            foreach (var room in _dbContext.Rooms)
            {
                FreeHoursList.Add(new RoomAPIView()
                {
                    Room = room,
                    FreeHours = room.OpeningHoursNumbers().Except(room.OccupiedOpeningHours(Date.Date)).ToList()
                });
            }
            return FreeHoursList;
        }

    }
}
