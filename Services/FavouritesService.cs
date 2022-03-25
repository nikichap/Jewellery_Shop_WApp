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
    public class FavouritesService
    {
        private JewelleryShopDbContext dbContext;

        public FavouritesService(JewelleryShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<FavouritesDTO> GetAll()
        {
            return dbContext.Favourites
                .Include(Favourites => Favourites.User)
                .Select(Favourites => ToDto(Favourites))
                .ToList();
        }

        public void Create(Favourites favourites, User user)
        {
            favourites.User = user;

            dbContext.Favourites.Add(favourites);
            dbContext.SaveChanges();
        }

        public Favourites GetById(int id)
        {
            return dbContext.Favourites.FirstOrDefault(x => x.Id == id);
        }

        public void Edit(Favourites Favourites)
        {
            Favourites dbFavourites = GetById(Favourites.Id);

            dbFavourites.Id = Favourites.Id;
            dbFavourites.Item = Favourites.Item;
            dbFavourites.User = Favourites.User;


            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Favourites dbFavourites = GetById(id);
            dbContext.Favourites.Remove(dbFavourites);
            dbContext.SaveChanges();
        }

        private static FavouritesDTO ToDto(Favourites favourites)
        {
            FavouritesDTO FavouritesDTO = new FavouritesDTO();

            FavouritesDTO.Id = favourites.Id;
            FavouritesDTO.Item = favourites.Item;
            FavouritesDTO.CreatedBy = $"{favourites.User.FirstName} {favourites.User.LastName}";
            FavouritesDTO.UserEmail = favourites.User.Email;

            return FavouritesDTO;
        }
    }
}

