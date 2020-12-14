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
        //This method puts sample data into the database
        /// <summary>
        /// creo que se crea un SQL Exeption cuando no s puede grabar todo en la db, ME explico la foto cost lo q sea q aparece que 
        /// no esta hace que falte el Foreing Key de la foto en si y como el resto esta numerada es como si faltara en este caso la 7
        /// 
        /// SOLUCION creo
        /// comentar de momento el resto de entradas!!!
        /// </summary>
        /// <param name="context"></param>
        protected override void Seed(PhotoSharingContext context)
        {
            base.Seed(context);

            var photoTypes = new List<PhotoType>()
            {
                new PhotoType {
                    PhotoTypeID = 1,
                    Description = "Panoramic"
                },
                new PhotoType {
                    PhotoTypeID = 2,
                    Description = "Portrait"
               }
            };

            photoTypes.ForEach(s => context.PhotoTypes.Add(s));
            context.SaveChanges();

            var files = new List<PhotoFile>()
            {
                new PhotoFile
                {
                    ID = 1,
                    File = getFileBytes("\\Images\\flower.jpg"),
                    ImageMimeType = "image/jpeg",
                },
                new PhotoFile
                {
                    ID = 2,
                    File = getFileBytes("\\Images\\orchard.jpg"),
                    ImageMimeType = "image/jpeg",
                },
                new PhotoFile
                {
                    ID = 3,
                     File = getFileBytes("\\Images\\path.jpg"),
                    ImageMimeType = "image/jpeg",
                },
                new PhotoFile
                {
                    ID = 4,
                    File = getFileBytes("\\Images\\fungi.jpg"),
                    ImageMimeType = "image/jpeg",
                },
                new PhotoFile
                {
                    ID = 5,
                    File = getFileBytes("\\Images\\pinkflower.jpg"),
                    ImageMimeType = "image/jpeg",
                },
                 new PhotoFile
                {
                    ID = 6,
                    File = getFileBytes("\\Images\\blackberries.jpg"),
                    ImageMimeType = "image/jpeg",
                },


                
              // < new PhotoFile
              // {
              //// //     ID = 7,
              //// //     File = getFileBytes("\\Images\\coastalview.jpg"),
              //// //     ImageMimeType = "image/jpeg",
              //////  },


              //   new PhotoFile
              //  {
              //      ID = 8,
              //      File = getFileBytes("\\Images\\headland.jpg"),
              //      ImageMimeType = "image/jpeg",
              //  },
              //   new PhotoFile
              //  {
              //      ID = 9,
              //      File = getFileBytes("\\Images\\pebbles.jpg"),
              //      ImageMimeType = "image/jpeg",
              //  },
              //   new PhotoFile
              //  {
              //      ID = 10,
              //      File = getFileBytes("\\Images\\pontoon.jpg"),
              //      ImageMimeType = "image/jpeg",
              //  },
              //   new PhotoFile
              //  {
              //      ID = 11,
              //      File = getFileBytes("\\Images\\ripples.jpg"),
              //      ImageMimeType = "image/jpeg",
              //  },
              //   new PhotoFile
              //  {
              //      ID = 12,
              //      File = getFileBytes("\\Images\\rockpool.jpg"),
              //      ImageMimeType = "image/jpeg",
              //  },
              //   new PhotoFile
              //  {
              //      ID = 13,
              //      File = getFileBytes("\\Images\\track.jpg"),
              //      ImageMimeType = "image/jpeg",
              //  }

            };

            files.ForEach(s => context.PhotoFiles.Add(s));
            context.SaveChanges();

            //Create some photos
            var photos = new List<Photo>
            {
                new Photo {
                    Title = "Sample Photo 1",
                    Description = "This is the first sample photo in the Adventure Works photo application",
                    UserName = "AllisonBrown",
                    PhotoFileID = 1,
                    CreatedDate = DateTime.Today.AddDays(-5),
                    PhotoTypeID = 1,
                    PhotoDate  = DateTime.Today.AddDays(-5)
                },
                new Photo {
                    Title = "Sample Photo 2",
                    Description = "This is the second sample photo in the Adventure Works photo application",
                    UserName = "RogerLengel",
                    PhotoFileID = 2,
                    CreatedDate = DateTime.Today.AddDays(-14),
                    PhotoTypeID = 2,
                    PhotoDate  = DateTime.Today.AddDays(-14)
                },
                new Photo {
                    Title = "Sample Photo 3",
                    Description = "This is the third sample photo in the Adventure Works photo application",
                    UserName = "AllisonBrown",
                    PhotoFileID = 3,
                    CreatedDate = DateTime.Today.AddDays(-14),
                    PhotoTypeID = 1,
                    PhotoDate  = DateTime.Today.AddDays(-5)
                },
                new Photo {
                    Title = "Sample Photo 4",
                    Description = "This is the forth sample photo in the Adventure Works photo application",
                    UserName = "JimCorbin",
                    PhotoFileID = 4,
                    CreatedDate = DateTime.Today.AddDays(-12),
                    PhotoTypeID = 1,
                    PhotoDate  = DateTime.Today.AddDays(-12)
                },
                new Photo {
                    Title = "Sample Photo 5",
                    Description = "This is the fifth sample photo in the Adventure Works photo application",
                    UserName = "JamieStark",
                    PhotoFileID = 5,
                    CreatedDate = DateTime.Today.AddDays(-11),
                    PhotoTypeID = 2,
                    PhotoDate  = DateTime.Today.AddDays(-6)

                },
                new Photo {
                    Title = "Sample Photo 6",
                    Description = "This is the sixth sample photo in the Adventure Works photo application",
                    UserName = "JamieStark",
                    PhotoFileID = 6,
                    CreatedDate = DateTime.Today.AddDays(-11),
                    PhotoTypeID = 2,
                    PhotoDate  = DateTime.Today.AddDays(-1)
                },



            //  //  new Photo {
            //    //    Title = "Sample Photo 7",
            //      //  Description = "This is the seventh sample photo in the Adventure Works photo application",
            //        //UserName = "BernardDuerr",
            ////        PhotoFileID = 7,
            //  //      CreatedDate = DateTime.Today.AddDays(-10),
            //    //    PhotoTypeID = 2,
            //      //  PhotoDate  = DateTime.Today.AddDays(-50)
            //   // },



            //    new Photo {
            //        Title = "Sample Photo 8",
            //        Description = "This is the eigth sample photo in the Adventure Works photo application",
            //        UserName = "FengHanYing",
            //        PhotoFileID = 8,
            //        CreatedDate = DateTime.Today.AddDays(-9),
            //        PhotoTypeID = 1,
            //        PhotoDate  = DateTime.Today.AddDays(-13)
            //    },
            //    new Photo {
            //        Title = "Sample Photo 9",
            //        Description = "This is the ninth sample photo in the Adventure Works photo application",
            //        UserName = "FengHanYing",
            //        PhotoFileID = 9,
            //        CreatedDate = DateTime.Today.AddDays(-8),
            //        PhotoTypeID = 1,
            //        PhotoDate  = DateTime.Today.AddDays(-56)
            //    },
            //    new Photo {
            //        Title = "Sample Photo 10",
            //        Description = "This is the tenth sample photo in the Adventure Works photo application",
            //        UserName = "SalmanMughal",
            //        PhotoFileID = 10,
            //        CreatedDate = DateTime.Today.AddDays(-7),
            //        PhotoTypeID = 2,
            //        PhotoDate  = DateTime.Today.AddDays(-1)
            //    },
            //    new Photo {
            //        Title = "Sample Photo 11",
            //        Description = "This is the eleventh sample photo in the Adventure Works photo application",
            //        UserName = "JamieStark",
            //        PhotoFileID = 11,
            //        CreatedDate = DateTime.Today.AddDays(-5),
            //        PhotoTypeID = 1,
            //        PhotoDate  = DateTime.Today.AddDays(-9)
            //    },
            //    new Photo {
            //        Title = "Sample Photo 12",
            //        Description = "This is the twelth sample photo in the Adventure Works photo application",
            //        UserName = "JimCorbin",
            //        PhotoFileID = 12,
            //        CreatedDate = DateTime.Today.AddDays(-3),
            //        PhotoTypeID = 2,
            //        PhotoDate  = DateTime.Today.AddDays(-15)
            //    },
            //    new Photo {
            //        Title = "Sample Photo 13",
            //        Description = "This is the thirteenth sample photo in the Adventure Works photo application",
            //        UserName = "AllisonBrown",
            //        PhotoFileID = 13,
            //        CreatedDate = DateTime.Today.AddDays(-1),
            //        PhotoTypeID = 1,
            //        PhotoDate  = DateTime.Today.AddDays(-10)
            //    }
            };
            photos.ForEach(s => context.Photos.Add(s));
            context.SaveChanges();

            //Create some comments
            var comments = new List<Comment>
            {
                new Comment {
                    PhotoID = 1,
                    UserName = "JamieStark",
                    Subject = "Sample Comment 1",
                    Body = "This is the first sample comment in the Adventure Works photo application"
                },
                new Comment {
                    PhotoID = 2,
                    UserName = "JimCorbin",
                    Subject = "Sample Comment 2",
                    Body = "This is the second sample comment in the Adventure Works photo application"
                },
                new Comment {
                    PhotoID = 3,
                    UserName = "RogerLengel",
                    Subject = "Sample Comment 3",
                    Body = "This is the third sample photo in the Adventure Works photo application"
                },
                new Comment {
                    PhotoID = 4,
                    UserName = "RogerLengel",
                    Subject = "Sample Comment 4",
                    Body = "This is the third sample photo in the Adventure Works photo application"
                },
                new Comment {
                    PhotoID = 5,
                    UserName = "RogerLengel",
                    Subject = "Sample Comment 5",
                    Body = "This is the third sample photo in the Adventure Works photo application"
                },
                new Comment {
                    PhotoID = 6,
                    UserName = "yo",
                    Subject = "comment",
                    Body = "mi puto comentario"
                },
       ////         new Comment {
       //  //           PhotoID = 7,
       //    //         UserName = "RogerLengel",
       //      //       Subject = "Sample Comment 7",
       //        //     Body = "This is the third sample photo in the Adventure Works photo application"
       //        // },



       //         new Comment {
       //             PhotoID = 8,
       //             UserName = "RogerLengel",
       //             Subject = "Sample Comment 8",
       //             Body = "This is the third sample photo in the Adventure Works photo application"
       //         },
       //         new Comment {
       //             PhotoID = 9,
       //             UserName = "RogerLengel",
       //             Subject = "Sample Comment 9",
       //             Body = "This is the third sample photo in the Adventure Works photo application"
       //         },
       //         new Comment {
       //             PhotoID = 10,
       //             UserName = "RogerLengel",
       //             Subject = "Sample Comment 11",
       //             Body = "This is the third sample photo in the Adventure Works photo application"
       //         },
       //         new Comment {
       //             PhotoID = 12,
       //             UserName = "RogerLengel",
       //             Subject = "Sample Comment 12",
       //             Body = "This is the third sample photo in the Adventure Works photo application"
       //         },
       //         new Comment {
       //             PhotoID = 13,
       //             UserName = "RogerLengel",
       //             Subject = "Sample Comment 13",
       //             Body = "This is the third sample photo in the Adventure Works photo application"
       //         }
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