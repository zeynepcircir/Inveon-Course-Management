using AutoMapper;
using CourseManagement.Core.DTOs;
using CourseManagement.Core.Repositories;
using CourseManagement.Core.Services;
using CourseManagement.Core.UnitOfWorks;
using Microsoft.EntityFrameworkCore;

namespace CourseManagement.Service.Services
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IGenericRepository<T> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Service(IGenericRepository<T> repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseDTO<TDto>> AddAsync<TDto>(T entity) where TDto : class
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            TDto dto = _mapper.Map<TDto>(entity);
            return ResponseDTO<TDto>.Success(dto, 200);
        }

        public async Task<ResponseDTO<NoDataDto>> UpdateAsync(T entity, int id)
        {
            T existingEntity = await _repository.GetByIdAsync(id);
            if (existingEntity == null)
            {
                return ResponseDTO<NoDataDto>.Fail("The entity not found", 404, true);
            }
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
            return ResponseDTO<NoDataDto>.Success(204);
        }

        public async Task<ResponseDTO<NoDataDto>> RemoveAsync(int id)
        {
            T existingEntity = await _repository.GetByIdAsync(id);
            if (existingEntity == null)
            {
                return ResponseDTO<NoDataDto>.Fail("The entity not found", 404, true);
            }
            _repository.Remove(existingEntity);
            await _unitOfWork.CommitAsync();
            return ResponseDTO<NoDataDto>.Success(204);
        }

        public async Task<ResponseDTO<List<TDto>>> GetAllAsync<TDto>() where TDto : class 
        {
            List<T> entities = await _repository.GetAll().ToListAsync();
            List<TDto> dtos = _mapper.Map<List<TDto>>(entities);
            return ResponseDTO<List<TDto>>.Success(dtos, 200);
        }

        public async Task<ResponseDTO<TDto>> GetByIdAsync<TDto>(int id) where TDto : class
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                return ResponseDTO<TDto>.Fail("The entity not found", 404, true);
            }
            TDto dto = _mapper.Map<TDto>(entity);
            return ResponseDTO<TDto>.Success(dto, 200);
        }
    }
}
