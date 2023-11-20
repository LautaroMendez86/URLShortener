using URLShortener.Entities;
using URLShortener.Models.DTO.XYZ;

namespace URLShortener.Data.Service.Interfaces
{
    public interface IXYZRepository
    {
        public List<XYZ> Index(int id);
        public List<XYZ> GetOne(int id);
        public XYZ GetOneByHash(string hash);
        public void UpdateVisit(XYZ xyz);
        public void Create(XYZForCreationDto dto, int userId);
        public void Update(XYZForUpdateDTO dto, int userId);
        public void Delete(int id);
    }
}
