using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSharingApp.Data.Models
{
    public class PhotoFile
    {
        public int ID { get; set; }
        //PhotoFile. This is a picture file
        public byte[] File { get; set; }

        //ImageMimeType, stores the MIME type for the PhotoFile
        public string ImageMimeType { get; set; }
    }
}
