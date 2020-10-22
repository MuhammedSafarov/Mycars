using Mycars.Dtos;
using Mycars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mycars.Data
{
    public class FeaturesRepo : IMycarsRepo
    {
        public readonly MycarsContext _context;

        public FeaturesRepo(MycarsContext context)
        {
            _context = context;            
        }

        public void CreateBrand(Brands cmd)
        {
            throw new NotImplementedException();
        }

        public void CreateFeature(Features cmd)
        {
            throw new NotImplementedException();
        }

        public void CreateFeature(Brands brandFeature)
        {
            throw new NotImplementedException();
        }

        public void DeleteBrand(Brands cmd)
        {
            throw new NotImplementedException();
        }

        public void DeleteFeature(Features cmd)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Brands> GetAllBrands()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Features> GetAllFeatures()
        {
            throw new NotImplementedException();
        }

        public Brands GetBrandById(int id)
        {
            throw new NotImplementedException();
        }

        public Features GetFeatureById(int id)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateBrand(Brands cmd)
        {
            throw new NotImplementedException();
        }








        /*  public async Task<IEnumerable<BrandReadDto>> ShowBooks()
          {
              return await _context.Features.Join
              (
                  _context.Brands,
                   category => category.Id,
                   final => final.Features.Id,

                  (model, brand) => new BrandReadDto
                  {
                      brand = brand.brand,
                      year = brand.year,
                      model = brand.model,
                      Id =brand.Id,
                      Region = brand.Region,
                      Colour = brand.Colour,
                      AZN =brand.AZN

                  }

              ).ToListAsync();

          }
  */
        public void UpdateFeature(Features cmd)
        {
            throw new NotImplementedException();
        }
    }
}
