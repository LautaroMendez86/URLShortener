using URLShortener.Entities;
using URLShortener.Models.DTO.Category;

namespace URLShortener.Data.Service.Interfaces
{
    public interface ICategoryRepository
    {
        public List<Category> Index();
        public Category GetOneByID(int id);
        public bool IsExist(int id);
        public void Create(CategoryForCreation dto);
        public void Update(CategoryForUpdateDTO dto);
        public void Delete(int id);
        
    }
}
