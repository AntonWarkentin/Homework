using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_10
{
    public class AvgHousingPriceMonitor
    {
        private Random random = new Random();
        private const int minAvgPrice = 500;
        private const int maxAvgPrice = 5000;
        private const int priceToNotify = 1000;

        private int avgHousingPrice;
        public int AvgHousingPrice 
        {
            get { return avgHousingPrice; } 
            set
            {
                if (value < priceToNotify)
                {
                    if (Subscribers.Count > 0)
                    {
                        NotifyAllSubscribers(value);
                    }
                    else AffordablePriceEvent?.Invoke(value);
                }
                avgHousingPrice = value;
            }
        }

        public delegate void dlgAction(int x);
        public dlgAction ShowPrice { get; set; }
        public event dlgAction AffordablePriceEvent;

        public List<User> Subscribers { get; set; }


        public AvgHousingPriceMonitor(dlgAction priceShowing)
        {
            GenerateRandomAvgPrice();
            ShowPrice = priceShowing;
            Subscribers = new List<User>();
        }

        public void GenerateRandomAvgPrice()
        {
            AvgHousingPrice = random.Next(minAvgPrice, maxAvgPrice);
        }

        public void RegisterSubscriber(User subscriber)
        {
            Subscribers.Add(subscriber);
        }

        public void RemoveSubscriber(User subscriber)
        {
            Subscribers.Remove(subscriber);
        }

        public void NotifyAllSubscribers(int price)
        {
            foreach (User subscriber in Subscribers)
            {
                subscriber.UserNotifiedWhenPriceOK(price);
            }
        }
    }
}
