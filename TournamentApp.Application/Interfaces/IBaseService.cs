using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentApp.Application.Interfaces
{
    public interface IBaseService<TContextObject,TCreateDTO, TGetDTO, TUpdateDTO>
    {
        Task<int> CreateAsync(TCreateDTO dto);
        Task UpdateAsync(TUpdateDTO dto, int id);
        Task RemoveAsync(int id);
        Task<TContextObject> GetAsync(int id);
        Task<TGetDTO> GetDTOAsync(int id);

    }
}
