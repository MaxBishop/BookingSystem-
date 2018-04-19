using NakedObjects;
using NakedObjects.Value;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Model
{
    public class Information
    {
        [NakedObjectsIgnore]
        public virtual int Id { get; set; }

        [Title]
        public virtual string Title { get; set; }

        //[MultiLine(NumberOfLines = 10)]
        public virtual string Text { get; set; }

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

        public void AddOrChangePhotoInfo(Image newImage)
        {
            PhotoContent = newImage.GetResourceAsByteArray();
            PhotoName = newImage.Name;
            PhotoMime = newImage.MimeType;
        }
    }
}
