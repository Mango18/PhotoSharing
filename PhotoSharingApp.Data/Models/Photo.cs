using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace PhotoSharingApp.Data.Models
{
    public class Photo
    {
        //PhotoID. This is the primary key
        public int PhotoID { get; set; }

        //Title. The title of the photo
        public string Title { get; set; }

        //Description.
        public string Description { get; set; }

        //CreatedDate
        public DateTime CreatedDate { get; set; }

        //Date when the photo was taken
        public DateTime PhotoDate { get; set; }

        //UserName. This is the name of the user who created the photo
        public string UserName { get; set; }

        public int PhotoTypeID { get; set; }

        public int? PhotoFileID { get; set; }

        //All the comments on this photo, as a navigation property
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual PhotoType Type { get; set; }
        public virtual PhotoFile File { get; set; }

    }
}