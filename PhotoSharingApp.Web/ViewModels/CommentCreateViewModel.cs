using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhotoSharingApp.Web.ViewModels
{
    public class CommentCreateViewModel
    {
        public int PhotoID { get; set; }

        [Required]
        [StringLength(250)]
        public string Subject { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }
    }
}