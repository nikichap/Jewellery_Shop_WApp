using Jewellery_Shop.Models;
using Jewellery_Shop.Models.DTOs;
using Jewellery_Shop.Models.Entities;
using Jewellery_Shop.Services;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewellery_Shop.Tests
{
    public class FavouritesServiceTest
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
            Favourites favourites = CreateFavourites(1, "Favourites Favourites");
            Favourites favourites2 = CreateFavourites(2, "Favourites Favourites 2");
            Favourites favourites3 = CreateFavourites(3, "Favourites Favourites 3");

            User user = new User();
            var mc = new FavouritesService(context);
            mc.Create(favourites, user);
            mc.Create(favourites2, user);
            mc.Create(favourites3, user);

            List<FavouritesDTO> FavouritesDTOs = mc.GetAll();

            Assert.AreEqual(3, FavouritesDTOs.Count);
            Assert.AreEqual("Favourites Favourites", FavouritesDTOs[0].Item);
        }

        [Test]
        public void TestGetById()
        {
            var mc = new FavouritesService(context);
            Favourites favourites = CreateFavourites(1, "Favourites Favourites");
            User user = new User();
            mc.Create(favourites, user);

            Favourites dbFavourites = mc.GetById(1);

            Assert.AreEqual(dbFavourites.Item, "Favourites Favourites");
        }

        [Test]
        public void TestCreate()
        {
            var mc = new FavouritesService(context);
            Favourites favourites = CreateFavourites(1, "Favourites Favourites");
            User user = new User();

            mc.Create(favourites, user);

            Favourites dbFavourites = context.Favourites.FirstOrDefault();

            Assert.NotNull(dbFavourites);
        }

        [Test]
        public void TestEdit()
        {
            FavouritesService postService = new FavouritesService(this.context);
            Favourites favourites = new Favourites();
            favourites.Id = 1;
            favourites.Item = "Favourites Item";
            User user = new User();

            favouritesService.Create(favourites, user);

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
            Favourites favourites = new Favourites();
            favourites.Id = 1;
            favourites.Item = "Favourites Item";
            User user = new User();

            mc.Create(favourites, user);

            mc.Delete(1);

            Favourites dbFavourites = context.Favourites.FirstOrDefault(x => x.Id == 1);
            Assert.Null(dbFavourites);
        }

        private Favourites CreateFavourites(int id, string name)
        {
            Favourites favourites = new Favourites();
            favourites.Id = id;
            favourites.Item = name;

            return favourites;
        }
    }
}
