using CourseManagement.Core.DTOs;

namespace CourseManagement.Core.Services
{
    public interface IService<T> where T : class
    {
        Task<ResponseDTO<List<TDto>>> GetAllAsync<TDto>() where TDto : class;
        Task<ResponseDTO<TDto>> GetByIdAsync<TDto>(int id) where TDto : class;
        Task<ResponseDTO<TDto>> AddAsync<TDto, TCDto>(TCDto createDto) where TDto : class;
        Task<ResponseDTO<NoDataDto>> UpdateAsync<TUDto>(TUDto updateDto, int id);
        Task<ResponseDTO<NoDataDto>> RemoveAsync(int id);
    }
}
