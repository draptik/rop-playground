using RopDemo.Domain;

namespace RopDemo.ApplicationService
{
    public class AppLogic
    {
        private readonly CustomerRepository _customerRepository;
        private readonly MailService _mailService;

        public AppLogic()
        {
            // Replace by ctor injection
            _customerRepository = new CustomerRepository();
            _mailService = new MailService();
        }

        public void ChangeCustomer(Customer customer)
        {
            var customerById = _customerRepository.GetCustomerById(customer.Id);
            _mailService.Send(customerById); // void, but can throw exception
        }
    }
}