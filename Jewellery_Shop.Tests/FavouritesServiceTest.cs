using Jewellery_Shop.Models;
using Jewellery_Shop.Models.DTOs;
using Jewellery_Shop.Models.Entities;
using Jewellery_Shop.Services;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Jewellery_Shop.tests
{
    class favouritesServiceTest
    {
        static private FavouritesService favouritesService;
        private JewelleryShopDbContext context;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<JewelleryShopDbContext>().UseInMemoryDatabase("TestDb").Options;

            this.context = new JewelleryShopDbContext(options);
            favouritesService = new FavouritesService(this.context);
        }

        [TearDown]
        public void TearDown()
        {
            this.context.Database.EnsureDeleted();
        }

        [Test]
        public void TestGetAll()

        {
            Favourites Favourites = CreateFavourites(1, "Favourites Favourites");
            Favourites Favourites2 = CreateFavourites(2, "Favourites Favourites 2");
            Favourites Favourites3 = CreateFavourites(3, "Favourites Favourites 3");

            User user = new User();
            var mc = new FavouritesService(context);
            mc.Create(Favourites, user);
            mc.Create(Favourites2, user);
            mc.Create(Favourites3, user);

            List<FavouritesDTO> FavouritesDTOs = mc.GetAll();

            Assert.AreEqual(3, FavouritesDTOs.Count);
            Assert.AreEqual("Favourites Favourites", FavouritesDTOs[0].Item);
        }

        [Test]
        public void TestGetById()
        {
            var mc = new FavouritesService(context);
            Favourites Favourites = CreateFavourites(1, "Favourites Favourites");
            User user = new User();
            mc.Create(Favourites, user);

            Favourites dbFavourites = mc.GetById(1);

            Assert.AreEqual(dbFavourites.Item, "Favourites Favourites");
        }

        [Test]
        public void TestCreate()
        {
            var mc = new FavouritesService(context);
            Favourites Favourites = CreateFavourites(1, "Favourites Favourites");
            User user = new User();

            mc.Create(Favourites, user);

            Favourites dbFavourites = context.Favourites.FirstOrDefault();

            Assert.NotNull(dbFavourites);
        }

        [Test]
        public void TestEdit()
        {
            FavouritesService postService = new FavouritesService(this.context);
            var mc = new FavouritesService(context);
            Favourites Favourites = new Favourites();
            Favourites.Id = 1;
            Favourites.Item = "Favourites Item";
            User user = new User();



            mc.Create(Favourites, user);

            Favourites editFavourites = new Favourites();

            editFavourites.Id = 1;
            editFavourites.Item = "asd";

            postService.Edit(editFavourites);

            Favourites dbFavourites = context.Favourites.FirstOrDefault(x => x.Id == 1);

            Assert.NotNull(dbFavourites);
            Assert.AreEqual(dbFavourites.Item, "asd");
        }

        [Test]
        public void TestDelete()
        {
            FavouritesService postService = new FavouritesService(this.context);
            var mc = new FavouritesService(context);
            Favourites Favourites = new Favourites();
            Favourites.Id = 1;
            Favourites.Item = "Favourites Item";
            User user = new User();

            mc.Create(Favourites, user);

            mc.Delete(1);

            Favourites dbFavourites = context.Favourites.FirstOrDefault(x => x.Id == 1);
            Assert.Null(dbFavourites);
        }

        private Favourites CreateFavourites(int id, string name)
        {
            Favourites Favourites = new Favourites();
            Favourites.Id = id;
            Favourites. Item = name;

            return Favourites;
        }
    }
}

