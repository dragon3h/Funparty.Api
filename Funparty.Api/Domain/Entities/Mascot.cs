using System;
using Microsoft.AspNetCore.DataProtection;

namespace Funparty.Api.Domain.Entities
{
    public class Mascot
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Name { get; set; }
        public decimal RentPrice { get; set; }
        public decimal SalePrice { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}