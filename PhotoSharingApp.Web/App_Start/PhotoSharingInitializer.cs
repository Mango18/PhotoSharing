using PhotoSharingApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;

namespace PhotoSharingApp.Web
{
    public class PhotoSharingInitializer : DropCreateDatabaseAlways<PhotoSharingContext>
    {
        
   
        protected override void Seed(PhotoSharingContext context)
        {
            base.Seed(context);

            var photoTypes = new List<PhotoType>()
            {
                new PhotoType {
                    PhotoTypeID = 1,
                    Description = "Type1"
                },
                new PhotoType {
                    PhotoTypeID = 2,
                    Description = "Type2"
               }
            };

            photoTypes.ForEach(s => context.PhotoTypes.Add(s));
            context.SaveChanges();

            var files = new List<PhotoFile>()
            {
                new PhotoFile
                {
                    ID = 1,
                    File = getFileBytes("\\Images1\\annie.jpg"),
                    ImageMimeType = "image/jpeg",
                },
                new PhotoFile
                {
                    ID = 2,
                    File = getFileBytes("\\Images1\\armin.jpg"),
                    ImageMimeType = "image/jpeg",
                },
                new PhotoFile
                {
                    ID = 3,
                     File = getFileBytes("\\Images1\\eren.jpg"),
                    ImageMimeType = "image/jpeg",
                },
                new PhotoFile
                {
                    ID = 4,
                    File = getFileBytes("\\Images1\\erwin.jpg"),
                    ImageMimeType = "image/jpeg",
                },
                new PhotoFile
                {
                    ID = 5,
                    File = getFileBytes("\\Images1\\hanji.jpg"),
                    ImageMimeType = "image/jpeg",
                },
                 new PhotoFile
                {
                    ID = 6,
                    File = getFileBytes("\\Images1\\Levy.jpg"),
                    ImageMimeType = "image/jpeg",
                },
                  new PhotoFile
                {
                    ID = 6,
                    File = getFileBytes("\\Images1\\miKasa.jpg"),
                    ImageMimeType = "image/jpeg",
                },

            };

            files.ForEach(s => context.PhotoFiles.Add(s));
            context.SaveChanges();

            
            var photos = new List<Photo>
            {
                new Photo {
                    Title = "Annie",
                    Description = "Description Annie",
                    UserName = "Annie",
                    PhotoFileID = 1,
                    CreatedDate = DateTime.Today.AddDays(-5),
                    PhotoTypeID = 1,
                    PhotoDate  = DateTime.Today.AddDays(-5)
                },
                new Photo {
                    Title = "Armin",
                    Description = "Description Armin",
                    UserName = "Armin",
                    PhotoFileID = 2,
                    CreatedDate = DateTime.Today.AddDays(-14),
                    PhotoTypeID = 2,
                    PhotoDate  = DateTime.Today.AddDays(-14)
                },
                new Photo {
                    Title = "Eren",
                    Description = "Description Eren",
                    UserName = "Eren",
                    PhotoFileID = 3,
                    CreatedDate = DateTime.Today.AddDays(-14),
                    PhotoTypeID = 1,
                    PhotoDate  = DateTime.Today.AddDays(-5)
                },
                new Photo {
                    Title = "Hanji",
                    Description = "Description Hanji",
                    UserName = "Hanji",
                    PhotoFileID = 4,
                    CreatedDate = DateTime.Today.AddDays(-12),
                    PhotoTypeID = 1,
                    PhotoDate  = DateTime.Today.AddDays(-12)
                },
                new Photo {
                    Title = "Levy",
                    Description = "Description Levy",
                    UserName = "Levy",
                    PhotoFileID = 5,
                    CreatedDate = DateTime.Today.AddDays(-11),
                    PhotoTypeID = 2,
                    PhotoDate  = DateTime.Today.AddDays(-6)

                },
                new Photo {
                    Title = "miKasa",
                    Description = "Description miKasa",
                    UserName = "miKasa",
                    PhotoFileID = 6,
                    CreatedDate = DateTime.Today.AddDays(-11),
                    PhotoTypeID = 2,
                    PhotoDate  = DateTime.Today.AddDays(-1)
                },



            


            };
            photos.ForEach(s => context.Photos.Add(s));
            context.SaveChanges();

            
            var comments = new List<Comment>
            {
                new Comment {
                    PhotoID = 1,
                    UserName = "Adan",
                    Subject = "Sample Comment 1",
                    Body = "First sample comment"
                },
                new Comment {
                    PhotoID = 2,
                    UserName = "Eva",
                    Subject = "Sample Comment 2",
                    Body = "Second sample comment"
                },
                new Comment {
                    PhotoID = 3,
                    UserName = "Noe",
                    Subject = "Sample Comment 3",
                    Body = "Third sample comment"
                },
                new Comment {
                    PhotoID = 4,
                    UserName = "David",
                    Subject = "Sample Comment 4",
                    Body = "4 sample comment"
                },
                new Comment {
                    PhotoID = 5,
                    UserName = "Salomon",
                    Subject = "Sample Comment 5",
                    Body = "5 sample comment"
                },
                new Comment {
                    PhotoID = 6,
                    UserName = "Saul",
                    Subject = "Sample Comment 6",
                    Body = "6 sample comment"
                },
       
       
     
            };
            comments.ForEach(s => context.Comments.Add(s));
            context.SaveChanges();
        }

        //This gets a byte array for a file at the path specified
        //The path is relative to the route of the web site
        //It is used to seed images
        private byte[] getFileBytes(string path)
        {
            FileStream fileOnDisk = new FileStream(HttpRuntime.AppDomainAppPath + path, FileMode.Open);
            byte[] fileBytes;
            using (BinaryReader br = new BinaryReader(fileOnDisk))
            {
                fileBytes = br.ReadBytes((int)fileOnDisk.Length);
            }
            return fileBytes;
        }

    }
}