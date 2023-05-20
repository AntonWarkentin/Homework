using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_10
{
    public class User
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public AvgHousingPriceMonitor Subscription { get; set; }

        public User(string firstName, string lastName, string middleName = null, AvgHousingPriceMonitor subscription = null)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            Subscription = subscription;

            if (Subscription != null)
            {
                Subscription.RegisterSubscriber(this);
            }
        }

        public void CloseSubscription()
        {
            Subscription?.RemoveSubscriber(this);
            Subscription = null;
        }

        public void UserNotifiedWhenPriceOK(int price)
        {
            Console.WriteLine($"Average housing price {price} has become affordable. User {FirstName} {MiddleName} {LastName} has been notified about that just now.");
        }
    }
}
