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
    public class OrderService
    {
        private JewelleryShopDbContext dbContext;

        public OrderService(JewelleryShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<OrderDTO> GetAll()
        {
            return dbContext.Orders
                .Include(Order => Order.User)
                .Select(Order => ToDto(Order))
                .ToList();
        }

        public void Create(Order Order, User user)
        {
            Order.User = user;

            dbContext.Orders.Add(Order);
            dbContext.SaveChanges();
        }

        public Order GetById(int id)
        {
            return dbContext.Orders.FirstOrDefault(x => x.Id == id);
        }

        public void Edit(Order Order)
        {
            Order dbOrder = GetById(Order.Id);

            dbOrder.Id = Order.Id;
            dbOrder.QuantityAvailable = Order.QuantityAvailable;
            dbOrder.User = Order.User;
            dbOrder.UserId = Order.UserId;
            dbOrder.OrderDate = Order.OrderDate;
            dbOrder.Price = Order.Price;
            

            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Order dbOrder = GetById(id);
            dbContext.Orders.Remove(dbOrder);
            dbContext.SaveChanges();
        }

        private static OrderDTO ToDto(Order Order)
        {
            OrderDTO OrderDTO = new OrderDTO();

            OrderDTO.Id = Order.Id;
            OrderDTO.OrderedOn = Order.OrderDate;
            OrderDTO.FullPrice = Order.Price;
            OrderDTO.CreatedBy = $"{Order.User.FirstName} {Order.User.LastName}";


            return OrderDTO;
        }
    }
}
