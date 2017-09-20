using BookingSystem.Model;
using NakedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Model
{
    public class Order
    {
        [NakedObjectsIgnore]//Indicates that this property will never be seen in the UI
        public virtual int Id { get; set; }

        
        private ICollection< OrderLine > _Basket = new List< OrderLine >();
        [Hidden(WhenTo.UntilPersisted)]
        public virtual ICollection<OrderLine>Basket
        {
            get
            {
                return _Basket;
            }
            set
            {
                _Basket = value;
            }
        }

        public void AddOrderLine(OrderLine OrderLine)
        {
            Basket.Add(OrderLine);
        }

        public virtual Status status { get; set; }





    }
}
