using NakedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Model
{
    public class RecomendedItems
    {
        #region injected services

        public IDomainObjectContainer Container { set; protected get; }
        
        
        #endregion

        [NakedObjectsIgnore]//Indicates that this property will never be seen in the UI
        public virtual int Id { get; set; }

        [Title]//This property will be used for the object's title at the top of the view and in a link
        public virtual string name { get; set; }

        #region products (collection)
        private ICollection<Product> _products = new List<Product>();

        public virtual ICollection<Product> Products
        {
            get
            {
                return _products;
            }
            set
            {
                _products = value;
            }
        }
        #endregion

        


    }
}
