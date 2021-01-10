using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoSharingApp.Data.Models
{
    public class Comment
    {
        //Primary Key
        public int CommentID { get; set; }

        //foto comentario relación
        public int PhotoID { get; set; }

        //idUser comentario
        public string UserName { get; set; }

        //Titól comentari 
        public string Subject { get; set; }

        //Body
        public string Body { get; set; }

        //foto con la que se relaciona propiedad comentario
        public virtual Photo Photo { get; set; }
    }
}