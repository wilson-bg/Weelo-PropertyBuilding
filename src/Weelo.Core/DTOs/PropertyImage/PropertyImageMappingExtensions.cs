using Weelo.Core.Entities;

namespace Weelo.Core.DTOs
{
    public static class PropertyImageMappingExtensions
    {
        public static PropertyImage CreateToBase(this CreatePropertyImageRequest model)
        {
            var entity = new PropertyImage
            {
                IdProperty = model.IdProperty,
                File = model.File,
                Enable = model.Enable.HasValue ? model.Enable.Value : true
            };
            return entity;
        }

        public static CreatePropertyImageResponse CreateToModel(this PropertyImage entity)
        {
            var model = new CreatePropertyImageResponse
            {
                IdPropertyImage = entity.IdPropertyImage
            };
            return model;
        }


    }
}
