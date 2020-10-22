using System.Collections.Generic;
using AutoMapper;
using Mycars.Data;
using Mycars.Dtos;
using Mycars.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;


namespace Mycars.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {

        private readonly MycarsContext _db;
        private readonly IMycarsRepo _repository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly int currentUserId;

        public BrandsController(IMycarsRepo repository, IMapper mapper, MycarsContext db, IHttpContextAccessor _httpContextAccessor)
        {
            _repository = repository;
            _mapper = mapper;
            _db = db;

        }



        [Authorize(Policy = Policies.User)]

        [HttpGet("search/modelVSbrand")]
        public async Task<List<Brands>> Index(string Brandsearch)
        {
            // View data["Getbrandsdetails"] = Brandsearch;
            var brandsquery = from x in _db.Brands select x;
            if (!String.IsNullOrEmpty(Brandsearch))
            {
                brandsquery = brandsquery.Where(x => x.model.Contains(Brandsearch) || x.brand.Contains(Brandsearch));
            }
            return await brandsquery.AsNoTracking().ToListAsync();
        }




        [Authorize(Policy = Policies.User)]
        //Filter

        [HttpGet("filter/brand")]
        public async Task<List<Brands>> Index(string sortOrder, string searchString)
        {

            var cars = from s in _db.Brands select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                cars = cars.Where(s => s.brand.Contains(searchString)
                                       || s.model.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "brand":
                    cars = cars.OrderByDescending(s => s.brand);
                    break;

                case "model":
                    cars = cars.OrderBy(s => s.model);
                    break;

                default:
                    cars = cars.OrderBy(s => s.year);
                    break;
            }
            return await cars.AsNoTracking().ToListAsync();
        }

        private IActionResult View(List<Brands> displaydata)
        {
            throw new NotImplementedException();
        }




        [Authorize(Policy = Policies.Admin)]   //GET api/brands 

        [HttpGet("/models")]

        public ActionResult<IEnumerable<BrandReadDto>> GetAllBrands()
        {
            var brandItems = _repository.GetAllBrands();

            return Ok(_mapper.Map<IEnumerable<BrandReadDto>>(brandItems));
        }




        [Authorize(Policy = Policies.Admin)]   //GET api/brands/{id}

        [HttpGet("{id}", Name = "GetBrandById")]
        public ActionResult<BrandReadDto> GetBrandById(int id)
        {
            var brandItem = _repository.GetBrandById(id);
            if (brandItem != null)
            {
                return Ok(_mapper.Map<BrandReadDto>(brandItem));
            }
            return NotFound();
        }





        [Authorize(Policy = Policies.Admin)]   //POST api/brands

        [HttpPost]
        public ActionResult<BrandReadDto> CreateBrand(BrandCreateDto brandCreateDto)
        {
            var brandModel = _mapper.Map<Brands>(brandCreateDto);
            _repository.CreateBrand(brandModel);
            _repository.SaveChanges();

            var brandReadDto = _mapper.Map<BrandReadDto>(brandModel);

            return CreatedAtRoute(nameof(GetBrandById), new { Id = brandReadDto.Id }, brandReadDto);
        }





        [Authorize(Policy = Policies.Admin)]   //PUT api/brands/{id}

        [HttpPut("{id}")]
        public ActionResult UpdateBrand(int id, BrandUpdateDto brandUpdateDto)
        {
            var brandModelFromRepo = _repository.GetBrandById(id);
            if (brandModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(brandUpdateDto, brandModelFromRepo);

            _repository.UpdateBrand(brandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }





        [Authorize(Policy = Policies.Admin)]   //PATCH api/brands/{id}

        [HttpPatch("{id}")]
        public ActionResult PartialBrandUpdate(int id, JsonPatchDocument<BrandUpdateDto> patchDoc)
        {
            var brandModelFromRepo = _repository.GetBrandById(id);
            if (brandModelFromRepo == null)
            {
                return NotFound();
            }

            var brandToPatch = _mapper.Map<BrandUpdateDto>(brandModelFromRepo);
            patchDoc.ApplyTo(brandToPatch, ModelState);

            if (!TryValidateModel(brandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(brandToPatch, brandModelFromRepo);

            _repository.UpdateBrand(brandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }




        [Authorize(Policy = Policies.Admin)]   //DELETE api/brands/{id}

        [HttpDelete("{id}")]
        public ActionResult DeleteBrand(int id)
        {
            var brandModelFromRepo = _repository.GetBrandById(id);
            if (brandModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteBrand(brandModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }



        [Authorize(Policy = Policies.Admin)]

        [HttpGet("/features")]

        public ActionResult<IEnumerable<FeatureReadDto>> GetAllFeatures()
        {
            var brandItems = _repository.GetAllFeatures();

            return Ok(_mapper.Map<IEnumerable<FeatureReadDto>>(brandItems));
        }




        [Authorize(Policy = Policies.User)]

        [HttpGet("{id}", Name = "GetFeatureById")]  //get/api/features {id}
        public ActionResult<BrandReadDto> GetFeatureById(int id)
        {
            var brandItem = _repository.GetFeatureById(id);
            if (brandItem != null)
            {
                return Ok(value: _mapper.Map<FeatureReadDto>(brandItem));
            }
            return NotFound();
        }



        [Authorize(Policy = Policies.Admin)]

        [HttpPost()]
        public ActionResult<FeatureReadDto> CreateFeature(FeatureCreateDto featureCreateDto)
        {
            var brandFeature = _mapper.Map<Features>(featureCreateDto);
            _repository.CreateFeature(brandFeature);
            _repository.SaveChanges();

            var featureReadDto = _mapper.Map<FeatureReadDto>(brandFeature);

            return CreatedAtRoute(nameof(GetFeatureById), new { Id = featureReadDto.Id }, featureReadDto);
        }

        /*
        [HttpGet]
        public IEnumerable<Brands> GetBrands()
        {
            return _context.Brands;
        }

        [HttpGet("{id}", Name = "GetBrand")]
        public IActionResult GetBrands([FromRoute] int id)
        {
            Brands brand = _context.Brands.Single(m => m.BrandId == id);

            return Ok(interview);
        }
        */



        [Authorize (Policy = Policies.Admin)]

        [HttpGet("/JoinTables")]
        public IEnumerable<Brands> GetBrands()
         {
            return (IEnumerable<Brands>)(from a in _db.Features
                   join p in _db.Brands on a.Id equals p.Id 
                   select new
                   {
                       brand_id = a.Id,
                       features_id = p.Id
                   });
         }
        

    }
}