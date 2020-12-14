using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhotoSharingApp.Web.ViewModels
{
    public class PhotoIndexViewModel
    {
        public int PhotoID { get; set; }

        public string Title { get; set; }

        public string Type { get; set; }

        [DisplayName("Photo")]
        public int? PhotoFileID { get; set; }

        [DataType(DataType.DateTime), DisplayName("Created Date")]
        public DateTime CreatedDate { get; set; }
    }
}