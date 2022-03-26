//using Jewellery_Shop.Models;
//using Jewellery_Shop.Models.DTOs;
//using Jewellery_Shop.Models.Entities;
//using Jewellery_Shop.Services;
//using Microsoft.EntityFrameworkCore;
//using NUnit.Framework;
//using System.Collections.Generic;
//using System.Linq;

//namespace Jewellery_Shop.tests
//{
//    public class FavouritesServiceTests
//    {
//        static private ItemService itemService;
//        private JewelleryShopDbContext context;

//        [SetUp]
//        public void Setup()
//        {
//            var options = new DbContextOptionsBuilder<JewelleryShopDbContext>().UseInMemoryDatabase("TestDb").Options;

//            this.context = new JewelleryShopDbContext(options);
//            itemService = new ItemService(this.context);
//        }

//        [TearDown]
//        public void TearDown()
//        {
//        this.context.Database.EnsureDeleted();
//        }

//        [Test]
//        public void TestGetAll()

//        {
//            Item Item = CreateItem(1, "Item Name");
//            Item Item2 = CreateItem(2, "Item Name 2");
//            Item Item3 = CreateItem(3, "Item Name 3");

//            User user = new User();
//            var mc = new ItemService(context);
//            mc.Create(Item, user);
//            mc.Create(Item2, user);
//            mc.Create(Item3, user);

//            List<ItemDTO> ItemDTOs = mc.GetAll();

//            Assert.AreEqual(3, ItemDTOs.Count);
//            Assert.AreEqual("Item Name", ItemDTOs[0].Name);
//        }

//        [Test]
//        public void TestGetById()
//        {
//            var mc = new ItemService(context);
//            Item Item = CreateItem(1, "Item Name");
//            User user = new User();
//            mc.Create(Item, user);

//            Item dbItem = mc.GetById(1);

//            Assert.AreEqual(dbItem.Name, "Item Name");
//        }

//        [Test]
//        public void TestCreate()
//        {
//            var mc = new ItemService(context);
//            Item Item = CreateItem(1, "Item Name");
//            User user = new User();

//            mc.Create(Item, user);

//            Item dbItem = context.Items.FirstOrDefault();

//            Assert.NotNull(dbItem);
//        }

//        [Test]
//        public void TestEdit()
//        {
//            ItemService postService = new ItemService(this.context);
//            var mc = new ItemService(context);
//            Item Item = new Item();
//            Item.Id = 1;
//            Item.Name = "Item Name";
//            User user = new User();

           

//            mc.Create(Item, user);

//            Item editItem = new Item();

//            editItem.Id = 1;
//            editItem.Name = "asd";

//            postService.Edit(editItem);

//            Item dbItem = context.Items.FirstOrDefault(x => x.Id == 1);

//            Assert.NotNull(dbItem);
//            Assert.AreEqual(dbItem.Name, "asd");
//        }

//        [Test]
//        public void TestDelete()
//        {
//            ItemService postService = new ItemService(this.context);
//            var mc = new ItemService(context);
//            Item Item = new Item();
//            Item.Id = 1;
//            Item.Name = "Item Name";
//            User user = new User();

//            mc.Create(Item, user);

//            mc.Delete(1);

//            Item dbItem = context.Items.FirstOrDefault(x => x.Id == 1);
//            Assert.Null(dbItem);
//        }

//        private Item CreateItem(int id, string name)
//        {
//            Item Item = new Item();
//            Item.Id = id;
//            Item.Name = name;

//            return Item;
//        }
//    }
//}