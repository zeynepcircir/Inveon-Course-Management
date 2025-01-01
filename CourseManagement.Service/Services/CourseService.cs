using AutoMapper;
using CourseManagement.Core.DTOs;
using CourseManagement.Core.Entities;
using CourseManagement.Core.Repositories;
using CourseManagement.Core.Services;
using CourseManagement.Core.UnitOfWorks;

namespace CourseManagement.Service.Services
{
    public class CourseService : Service<Course>, ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CourseService(ICourseRepository courseRepository,
                            IUnitOfWork unitOfWork,
                            IMapper mapper) : base(courseRepository, unitOfWork, mapper)
        {
            _courseRepository = courseRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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
