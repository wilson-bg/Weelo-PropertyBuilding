using System.Collections.Generic;
using Weelo.Core.Entities;

namespace Weelo.Core.DTOs
{
    public static class PropertyMappingExtensions
    {
        public static Property CreateToBase(this CreatePropertyRequest model)
        {
            var entity = new Property
            {
                Name = model.Name,
                Address = model.Address,
                Price = model.Price,
                CodeInternal = model.CodeInternal,
                Year = model.Year,
                IdOwner = model.IdOwner,
                Active = true,
                Deleted = false
            };
            return entity;
        }

        public static CreatePropertyResponse CreateToModel(this Property entity)
        {
            var model = new CreatePropertyResponse
            {
                IdProperty = entity.IdProperty
            };
            return model;
        }

        public static Property CreateToBase(this UpdatePropertyPriceRequest model)
        {
            var entity = new Property
            {
                IdProperty = model.IdProperty,
                Price = model.Price,
                
            };
            return entity;
        }

        public static PropertyResponse ToModel(this Property entity)
        {            
            var model = new PropertyResponse
            {
                IdProperty = entity.IdProperty,
                Name = entity.Name,
                Address = entity.Address,
                Price = entity.Price,
                CodeInternal = entity.CodeInternal,
                Year = entity.Year,
                Owner = entity.Owner == null ? new OwnerResponse(): entity.Owner.ToModel(false)

        };
            return model;
        }

        public static IList<PropertyResponse> ToModels(this IList<Property> entities)
        {
            var models = new List<PropertyResponse>();
            foreach (var entity in entities)
            {
                models.Add(entity.ToModel());
            }

            return models;
        }
    }
}
