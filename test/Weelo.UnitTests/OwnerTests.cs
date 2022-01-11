
using FakeImageGenerator;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Linq;
using Weelo.Core.DTOs;
using Weelo.Core.Interfaces;
using Weelo.Core.Services;
using Weelo.Core.Wrappers;
using Weelo.Infrastructure;
using Weelo.Infrastructure.Data;

namespace Weelo.UnitTests
{
    [TestFixture]
    public class OwnerTests
    {
        private IOwnerRepository ownerRepository;
        private IOwnerService ownerService;
        private Generator generator;
        private Random rnd;

        [SetUp]
        public void Setup()
        {
            ownerRepository = new OwnerRepository(ConfigureServices.GetContext);
            ownerService = new OwnerService(ownerRepository);

            generator = new Generator();
            rnd = new Random();
            
            var owners = Enumerable.Range(1, 10)
                .Select(i => new CreateOwnerRequest { 
                    Name = Faker.Name.FullName(),
                    Address = Faker.Address.StreetAddress(),
                    Birthday = Faker.Identification.DateOfBirth(),
                    Photo = generator.Run(rnd.Next(100000, 1500000), "Png")
                });

            Response<CreateOwnerResponse> rs;
            foreach (var item in owners)
            {
                rs = ownerService.InsertAsync(item).Result;
            }

        }

        [Test]
        public void Create_Owner_ReturnIdOwner()
        {
            Int64 maxIdOwner = ownerService.GetAll().Result.Select(s => s.IdOwner).Max();

            var owner = new CreateOwnerRequest
            {
                Name = Faker.Name.FullName(),
                Address = Faker.Address.StreetAddress(),
                Birthday = Faker.Identification.DateOfBirth(),
                Photo = generator.Run(rnd.Next(100000, 1500000), "Png")
            };
            var rs = ownerService.InsertAsync(owner).Result;

            Assert.Greater(rs.Data.IdOwner, maxIdOwner);
            Assert.Pass();

        }

    }
}
