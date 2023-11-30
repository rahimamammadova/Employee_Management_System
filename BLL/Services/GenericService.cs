using AutoMapper;
using EMS_BLL.Exceptions;
using EMS_BLL.Helper;
using EMS_BLL.Services.Interfaces;
using EMS_DAL.Dtos;
using EMS_DAL.Models;
using EMS_DAL.Repository.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS_BLL.Services
{
    public class GenericService<TDto, TEntity> : IGenericService<TDto, TEntity> where TDto : class where TEntity : class
    {
        private readonly IGenericRepository<TEntity> _genericRepository;
        protected readonly IMapper _mapper;
        private readonly ILogger<GenericService<TDto, TEntity>> _logger;

        public GenericService(IGenericRepository<TEntity> genericRepository, IMapper mapper, ILogger<GenericService<TDto, TEntity>> logger)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<TDto> AddAsync(TDto item)
        {
            try
            {
                TEntity entity = _mapper.Map<TEntity>(item);
                entity.SetValue<TEntity>("CreatedDate", DateTime.Now);
                TEntity dbEntity = await _genericRepository.AddAsync(entity);
                return _mapper.Map<TDto>(dbEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogError(ex.StackTrace);
                throw new CustomException("An error occured when adding to BLL. Please contact the administrator.");
            }
        }
        public void Delete(Guid id)
        {
            try
            {
                _genericRepository.Delete(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogError(ex.StackTrace);
                throw new CustomException($"Could not delete {id} Please contact the administrator.");
            }
        }
        public async Task<TDto> GetByIdAsync(Guid id)
        {
            try
            {
                TEntity entity = await _genericRepository.GetByIdAsync(id);
                return _mapper.Map<TDto>(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogError(ex.StackTrace);
                throw new CustomException($"Could not get by id: {id}. It is possible that {id} does not exist or been deleted.");
            }
        }
        public async Task<List<TDto>> GetListAsync()
        {
            try
            {
                var list = await _genericRepository.GetListAsync();
                List<TDto> dtos = _mapper.Map<List<TDto>>(list);
                return dtos;
            }
            catch (Exception ex) {
                _logger.LogError(ex.Message);
                _logger.LogError(ex.StackTrace);
                throw new CustomException("An error occured loading the list from BLL. Please contact the administrator.");
            }
        }
        public TDto Update(TDto item)
        {
            try
            {
                TEntity entity = _mapper.Map<TEntity>(item);
                entity.SetValue<TEntity>("UpdatedDate", DateTime.Now);
                TEntity dbEntity = _genericRepository.Update(entity);
                return _mapper.Map<TDto>(dbEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogError(ex.StackTrace);
                throw new CustomException("Could not update, an error occured from BLL. Please contact the administrator.");
            }
        }

    }
}
