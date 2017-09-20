using NakedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Model
{
    public class OrderLine
    {
        [NakedObjectsIgnore]//Indicates that this property will never be seen in the UI
        public virtual int ID { get; set; }

        [Title]
        public virtual Product Product { get; set; }

        [NakedObjectsIgnore]
        public virtual int ProductID { get; set; }

        public virtual int Quantity { get; set; }

   //     public void AddToBasket(Product product, int Quantitiy)
   //     {

  //      }


 //       public int DefaultQuantity()
  //      {
  //          return 1;
  //      }
       // public decimal Subtotal()
      //  {
      //      var Subtotal = product.price * Quantity;
      //      return Subtotal;
      //  }
       
    }
}
