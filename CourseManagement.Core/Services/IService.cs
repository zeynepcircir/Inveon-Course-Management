using CourseManagement.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Core.Services
{
    public interface IService<T> where T : class
    {
        Task<ResponseDTO<List<TDto>>> GetAllAsync<TDto>() where TDto : class;
        Task<ResponseDTO<TDto>> GetByIdAsync<TDto>(int id) where TDto : class;
        Task<ResponseDTO<TDto>> AddAsync<TDto>(T entity) where TDto : class;
        Task<ResponseDTO<NoDataDto>> UpdateAsync(T entity, int id);
        Task<ResponseDTO<NoDataDto>> RemoveAsync(int id);
    }
}
