using System.Collections.Generic;
using Funparty.Api.Domain.Entities;

namespace Funparty.Api.Application.Dtos
{
    public class MascotDto
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public decimal RentPrice { get; set; }
        public decimal SalePrice { get; set; }
        public ICollection<MascotPhotoDto> MascotPhotos { get; set; }

        public MascotDto()
        {
            MascotPhotos = new List<MascotPhotoDto>();
        }
    }
}
