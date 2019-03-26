using MyMusic.Domain.Interfaces.Domain;
using MyMusic.Domain.Interfaces.Repository;
using MyMusic.Domain.Models;
using MyMusic.Domain.Models.Filter;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace MyMusic.Domain.Implementations
{
    public class MusicDomainService : DomainServiceBase<Music>, IMusicDomainService
    {
        public MusicDomainService(IMusicRepository entityRepository) : base(entityRepository)
        {
    }

        public async Task<List<Music>> GetAllAsync(MusicFilter filter)
        {
            var response = await base.GetAllAsync();

            if (!String.IsNullOrWhiteSpace(filter.Text))
                response = response.Where(x => x.Title.Contains(filter.Text) || x.Author.Contains(filter.Text)).ToList();

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
           
            return response;
        }

        public override async Task<Music> InsertAsync(Music entity)
        {
            if (!entity.IsValid)
                throw new Exception(entity.ValidationResult.ToString());
            return await base.InsertAsync(entity);

        }

    }
}
