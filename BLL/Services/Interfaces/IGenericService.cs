using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS_BLL.Services.Interfaces
{
   public interface IGenericService<TDto, TEntity> where TDto : class where TEntity : class
    {
        public Task<TDto> AddAsync(TDto item);
        public Task<TDto> GetByIdAsync(Guid id);
        public Task<List<TDto>> GetListAsync();
        public void Delete(Guid id);
        public TDto Update(TDto item);
    }
}
