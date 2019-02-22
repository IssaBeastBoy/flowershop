using NUnit.Framework;
using NSubstitute;
using FlowerShop;

namespace Tests
{
    public class Tests
    {
        private IOrderDAO _iorderDAO;
        private IClient _iclient;
        private IOrder _iorder;

        [SetUp]
        public void Setup()
        {
            _iorderDAO=Substitute.For<IOrderDAO>();
            _iclient=Substitute.For<IClient>();
            _iorder=Substitute.For<IOrder>();
        }

        [Test]
        public void Test1()
        {
            //Arrange
            var testing=new Order(_iorderDAO,_iclient);
            //act
            testing.Deliver();
            //assert
            Assert.AreEqual(1,_iorderDAO.ReceivedCalls());
        }
    }
}