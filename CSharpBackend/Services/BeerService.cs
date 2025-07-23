using AutoMapper;
using CSharpBackend.DTOs;
using CSharpBackend.Models;
using CSharpBackend.Repository;
using Microsoft.EntityFrameworkCore;

namespace CSharpBackend.Services
{
    public class BeerService : ICommonService<BeerDto, BeerInsertDto, BeerUpdateDto>
    {
        private IRepository<Beer> _beerRepository;
        private IMapper _mapper;
        public List<string> Errors { get; }
        public BeerService(
            IRepository<Beer> beerRepository,
            IMapper mapper)
        {
            _beerRepository = beerRepository;
            _mapper = mapper;
            Errors = new List<string>();
        }

        public async Task<IEnumerable<BeerDto>> Get()
        {
            var beers = await _beerRepository.Get();

            return beers.Select(b => _mapper.Map<BeerDto>(b)); // Map Model back to DTO
        }

        public async Task<BeerDto> GetById(int id)
        {
            var beer = await _beerRepository.GetById(id);

            if (beer != null)
            {
                var beerDto = _mapper.Map<BeerDto>(beer); // Map Model back to DTO

                return beerDto;
            }

            return null;
        }

        public async Task<BeerDto> Add(BeerInsertDto beerInsertDto)
        {
            var beer = _mapper.Map<Beer>(beerInsertDto); // Map DTO to Model

            await _beerRepository.Add(beer); // Add the new beer to the context
            await _beerRepository.Save(); // Save changes to the database

            var beerDto = _mapper.Map<BeerDto>(beer); // Map Model back to DTO

            return beerDto;
        }

        public async Task<BeerDto> Update(int id, BeerUpdateDto beerUpdateDto)
        {
            var beer = await _beerRepository.GetById(id);

            if (beer != null)
            {
                beer.Name = beerUpdateDto.Name;
                beer.Alcohol = beerUpdateDto.Alcohol;
                beer.BrandID = beerUpdateDto.BrandId;

                _beerRepository.Update(beer);
                await _beerRepository.Save(); // Save changes to the database

                var beerDto = _mapper.Map<BeerDto>(beer); // Map Model back to DTO

                return beerDto;
            }

            return null;
        }

        public async Task<BeerDto> Delete(int id)
        {
            var beer = await _beerRepository.GetById(id);

            if (beer != null)
            {
                _beerRepository.Delete(beer); // One way to remove
                //_context.Remove(beer); // Another way to remove
                await _beerRepository.Save();

                var beerDto = _mapper.Map<BeerDto>(beer); // Map Model back to DTO

                //var beerDto = new BeerDto
                //{
                //    Id = beer.BeerID,
                //    Name = beer.Name,
                //    Alcohol = beer.Alcohol,
                //    BrandId = beer.BrandID,
                //};

                return beerDto;
            }

            return null;
        }

        public bool Validate(BeerInsertDto beerInsertDto)
        {
            if (_beerRepository.Search(b => b.Name == beerInsertDto.Name).Count() > 0)
            {
                Errors.Add("A beer cannot have the same name as one that already exists.");
                return false;
            }
            return true;
        }

        public bool Validate(BeerUpdateDto beerUpdateDto)
        {
            if (_beerRepository.Search(b => b.Name == beerUpdateDto.Name && beerUpdateDto.Id != b.BeerID).Count() > 0)
            {
                Errors.Add("A beer cannot have the same name as one that already exists.");
                return false;
            }
            return true;
        }
    }
}
