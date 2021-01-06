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
        //arxiu foto
        public byte[] File { get; set; }

        
        public string ImageMimeType { get; set; }
    }
}
