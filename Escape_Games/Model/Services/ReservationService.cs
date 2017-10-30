using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_DU_2.Model.Services
{
    public interface IReservationService
    {
        List<Reservation> GetAll();
        Reservation GetById(int id);
        void Create(Reservation reservation);
    }

    public class ReservationService : IReservationService
    {
        DatabaseContext _dbContext;

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="dbContext"></param>
        public ReservationService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Vytvoreni reservace
        /// </summary>
        /// <param name="reservation"></param>
        public void Create(Reservation reservation)
        {
            _dbContext.Reservations.Add(reservation);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Vraci vsechny reservace
        /// </summary>
        /// <returns></returns>
        public List<Reservation> GetAll()
        {
            return _dbContext.Reservations.ToList();
        }

        /// <summary>
        /// Vyhleda Reservaci podle ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Reservation GetById(int id)
        {
            return _dbContext.Reservations.Single(res => res.Id == id);
        }
    }
}
