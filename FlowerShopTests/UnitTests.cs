using NUnit.Framework;
using NSubstitute;
using FlowerShop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class Tests
    {
        public IOrderDAO _iorderDAO;
        public IClient _iclient;
        public IOrder _iorder;
        public IFlower _iflowers;
        public IFlowerDAO _iflowerDAO;

        [SetUp]
        public void Setup()
        {
            _iorderDAO=Substitute.For<IOrderDAO>();
            _iclient=Substitute.For<IClient>();
            _iorder=Substitute.For<IOrder>();
            _iflowers = Substitute.For<IFlower>();
            _iflowerDAO = Substitute.For<IFlowerDAO>();
            
        }
        
        [Test]
        public void Test1()
        {
            //Arrange
            var testing=new Order(_iorderDAO,_iclient);
            //act
            testing.Deliver();
            //assert
            Assert.AreEqual(2,_iorderDAO.ReceivedCalls().Count());
        }
        
    }
}