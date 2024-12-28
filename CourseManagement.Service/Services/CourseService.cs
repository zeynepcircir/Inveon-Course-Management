using AutoMapper;
using CourseManagement.Core.DTOs;
using CourseManagement.Core.Entities;
using CourseManagement.Core.Repositories;
using CourseManagement.Core.Services;
using CourseManagement.Core.UnitOfWorks;
using CourseManagement.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Service.Services
{
    public class CourseService : Service<Course>, ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CourseService(ICourseRepository courseRepository,
                            IUnitOfWork unitOfWork,
                            IMapper mapper) : base(courseRepository, unitOfWork)
        {
            _courseRepository = courseRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<CourseDTO>> GetAllAsync()
        {
            var courses = await _courseRepository.GetAllAsync();
            return _mapper.Map<List<CourseDTO>>(courses);
        }

        public async Task<CourseDTO> GetByIdAsync(int id)
        {
            var course = await _courseRepository.GetByIdAsync(id);
            return _mapper.Map<CourseDTO>(course);
        }

        public async Task<CourseDTO> CreateAsync(CourseDTO dto)
        {
            var course = _mapper.Map<Course>(dto);
            await _courseRepository.AddAsync(course);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<CourseDTO>(course);
        }

        public async Task<CourseProgressDTO> GetCourseProgressAsync(int courseId, int studentId)
        {
            // Implementation for getting course progress
            throw new NotImplementedException();
        }

        public async Task<PaymentResultDTO> ProcessPaymentAsync(CreatePaymentRequestDTO paymentRequest)
        {
            // Implementation for processing payment
            throw new NotImplementedException();
        }

        public async Task<CourseDTO> AddCouponAsync(int courseId, CouponDTO coupon)
        {
            // Implementation for adding coupon
            throw new NotImplementedException();
        }
    }
}
