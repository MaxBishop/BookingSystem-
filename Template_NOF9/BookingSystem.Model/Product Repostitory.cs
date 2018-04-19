using NakedObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Model
{
    public class Product_Repostitory
    {
        #region Injected Services
        //An implementation of this interface is injected automatically by the framework
        public IDomainObjectContainer Container { set; protected get; }
        public Product Product { set; protected get; }
        #endregion
        public Product CreateNewProduct()
        {
            //'Transient' means 'unsaved' -  returned to the user
            //for fields to be filled-in and the object saved.
            return Container.NewTransientInstance<Product>();
        }

        public IQueryable<Product> AllProducts()
        {
            //The 'Container' masks all the complexities of 
            //dealing with the database directly.
            return Container.Instances<Product>();
        }

        public IQueryable<Product> FindProductByName(string name)
        {
            //Filters students to find a match
            return AllProducts().Where(c => c.ProductName.ToUpper().Contains(name.ToUpper()));
        }
        [NakedObjectsIgnore]
        public List<Product> FileReader()
        {
            string line;
            var listOfProducts = new List<Product>();

            // Read the file and display it line by line.
       
               using (StreamReader myFile = new StreamReader(@"C:\Users\Max\Documents\GitHub\BookingSystem-\Template_NOF9\TextFile1.txt"))
            {
                while ((line = myFile.ReadLine()) != null)
                {
                    string[] words = line.Split(',');
                    Product E = new Product();
                    E.ProductName = words[2];
                    E.price = Decimal.Parse(words[3]);                  
                    listOfProducts.Add(E);
                }
            }
            
            return listOfProducts;
        }
       
    }
}
