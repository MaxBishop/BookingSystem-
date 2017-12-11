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
        public Pupil Pupil { set; protected get; }
        public Product_Repostitory Product_Repository { set; protected get; }
        public PupilRepository PupilRepository { set; protected get; }
        #endregion

        public IQueryable<RecomendedItems> AllRecomendedItems()
        {
            //The 'Container' masks all the complexities of 
            //dealing with the database directly.
            return Container.Instances<RecomendedItems>();


        }

            public List<Product> RecomendedItemsList()
            {
            //'Transient' means 'unsaved' -  returned to the user
            //for fields to be filled-in and the object saved.

            //var pup = PupilRepository.AllPupils().Where(c => c.FullName.ToUpper().Contains(name.ToUpper()));

            var Pupil = PupilRepository.MyChildren().FirstOrDefault();

            var Items = Product_Repository.AllProducts();

                if (Pupil.Sex == Sex.Male)
                {
                    Items = Items.Where(i => i.Sex == Sex.Male);
                    if (Pupil.Form == Form._3rdForm)
                    {

                        var RecItems = Items.Where(i => i.Form == Form._3rdForm);
                        return RecItems.ToList();
                    }

                    else if (Pupil.Form == Form._6thForm)
                    {


                        var RecItems = Items.Where(i => i.Form == Form._6thForm);
                        return RecItems.ToList();
                    }
                }
                if (Pupil.Sex == Sex.Female)
                {
                    Items = Items.Where(i => i.Sex == Sex.Female);
                    if (Pupil.Form == Form._3rdForm)
                    {


                        var RecItems = Items.Where(i => i.Form == Form._3rdForm);
                        return RecItems.ToList();
                    }
                    else if (Pupil.Form == Form._6thForm)
                    {


                        var RecItems = Items.Where(i => i.Form == Form._6thForm);
                        return RecItems.ToList();
                    }
                }

                return null;

            }
        }


    }

