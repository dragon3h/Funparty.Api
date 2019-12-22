using System.Collections.Generic;
using System.Threading.Tasks;
using Funparty.Api.Domain.Entities;

namespace Funparty.Api.Application.Interfaces
{
    public interface IMascotRepository
    {
        Task<ICollection<Mascot>> GetAllMascots();
        Task<Mascot> GetMascotById(int id);
        Task<Mascot> CreateMascot(Mascot mascot);
        Task<bool> MascotExist(int id);
        Task<int> DeleteMascot(int id);
    }
}