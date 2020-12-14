using PhotoSharingApp.Web.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoSharingApp.Web.ViewModels
{
    public class PhotoCreateViewModel
    {
        [Required]
        [MaxWords(3, ErrorMessage = "{0} debería tener como máximo 3 palabras!")]
        public string Title { get; set; }

        [Required]
        [DisplayName("Type")]
        public int TypeID { get; set; }

        [DisplayName("Photo")]
        public int? PhotoFileID { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DataType(DataType.DateTime), DisplayName("Created Date")]
        public DateTime CreatedDate { get; set; }

        public SelectList PhotoTypes { get; set; }

        [Required]
        [DataType(DataType.Date), DisplayName("Photo Date")]
        public DateTime? PhotoDate { get; set; }
    }
}