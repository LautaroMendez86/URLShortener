using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using URLShortener.Data.Services.Interfaces;
using URLShortener.Entities;
using URLShortener.Models.DTO.Auth;
using URLShortener.Models.DTO.User;

namespace URLShortener.Data.Services.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UrlShortenerContext _context;
        public UserRepository(UrlShortenerContext context)
        {
            _context = context;
        }

        public List<User> Index()
        {
            return _context.Users.ToList();
        }

        public void Create(UserToCreateDto userDto)
        {

            User user = new()
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Password = userDto.Password,
                UserName = userDto.UserName
            };

            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Update(UserToUpdateDto userDto)
        {
            User user = new()
            {
                ID = userDto.ID,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Password = userDto.Password,
                UserName = userDto.UserName
            };

            _context.Update(user);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Remove(_context.Users.Single(u => u.ID == id));
            _context.SaveChanges();
        }

        public User? GetById(int userId)
        {
            return _context.Users.Include(u => u.XYZs).SingleOrDefault(u => u.ID == userId);
        }

        public User? ValidateUser(AuthDto authRequestBody)
        { 
            return _context.Users.FirstOrDefault(p => p.UserName == authRequestBody.UserName && p.Password == authRequestBody.Password);
        }

    }
}
