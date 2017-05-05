using RopDemo01.Domain;

namespace RopDemo01
{
    public class SomeService
    {
        private readonly ITraditionalRepository _repo;
        private readonly IMonadicRepository _repo2;

        public SomeService(ITraditionalRepository repo, IMonadicRepository repo2)
        {
            _repo = repo;
            _repo2 = repo2;
        }

        public Shipper GetShipperOfLastOrderOnCurrentAddress(int customerId)
        {
            Shipper shipperOfLastOrderOnCurrentAddress = null;
            var customer = _repo.GetCustomer(customerId);
            if (customer?.Address != null)
            {
                var address = _repo.GetAddress(customer.Address.Id);
                if (address?.LastOrder != null)
                {
                    var order = _repo.GetOrder(address.LastOrder.Id);
                    shipperOfLastOrderOnCurrentAddress = order?.Shipper;

                }
            }
            return shipperOfLastOrderOnCurrentAddress;
        }

        public Maybe<Shipper> GetMaybeShipperOfLastOrderOnCurrentAddress(int customerId)
        {
            Maybe<Shipper> shipperOfLastOrderOnCurrentAddress =
                _repo2.GetCustomer(customerId)
                    .Bind(c => c.Address.Return())
                    .Bind(a => _repo2.GetAddress(a.Id))
                    .Bind(a => a.LastOrder.Return())
                    .Bind(lo => _repo2.GetOrder(lo.Id))
                    .Bind(o => o.Shipper.Return());

            return shipperOfLastOrderOnCurrentAddress;
        }
    }
}