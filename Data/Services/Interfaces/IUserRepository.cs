using URLShortener.Entities;
using URLShortener.Models.DTO.Auth;
using URLShortener.Models.DTO.User;

namespace URLShortener.Data.Services.Interfaces
{
    public interface IUserRepository
    {
        public List<User> Index();
        public void Create(UserToCreateDto userDto);
        public void Update(UserToUpdateDto userDto);
        public void Delete(int id);
        public User? GetById(int userId);
        public User? ValidateUser(AuthDto authRequestBody);
    }
}
