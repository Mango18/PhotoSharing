using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace PhotoSharingApp.Data.Models
{
    public class Photo
    {
        //primary key
        public int PhotoID { get; set; }

        //titulo foto
        public string Title { get; set; }

        //Descripcion
        public string Description { get; set; }

        //CreatedDate
        public DateTime CreatedDate { get; set; }

        //fecha de toma
        public DateTime PhotoDate { get; set; }

        //quien realizo la foto
        public string UserName { get; set; }
        //tipo de foto
        public int PhotoTypeID { get; set; }
        //id del tipo de foto
        public int? PhotoFileID { get; set; }

        //Todos los comentarios de esta foto, como propiedad de navegación
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual PhotoType Type { get; set; }
        public virtual PhotoFile File { get; set; }

    }
}