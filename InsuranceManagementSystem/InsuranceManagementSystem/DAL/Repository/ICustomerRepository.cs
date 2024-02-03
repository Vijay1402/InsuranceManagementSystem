using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface ICustomerRepository
    {
        // Create
        Customer CreateCustomer(Customer customer);
        int customerSAveChanges();

        // Read
        Customer GetCustomerByUserName(string userName);
        Customer GetCustomerByUserNamePhone(string UserName, string PhoneNumber);

        bool CustomerExistsEmail(string Email);
        
        Customer GetCustomerById(int customerId);
        IEnumerable<Customer> GetAllCustomers();
        bool CustomerExists(string userName);
        // Update
        Customer UpdateCustomer(Customer customer);
        
        // Delete
        Customer DeleteCustomer(int customerId);

        

    }
}
