using NakedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Model
{
    public class RecomendedItemsRepository
    {
        #region Injected Services
        //An implementation of this interface is injected automatically by the framework
        public IDomainObjectContainer Container { set; protected get; }
        #endregion

        public IQueryable<RecomendedItems> AllRecomendedItems()
        {
            //The 'Container' masks all the complexities of 
            //dealing with the database directly.
            return Container.Instances<RecomendedItems>();
        }


    }
}
