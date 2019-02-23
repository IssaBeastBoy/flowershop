using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerShop
{
    public class Order : IOrder, IIdentified
    {
        public List<Flower> flowers;
        private bool isDelivered = false;
        public int Id { get; }

        // should apply a 20% mark-up to each flower.
        public double Price {
            get {
                double amount = 0;
                for (int stop = 0; stop < flowers.Count; stop++)
                {
                    amount += flowers[stop].Cost + (flowers[stop].Cost * 0.2);
                }
                return amount;
            }
        }

        public double Profit {
            get {
                return 0;
            }
        }

        public IReadOnlyList<IFlower> Ordered {
            get {
                return flowers.AsReadOnly();
            }
        }

        public IClient Client { get; private set; }
        public IOrderDAO deliver;

        public Order(IOrderDAO dao, IClient client)
        {
            Id = dao.AddOrder(client);
            deliver = dao;
        }

        // used when we already have an order with an Id.
        public Order(IOrderDAO dao, IClient client, bool isDelivered = false)
        {
            this.flowers = new List<Flower>();
            this.isDelivered = isDelivered;
            Client = client;
            Id = dao.AddOrder(client);
            deliver = dao;
        }

        public void AddFlowers(Flower flower, int n)
        {
           
        }

        public void Deliver()
        {
            deliver.SetDelivered(this);
        }
    }
}
