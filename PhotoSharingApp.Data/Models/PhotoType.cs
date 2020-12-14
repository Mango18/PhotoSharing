using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSharingApp.Data.Models
{
    public class PhotoType
    {
        public int PhotoTypeID { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Photo> Photos { get; set; }
    }
}
