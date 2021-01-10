using PhotoSharingApp.Data.API;
using PhotoSharingApp.Web.Extensions;
using PhotoSharingApp.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoSharingApp.Web.Controllers
{


    /// <summary>
    /// [ValueReporter] parece ser un data anotetion de fabricacion casera ya que 
    /// hereda de la clase "ActionFilterAttribute" posicionar el raton encima.(EXPLICAR MEJOR)
    /// -------
    /// [RoutePrefix("Photo")]= es una clase y su nombre lo define bien es un prefijo 
    /// dela ruta
    /// </summary>
    [ValueReporter]
    [RoutePrefix("Photo")]
    // photocontroller herede de la clase controller
    public class PhotoController : Controller
    {
        //tipo de acceso private photoApi hereda de la clase "PhotoSharingAPI" y solofunciona en esta clase
        private PhotoSharingAPI photoAPI;

        //metodo o constructor que crea un nuevo objeto "PhotoSharingAPI"
        public PhotoController()
        {
            photoAPI = new PhotoSharingAPI();
        }

        //metodo
        public ActionResult Index()
        {
            //la variable photos pilla de la clase photoAPI el metodo GetAllPhotos y hace una 
            //expresion lambda y utiliza el metodo tolist
            var photos = photoAPI.GetAllPhotos().Select(m => m.ToIndexViewModel()).ToList();
            //metodo view devuelve un objeto, en este caso el objeto photos
            return View(photos);
        }

        [Route("{id}")]
        public ActionResult Details(int id)
        {
            var photo = photoAPI.FindPhotoById(id);
            if (photo == null)
            {
                return HttpNotFound();
            }
            else
            {
                var model = new PhotoDetailsViewModel
                {
                    Photo = photo.ToDetailsViewModel(),
                    Comments = photo.Comments.Select(x => x.toViewModel()).ToList()
                };

                return View(model);
            }
        }

        [Route("Create")]
        public ActionResult Create()
        {
            var newPhoto = new PhotoCreateViewModel();
            var types = photoAPI.GetAllPhotoTypes();

            newPhoto.PhotoTypes = new SelectList(types, "PhotoTypeID", "Description");

            return View(newPhoto);
        }

        [HttpPost]
        [Route("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PhotoCreateViewModel photo, HttpPostedFileBase image)
        {
            photo.CreatedDate = DateTime.Today;
            if (!ModelState.IsValid)
            {
                var types = photoAPI.GetAllPhotoTypes();
                photo.PhotoTypes = new SelectList(types, "PhotoTypeID", "Description");
                return View(photo);
            }
            else
            {
                photo.CreatedDate = DateTime.Today;
                if (image != null)
                {
                    var photoFile = new byte[image.ContentLength];
                    image.InputStream.Read(photoFile, 0, image.ContentLength);
                    photoAPI.AddPhoto(photo.ToDataModel(), photoFile, image.ContentType);
                }
                else
                {
                    photoAPI.AddPhoto(photo.ToDataModel());
                }

                return RedirectToAction("Index");
            }
        }

        [Route("{id}/Delete")]
        public ActionResult Delete(int id)
        {
            var photo = photoAPI.FindPhotoById(id);
            if (photo == null)
            {
                return HttpNotFound();
            }
            else
            {
                var model = new PhotoDeleteViewModel
                {
                    Photo = photo.ToDetailsViewModel()
                };

                return View(model);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        [Route("{id}/Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var photo = photoAPI.FindPhotoById(id);
            if (photo == null)
            {
                return HttpNotFound();
            }
            else
            {
                photoAPI.DeletePhoto(photo);
            }
            return RedirectToAction("Index");
        }

        [Route("{id}/GetImage")]
        public FileContentResult GetImage(int id)
        {
            var photo = photoAPI.FindPhotoById(id);
            if (photo != null && photo.File != null)
            {
                return File(photo.File.File, photo.File.ImageMimeType);
            }
            else
            {
                return null;
            }
        }

        [HttpGet]
        [Route("{PhotoID}/AddCommentToPhoto")]
        public PartialViewResult AddCommentToPhoto(int PhotoID)
        {
            var photo = photoAPI.FindPhotoById(PhotoID);
            if (photo != null)
            {
                var model = new CommentCreateViewModel();
                model.PhotoID = PhotoID;

                return PartialView("_AddCommentToPhoto", model);
            }
            else
            {
                throw new NullReferenceException("The Photo with the specified ID was not found");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("{PhotoID}/AddCommentToPhoto")]
        public PartialViewResult AddCommentToPhoto(CommentCreateViewModel comment)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_AddCommentToPhoto", comment);
            }
            else
            {
                photoAPI.AddComment(comment.toDataModel());

                var model = new CommentCreateViewModel { PhotoID = comment.PhotoID };

                ModelState.Clear();
                return PartialView("_AddCommentToPhoto", model);
            }

        }

        [Route("{PhotoID}/CommentsForPhoto")]
        public PartialViewResult CommentsForPhoto(int PhotoID)
        {
            var model = new List<CommentViewModel>();
            var comments = photoAPI.FindCommentsByPhotoId(PhotoID);

            if (comments != null && comments.Count > 0)
            {
                model = comments.Select(x => x.toViewModel()).ToList();
            }

            return PartialView("_CommentsForPhoto", model);
        }

        [Route("{PhotoID}/AddToFavorites")]
        public ContentResult AddToFavorites(int PhotoID)
        {
            AddPhotoToFavorites(PhotoID);

            return Content("The picture has been added to your favorites", "text/plain", System.Text.Encoding.Default);
        }

        private void AddPhotoToFavorites(int PhotoID)
        {
            return;
        }
    }
}