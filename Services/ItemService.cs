using Jewellery_Shop.Models;
using Jewellery_Shop.Models.DTOs;
using Jewellery_Shop.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jewellery_Shop.Services
{
    public class ItemService
    {
        private JewelleryShopDbContext dbContext;

        public ItemService(JewelleryShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<ItemDTO> GetAll()
        {
            return dbContext.Items
                .Include(item => item.User)
                .Select(item => ToDto(item))
                .ToList();
        }

        public void Create(Item item, User user)
        {
            item.User = user;

            dbContext.Items.Add(item);
            dbContext.SaveChanges();
        }

        public Item GetById(int id)
        {
            return dbContext.Items.FirstOrDefault(x => x.Id == id);
        }

        public void Edit(Item item)
        {
            Item dbItem = GetById(item.Id);

            dbItem.Name = item.Name;
            dbItem.Price = item.Price;
            dbItem.Id = item.Id;
            dbItem.Type = item.Type;
            dbItem.QuantityAvailable = item.QuantityAvailable;

            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Item dbItem = GetById(id);
            dbContext.Items.Remove(dbItem);
            dbContext.SaveChanges();
        }

        private static ItemDTO ToDto(Item item)
        {
            ItemDTO itemDTO = new ItemDTO();

            itemDTO.Id = item.Id;
            itemDTO.Name = item.Name;
            itemDTO.Price = item.Price;
            itemDTO.Type = item.Type;
            itemDTO.QuantityAvailable = item.QuantityAvailable;
            itemDTO.CreatedBy = $"{item.User.FirstName} {item.User.LastName}";

            return itemDTO;
        }
    }
}
