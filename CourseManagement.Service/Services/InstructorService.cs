using AutoMapper;
using CourseManagement.Core.DTOs;
using CourseManagement.Core.Entities;
using CourseManagement.Core.Repositories;
using CourseManagement.Core.Services;
using CourseManagement.Core.UnitOfWorks;

namespace CourseManagement.Service.Services
{
    public class InstructorService : Service<Instructor>, IInstructorService
    {
        private readonly IInstructorRepository _instructorRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InstructorService(IInstructorRepository instructorRepository,
                                IUnitOfWork unitOfWork,
                                IMapper mapper) : base(instructorRepository, unitOfWork, mapper)
        {
            _instructorRepository = instructorRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<List<PaymentResultDTO>> GetEarningsAsync(int instructorId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ReviewDTO>> GetReviewsAsync(int instructorId)
        {
            throw new NotImplementedException();
        }
    }
}
