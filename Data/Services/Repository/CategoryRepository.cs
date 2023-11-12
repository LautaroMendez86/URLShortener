using Microsoft.EntityFrameworkCore;
using URLShortener.Data.Service.Interfaces;
using URLShortener.Entities;
using URLShortener.Models.DTO.Category;

namespace URLShortener.Data.Service.Repository
{
    public class CategoryRepository : ICategoryRepository
    {

        private readonly UrlShortenerContext _context;
        public CategoryRepository(UrlShortenerContext context)
        { 
            _context = context;
        }

        public List<Category> Index()
        {
            return _context.Categories.Include(x => x.XYZs).ToList();
        }

        public void Create(CategoryForCreation dto)
        {
            Category category = new Category
            {
                Name = dto.Name
            };

            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void Update(CategoryForUpdateDTO dto)
        {
            Category category = new Category
            {
                ID = dto.ID,
                Name = dto.Name
            };

            _context.Update(category);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Category category = GetOneByID(id);
            _context.Remove(category);
            _context.SaveChanges();
        }

        public Category GetOneByID(int id)
        {
            return _context.Categories.Single(category => category.ID == id);
        }

        public bool IsExist(int id)
        {
            return _context.Categories.Any(category => category.ID == id);
        }
    }
}
