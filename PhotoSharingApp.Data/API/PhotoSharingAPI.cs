using PhotoSharingApp.Data.Models;
using PhotoSharingApp.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSharingApp.Data.API
{
    public class PhotoSharingAPI
    {
        IDataRepository repository;

        public PhotoSharingAPI()
        {
            repository = new DefaultRepository();
        }

        public List<Photo> GetMostRecentPhotos(int take)
        {
            return repository.Filter<Photo>(e => true).OrderByDescending(x => x.CreatedDate).Take(take).ToList();
        }

        public List<Photo> GetAllPhotos()
        {
            return repository.Filter<Photo>(e => true, new List<string> { "Type" }).OrderByDescending(x => x.CreatedDate).ToList();
        }

        public List<PhotoType> GetAllPhotoTypes()
        {
            return repository.Filter<PhotoType>(e => true).OrderBy(x => x.Description).ToList();
        }

        public Photo FindPhotoById(int ID)
        {
            return repository.FindById<Photo>(ID);
        }

        public Photo FindPhotoByTitle(string title)
        {
            return repository.Filter<Photo>(e => e.Title == title).FirstOrDefault();
        }

        public Photo AddPhoto(Photo photo)
        {
            return repository.Add(photo);
        }

        public Photo AddPhoto(Photo photo, byte[] data, string mimeType)
        {
            var file = new PhotoFile
            {
                File = data,
                ImageMimeType = mimeType
            };
            using (var transaction = repository.BeginTransaction())
            {
                try
                {
                    file = repository.Add(file);
                    photo.PhotoFileID = file.ID;
                    photo = repository.Add(photo);
                    transaction.Commit();
                    return photo;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }

        public Photo DeletePhoto(Photo photo)
        {
            PhotoFile file = null;

            if (photo.PhotoFileID.HasValue)
            {
                file = repository.FindById<PhotoFile>(photo.PhotoFileID.Value);
            }

            if (file != null)
            {
                using (var transaction = repository.BeginTransaction())
                {
                    try
                    {
                        repository.Delete(file);
                        photo = repository.Delete(photo);
                        transaction.Commit();
                        return photo;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
            else
            {
                return repository.Delete(photo);
            }
        }

        public Comment DeleteComment(Comment comment)
        {
            return repository.Delete(comment);
        }

        public Comment AddComment(Comment comment)
        {
            return repository.Add(comment);
        }

        public Comment FindCommentById(int ID)
        {
            return repository.FindById<Comment>(ID);
        }

        public List<Comment> FindCommentsByPhotoId(int photoId)
        {
            return repository.Filter<Comment>(e => e.PhotoID == photoId).OrderByDescending(x => x.CommentID).ToList();
        }
    }
}
