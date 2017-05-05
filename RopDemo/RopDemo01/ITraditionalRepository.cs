using RopDemo01.Domain;

namespace RopDemo01
{
    public interface ITraditionalRepository
    {
        Customer GetCustomer(int id);
        Address GetAddress(int id);
        Order GetOrder(int id);
    }
}