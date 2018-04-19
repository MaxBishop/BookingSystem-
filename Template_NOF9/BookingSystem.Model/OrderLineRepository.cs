using NakedObjects;
using NakedObjects.Value;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Model
{
    public class OrderLineRepository
    {
        #region Injected Services
        //An implementation of this interface is injected automatically by the framework
        public IDomainObjectContainer Container { set; protected get; }
        #endregion
        public OrderLine CreateNewOrder()
        {
            //'Transient' means 'unsaved' -  returned to the user
            //for fields to be filled-in and the object saved.
            return Container.NewTransientInstance<OrderLine>();
            
          
        }

       public IQueryable<OrderLine> AllOrderItems()
        {
            //The 'Container' masks all the complexities of 
            //dealing with the database directly.
            return Container.Instances<OrderLine>();
       }

    
    }
}
