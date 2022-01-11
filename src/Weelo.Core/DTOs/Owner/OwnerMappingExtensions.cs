using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weelo.Core.Entities;

namespace Weelo.Core.DTOs
{
    public static class OwnerMappingExtensions
    {
        public static Owner CreateToBase(this CreateOwnerRequest model)
        {
            var entity = new Owner
            {
                Name = model.Name,
                Address = model.Address,
                Photo = model.Photo,
                Birthday = model.Birthday,
                Active = true,
                Deleted = false
            };
            return entity;
        }

        //public static Owner CreateToBase(this UpdateOwnerRequest model)
        //{
        //    var entity = new Owner
        //    {
        //        Name = model.Name,
        //        Address = model.Address,
        //        Photo = model.Photo,
        //        Birthday = model.Birthday,
        //        Active = true,
        //        Deleted = false
        //    };
        //    return entity;
        //}



        public static CreateOwnerResponse CreateToModel(this Owner entity)
        {
            var model = new CreateOwnerResponse
            {
                IdOwner = entity.IdOwner
            };
            return model;
        }


        public static OwnerResponse ToModel(this Owner entity, bool showPhoto = true)
        {
            var model = new OwnerResponse
            {
                IdOwner = entity.IdOwner,
                Name = entity.Name,
                Address = entity.Address,
                Photo = showPhoto ? entity.Photo : null,
                Birthday = entity.Birthday
            };
            return model;
        }

        public static IList<OwnerResponse> ToModels(this IList<Owner> entities)
        {
            var models = new List<OwnerResponse>();
            foreach (var entity in entities)
            {
                models.Add(entity.ToModel(false));
            }

            return models;
        }


    }
}
