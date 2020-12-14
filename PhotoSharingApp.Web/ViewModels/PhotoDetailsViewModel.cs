using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhotoSharingApp.Web.ViewModels
{
    public class PhotoDetailsViewModel
    {
        public PhotoViewModel Photo { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }

        public PhotoDetailsViewModel()
        {
            this.Comments = new List<CommentViewModel>();
        }

    }

}