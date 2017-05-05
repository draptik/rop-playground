using RopDemo01.Domain;

namespace RopDemo01
{
    public interface IMonadicRepository
    {
        Maybe<Customer> GetCustomer(int id);
        Maybe<Address> GetAddress(int id);
        Maybe<Order> GetOrder(int id);
    }
}