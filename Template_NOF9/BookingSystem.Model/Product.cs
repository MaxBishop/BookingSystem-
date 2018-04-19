using NakedObjects;
using NakedObjects.Value;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Model
{
    public class Product
    {
        [NakedObjectsIgnore]//Indicates that this property will never be seen in the UI
        public virtual int ProductID { get; set; }

        [Title]//This property will be used for the object's title at the top of the view and in a link
        public virtual string ProductName { get; set; }

        public virtual  Form Form { get;  set; }

        public virtual Sex Sex { get; set; }

       
        public virtual string description { get; set; }

      

        public virtual decimal price { get; set; }


      
     
        public virtual Image Photo
        {
            get
            {
                if (PhotoContent != null)
                {
                    return new Image(PhotoContent, PhotoName, PhotoMime);
                }
                return null;
            }
        }

        [NakedObjectsIgnore]
        public virtual byte[] PhotoContent { get; set; }

        [NakedObjectsIgnore]
        public virtual string PhotoName { get; set; }

        [NakedObjectsIgnore]
        public virtual string PhotoMime { get; set; }

        public void AddOrChangePhoto(Image newImage)
        {
            PhotoContent = newImage.GetResourceAsByteArray();
            PhotoName = newImage.Name;
            PhotoMime = newImage.MimeType;
        }

        


    }
}
