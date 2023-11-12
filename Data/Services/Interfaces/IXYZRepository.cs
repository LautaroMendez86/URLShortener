﻿using URLShortener.Entities;
using URLShortener.Models.DTO.XYZ;

namespace URLShortener.Data.Service.Interfaces
{
    public interface IXYZRepository
    {
        public List<XYZ> Index();
        public List<XYZ> GetOne(int id);
        public XYZ GetOneByHash(string hash);
        public void UpdateVisit(XYZ xyz);
        public void Create(XYZForCreationDto dto);
        public void Update(XYZForUpdateDTO dto);
        public void Delete(int id);
    }
}
