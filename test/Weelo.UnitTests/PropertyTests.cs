using FakeImageGenerator;
using NUnit.Framework;
using System;
using System.Linq;
using Weelo.Core.DTOs;
using Weelo.Core.Entities;
using Weelo.Core.Interfaces;
using Weelo.Core.Services;
using Weelo.Core.Wrappers;
using Weelo.Infrastructure.Data;

namespace Weelo.UnitTests
{
    [TestFixture]
    public class PropertyTests
    {
        private IOwnerRepository ownerRepository;
        private IPropertyRepository propertyRepository;
        private IRepository<PropertyImage> imageRepository;

        private IPropertyService propertyService;
        private IOwnerService ownerService;

        private Generator generator;
        private Random rnd;

        [SetUp]
        public void Setup()
        {
            propertyRepository = new PropertyRepository(ConfigureServices.GetContext);
            ownerRepository = new OwnerRepository(ConfigureServices.GetContext);
            imageRepository = new Repository<PropertyImage>(ConfigureServices.GetContext);

            propertyService = new PropertyService(propertyRepository, ownerRepository, imageRepository);
            ownerService = new OwnerService(ownerRepository);

            generator = new Generator();
            rnd = new Random();

            var owners = Enumerable.Range(1, 10)
                .Select(i => new CreateOwnerRequest
                {
                    Name = Faker.Name.FullName(),
                    Address = Faker.Address.StreetAddress(),
                    Birthday = Faker.Identification.DateOfBirth(),
                    Photo = generator.Run(rnd.Next(100000, 1500000), "Png")
                });

            Response<CreateOwnerResponse> responseOwner;
            foreach (var item in owners)
            {
                responseOwner = ownerService.InsertAsync(item).Result;
            }

            Int64 maxIdOwner = ownerService.GetAll().Result.Select(s => s.IdOwner).Max();
            var property = new CreatePropertyRequest
            {
                Name = Faker.Company.Name(),
                Address = Faker.Address.StreetAddress(),
                Price = rnd.Next(100000, 1500000),
                CodeInternal = string.Format("CD_01{0}", rnd.Next(10, 12500)),
                Year = rnd.Next(2000, 2021),
                IdOwner = maxIdOwner
            };
            var responseProperty = propertyService.InsertAsync(property).Result;

        }


        [Test]
        public void Create_Property_ReturnIdProperty()
        {
            Int64 maxIdOwner = ownerService.GetAll().Result.Select(s => s.IdOwner).Max();
            Int64 maxIdProperty = 0;

            var listProperties = propertyService.GetAll().Result;
            if (listProperties.Any())
            {
                maxIdProperty = listProperties.Select(s => s.IdProperty).Max();
            }

            var property = new CreatePropertyRequest
            {
                Name = Faker.Company.Name(),
                Address = Faker.Address.StreetAddress(),
                Price = rnd.Next(100000, 1500000),
                CodeInternal = string.Format("CD_01{0}", rnd.Next(10, 12500)),
                Year = rnd.Next(2000, 2021),
                IdOwner = maxIdOwner,
                
            };
            var rs = propertyService.InsertAsync(property).Result;

            Assert.Greater(rs.Data.IdProperty, maxIdProperty);
            Assert.Pass();
        }

        [Test]
        public void Create_Property_Image_ReturnIdPropertyImage()
        {
            Int64 maxIdProperty = propertyService.GetAll().Result.Select(s => s.IdProperty).Max();
                
            var propertyImage = new CreatePropertyImageRequest
            {
               IdProperty = maxIdProperty,
               File = generator.Run(rnd.Next(100000, 1500000), "Png"),
               Enable = true
            };
            var rs = propertyService.InsertImageAsync(propertyImage).Result;

            Assert.Greater(rs.Data.IdPropertyImage, 0);
            Assert.Pass();
        }
    }
}