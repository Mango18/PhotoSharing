using PhotoSharingApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoSharingApp.Web.ViewModels
{
    public static class ModelExtensions
    {
        public static PhotoViewModel ToDetailsViewModel(this Photo dataModel)
        {
            var viewModel = new PhotoViewModel()
            {
                Description = dataModel.Description,
                CreatedDate = dataModel.CreatedDate,
                PhotoID = dataModel.PhotoID,
                Title = dataModel.Title,
                Type = dataModel.Type.Description,
                PhotoFileID = dataModel.PhotoFileID
            };

            return viewModel;
        }

        public static PhotoIndexViewModel ToIndexViewModel(this Photo dataModel)
        {
            var viewModel = new PhotoIndexViewModel()
            {
                CreatedDate = dataModel.CreatedDate,
                PhotoID = dataModel.PhotoID,
                Title = dataModel.Title,
                Type = dataModel.Type.Description,
                PhotoFileID = dataModel.PhotoFileID
            };
            return viewModel;
        }

        public static Photo ToDataModel(this PhotoCreateViewModel viewModel)
        {
            var model = new Photo()
            {
                Description = viewModel.Description,
                CreatedDate = viewModel.CreatedDate,
                Title = viewModel.Title,
                PhotoTypeID = viewModel.TypeID,
                PhotoDate = viewModel.PhotoDate.Value
            };
            return model;
        }

        public static Comment toDataModel(this CommentCreateViewModel dataModel)
        {

            var viewModel = new Comment
            {
                Body = dataModel.Body,
                Subject = dataModel.Subject,
                PhotoID = dataModel.PhotoID,
            };

            return viewModel;
        }

        public static CommentViewModel toViewModel(this Comment dataModel)
        {
            var model = new CommentViewModel
            {
                Body = dataModel.Body,
                Subject = dataModel.Subject
            };

            return model;
        }
    }
}