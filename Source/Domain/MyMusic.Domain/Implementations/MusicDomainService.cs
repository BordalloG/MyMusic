using MyMusic.Domain.Exceptions;
using MyMusic.Domain.Interfaces.Domain;
using MyMusic.Domain.Interfaces.Repository;
using MyMusic.Domain.Models;
using MyMusic.Domain.Models.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMusic.Domain.Implementations
{
    public class MusicDomainService : DomainServiceBase<Music>, IMusicDomainService
    {
        private readonly IMusicRepository _repository;
        public MusicDomainService(IMusicRepository entityRepository) : base(entityRepository)
        {
            _repository = entityRepository;
        }

        public async Task<List<Music>> GetAllAsync(MusicFilter filter)
        {
            var response = await base.GetAllAsync();

            if (!String.IsNullOrWhiteSpace(filter.Text))
                response = response.Where(x => x.Title.Contains(filter.Text) || x.Author.Contains(filter.Text)).ToList();

            if (!response.Any())
                throw new NoContentException("Nenhum dado encontrado.");

            switch (filter.SortOrder.ToUpper())
            {
                case "TITLE":
                    response = response.OrderBy(r => r.Title).ToList();
                    break;
                case "AUTHOR":
                    response = response.OrderBy(r => r.Author).ToList();
                    break;
                case "DURATION":
                    response = response.OrderBy(r => r.Duration).ToList();
                    break;
                default:
                    response = response.OrderBy(r => r.Title).ToList();
                    break;
            }

            if (!response.Any())
                throw new NoContentException("Nenhum dado encontrado.");

            return response;
        }

        public override async Task<Music> InsertAsync(Music entity)
        {
            if (!entity.IsValid)
                throw new BadRequestException(entity.ValidationResult.ToString());
            return await base.InsertAsync(entity);

        }

        public async Task<List<Music>> InsertRangeAsync(List<Music> domainMusicList)
        {
            var validMusics = domainMusicList.Where(x => x.IsValid);
            if (!validMusics.Any())
                throw new BadRequestException("Nenhuma música está valida.");
            await _repository.InsertRangeAsync(validMusics.ToList());
            await _repository.SaveChangesAsync();
            return validMusics.ToList();
        }

        public override async Task<Music> UpdateAsync(Music entity, int entityId)
        {
            if (!entity.IsValid)
                throw new BadRequestException(entity.ValidationResult.ToString());
            await base.UpdateAsync(entity, entityId);

            return entity;
        }
    }
}
