using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace PhotoSharingApp.Data.Models
{
    public class PhotoSharingContext : DbContext
    {
        public PhotoSharingContext()
            : base("name=PhotoSTitan")
        {

        }

        public DbSet<Photo> Photos { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<PhotoType> PhotoTypes { get; set; }
        public DbSet<PhotoFile> PhotoFiles { get; set; }

    }
}