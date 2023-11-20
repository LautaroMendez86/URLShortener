using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Xml.Linq;
using URLShortener.Data.Service.Implementations;
using URLShortener.Data.Service.Interfaces;
using URLShortener.Entities;
using URLShortener.Models.DTO.XYZ;

namespace URLShortener.Data.Service.Repository
{
    public class XYZRepository : IXYZRepository
    {

        private readonly ICategoryRepository _categoryRepository;
        private readonly UrlShortenerContext _context;
        private readonly XYZService _xyzService;
        public XYZRepository(UrlShortenerContext context, XYZService xyzService, ICategoryRepository categoryRepository)
        {
            _context = context;
            _xyzService = xyzService;
            _categoryRepository = categoryRepository;
        }

        public List<XYZ> Index(int userId)
        {
            return _context.XYZs.Include(xyz => xyz.Category).Where(xyz => xyz.UserID == userId).ToList();
        }

        public List<XYZ> GetOne(int id)
        {
            return _context.XYZs.Include(xyz => xyz.Category).Where(xyz => xyz.ID == id).ToList();
        }

        public void Create(XYZForCreationDto dto, int userId)
        {

            CreateValidations(dto);

            XYZ xyz = new()
            {
                URL = dto.URL,
                Hash = _xyzService.HashGenerate(dto.URL),
                Visit = 0,
                CategoryID = dto.CategoryID,
                UserID = userId
            };

            _context.XYZs.Add(xyz);
            _context.SaveChanges();

        }

        public void Update(XYZForUpdateDTO dto, int userId)
        {
            UpdateValidations(dto);

            XYZ xyz = new()
            {
                ID = dto.ID,
                URL = dto.URL,
                Hash = _xyzService.HashGenerate(dto.URL),
                Visit = 0,
                CategoryID = dto.CategoryID,
                UserID = userId
            };

            _context.XYZs.Update(xyz);
            _context.SaveChanges();

        }

        public void Delete(int id)
        {
            XYZ XYZ = GetOneByID(id);
            _context.XYZs.Remove(XYZ);
            _context.SaveChanges();
        }

        public XYZ GetOneByHash(string hash)
        {
            return _context.XYZs.Single(x => x.Hash == hash);
        }

        public XYZ GetOneByID(int id)
        {
            return _context.XYZs.Single(x => x.ID == id);
        }

        public void UpdateVisit(XYZ xyz)
        {
            xyz.Visit++;
            _context.XYZs.Update(xyz);
            _context.SaveChanges();
        }

        public bool IsExistURL(string url)
        {
            return _context.XYZs.Any(x => x.URL == url);
        }

        public bool IsExistID(int id)
        {
            return _context.XYZs.Any(x => x.ID == id);
        }

        public void CreateValidations(XYZForCreationDto dto)
        {
            if (IsExistURL(dto.URL))
            {
                throw new Exception("Ya existe un hash para esa URL");
            }

            if (!_categoryRepository.IsExist(dto.CategoryID))
            {
                throw new Exception("La categoria no existe");
            }

        }
        public void UpdateValidations(XYZForUpdateDTO dto)
        {
            if (!IsExistID(dto.ID))
            {
                throw new Exception("No existe ningun URL con el ID ingresado");
            }

            if (!_categoryRepository.IsExist(dto.CategoryID))
            {
                throw new Exception("La categoria no existe");
            }

        }

    }
}
