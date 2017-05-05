using FluentAssertions;
using NSubstitute;
using RopDemo01.Domain;
using Xunit;

namespace RopDemo01.Tests
{
    public class SomeServiceTestsGetShipperTraditional
    {
        [Fact]
        public void Given_AllObjectsExist_Should_Return_Correct_Shipper_And_Log()
        {
            // Arrange
            var lastOrder = new Order
            {
                Id = 1,
                Shipper = new Shipper { Id = 42 }
            };

            var address = new Address
            {
                Id = 1,
                LastOrder = lastOrder
            };

            var customer = new Customer { Address = address };

            var repo = Substitute.For<ITraditionalRepository>();
            repo.GetCustomer(Arg.Any<int>()).Returns(customer);
            repo.GetAddress(Arg.Any<int>()).Returns(address);
            repo.GetOrder(Arg.Any<int>()).Returns(lastOrder);

            var repo2 = Substitute.For<IMonadicRepository>();
            var sut = new SomeService(repo, repo2);

            // Act
            var result = sut.GetShipperOfLastOrderOnCurrentAddress(1);
            
            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(42);
        }

        [Fact]
        public void Given_RepoReturnsNoCustomer_Should_Return_Correct_Shipper()
        {
            // Arrange
            //var lastOrder = new Order
            //{
            //    Id = 1,
            //    Shipper = new Shipper { Id = 42 }
            //};

            //var address = new Address
            //{
            //    Id = 1,
            //    LastOrder = lastOrder
            //};

            //var customer = new Customer { Address = address };

            var repo = Substitute.For<ITraditionalRepository>();
            repo.GetCustomer(Arg.Any<int>()).Returns((Customer)null);
            //repo.GetAddress(Arg.Any<int>()).Returns(address);
            //repo.GetOrder(Arg.Any<int>()).Returns(lastOrder);

            var repo2 = Substitute.For<IMonadicRepository>();
            var sut = new SomeService(repo, repo2);

            // Act
            var result = sut.GetShipperOfLastOrderOnCurrentAddress(1);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(42);
        }

    }
}