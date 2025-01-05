using AutoMapper;
using CourseManagement.Core.DTOs;
using CourseManagement.Core.Entities;
using CourseManagement.Core.Repositories;
using CourseManagement.Core.Services;
using CourseManagement.Core.UnitOfWorks;
using Microsoft.EntityFrameworkCore;

namespace CourseManagement.Service.Services
{
    public class PaymentService : Service<Payment>, IPaymentService
    {
        private readonly IPaymentRepository _repository;
        private readonly ICreditCardRepository _creditCardRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IStudentCourseRepository _studentCourseRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PaymentService(IPaymentRepository repository,
                             ICreditCardRepository creditCardRepository,
                             ICourseRepository courseRepository,
                             IStudentRepository studentRepository,
                             IStudentCourseRepository studentCourseRepository,
                             IUnitOfWork unitOfWork,
                             IMapper mapper) : base(repository, unitOfWork, mapper)
        {
            _repository = repository;
            _creditCardRepository = creditCardRepository;
            _courseRepository = courseRepository;
            _studentRepository = studentRepository;
            _studentCourseRepository = studentCourseRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseDTO<PaymentDTO>> MakePayment(PaymentCreateDTO createDTO, string? userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return ResponseDTO<PaymentDTO>.Fail("User ID cannot be null or empty.", 400, true);
            }

            Student? student = await _studentRepository.Where(s => s.UserId == userId).FirstOrDefaultAsync();
            if (student == null)
            {
                return ResponseDTO<PaymentDTO>.Fail("Student not found.", 404, true);
            }

            bool courseExists = await _courseRepository.AnyAsync(c => c.Id == createDTO.CourseId);
            if (!courseExists)
            {
                return ResponseDTO<PaymentDTO>.Fail("Course not found.", 404, true);
            }

            CreditCard creditCard = new CreditCard
            {
                CVV = createDTO.CVV,
                CardNumber = createDTO.CardNumber,
                ExpiryDate = createDTO.ExpiryDate
            };

            await _creditCardRepository.AddAsync(creditCard);
            await _unitOfWork.CommitAsync();

            Payment payment = new Payment
            {
                CourseId = createDTO.CourseId,
                StudentId = student.Id,
                CreditCardId = creditCard.Id,
                PaymentTime = DateTime.UtcNow
            };

            await _repository.AddAsync(payment);
            await _unitOfWork.CommitAsync();

            StudentCourse studentCourse = new StudentCourse
            {
                StudentId = student.Id,
                CourseId = createDTO.CourseId,
                IsCompleted = false,
                LastAccessDate = DateTime.UtcNow
            };

            await _studentCourseRepository.AddAsync(studentCourse);
            await _unitOfWork.CommitAsync();

            PaymentDTO paymentDto = _mapper.Map<PaymentDTO>(payment);
            return ResponseDTO<PaymentDTO>.Success(paymentDto, 201);
        }
    }
}
