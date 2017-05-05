using RopDemo.Domain;

namespace RopDemo.ApplicationService
{
    public class CustomerRepository
    {
        /// <summary>
        /// 
        /// I don't want to change this method signature / interface
        /// 
        /// </summary>
        public Customer GetCustomerById(int id)
        {
            return new Customer {Id = 1, Name = "Jon Doe"};
        }
    }
}