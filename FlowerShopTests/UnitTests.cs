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

        //unedited price file
        [Test]
        public void Test2()
        {
            //Arrange
            var testing = new Order(_iorderDAO, _iclient, true);
            //act

            //assert
            Assert.AreEqual(0, testing.Price);
        }
        [Test]
        public void Test3()
        {

            //Arrange
            Flower adding = new Flower(_iflowerDAO, "Roses", 100, 10);
            var testing = new Order(_iorderDAO, _iclient, true);
            //act
            testing.AddFlowers(adding, 1);
            Console.WriteLine(testing.flowers[0]);


            //assert
            Assert.AreEqual(120, testing.Price);

        }
    }
}