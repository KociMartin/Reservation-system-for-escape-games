using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_DU_2.Model.Services
{
    public interface ICustomerService
    {
        List<Customer> GetAll();
        Customer GetById(int id);
        void Create(Customer customer);
    }

    public class CustomerService : ICustomerService
    {
        DatabaseContext _dbContext;

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="dbContext"></param>
        public CustomerService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Vytvareni Customera
        /// </summary>
        /// <param name="customer"></param>
        public void Create(Customer customer)
        {
            _dbContext.Add(customer);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Vraceni vsech Customeru
        /// </summary>
        /// <returns></returns>
        public List<Customer> GetAll()
        {
            return _dbContext.Customers.ToList();
        }

        /// <summary>
        /// Vyhledani Customera podle ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Customer GetById(int id)
        {
            return _dbContext.Customers.Single(cust => cust.Id == id);
        }
    }
}
