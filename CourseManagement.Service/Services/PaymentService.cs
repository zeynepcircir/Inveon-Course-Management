using AutoMapper;
using CourseManagement.Core.DTOs;
using CourseManagement.Core.Entities;
using CourseManagement.Core.Repositories;
using CourseManagement.Core.Services;
using CourseManagement.Core.UnitOfWorks;
using CourseManagement.Repository.Repositories;
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
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PaymentService(IPaymentRepository repository,
                             ICreditCardRepository creditCardRepository,
                             ICourseRepository courseRepository,
                             IStudentRepository studentRepository,
                             IStudentCourseRepository studentCourseRepository,
                             IShoppingCartRepository shoppingCartRepository,
                             IUnitOfWork unitOfWork,
                             IMapper mapper) : base(repository, unitOfWork, mapper)
        {
            _repository = repository;
            _creditCardRepository = creditCardRepository;
            _courseRepository = courseRepository;
            _studentRepository = studentRepository;
            _studentCourseRepository = studentCourseRepository;
            _shoppingCartRepository = shoppingCartRepository;
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

            ShoppingCart? shoppingCart = await _shoppingCartRepository
                .Where(sc => sc.StudentId == student.Id)
                .Include(sc => sc.ShoppingCartCourses)
                    .ThenInclude(scc => scc.Course)
                .FirstOrDefaultAsync();

            if (shoppingCart == null || !shoppingCart.ShoppingCartCourses.Any())
            {
                return ResponseDTO<PaymentDTO>.Fail("No courses in the shopping cart to process payment.", 404, true);
            }

            CreditCard creditCard = new CreditCard
            {
                CVV = createDTO.CVV,
                CardNumber = createDTO.CardNumber,
                ExpiryDate = createDTO.ExpiryDate
            };

            await _creditCardRepository.AddAsync(creditCard);
            await _unitOfWork.CommitAsync();

            foreach (ShoppingCartCourse shoppingCartCourse in shoppingCart.ShoppingCartCourses)
            {
                Payment payment = new Payment
                {
                    CourseId = shoppingCartCourse.CourseId,
                    StudentId = student.Id,
                    CreditCardId = creditCard.Id,
                    PaymentTime = DateTime.UtcNow
                };

                await _repository.AddAsync(payment);

                StudentCourse studentCourse = new StudentCourse
                {
                    CourseId = shoppingCartCourse.CourseId,
                    StudentId = student.Id,
                    IsCompleted = false,
                    LastAccessDate = DateTime.UtcNow
                };

                await _studentCourseRepository.AddAsync(studentCourse);
            }

            _shoppingCartRepository.Remove(shoppingCart);
            await _unitOfWork.CommitAsync();

            PaymentDTO paymentDto = new PaymentDTO
            {
                Id = creditCard.Id,
                StudentId = student.Id,
                CreditCardId = creditCard.Id,
                PaymentTime = DateTime.UtcNow
            };

            return ResponseDTO<PaymentDTO>.Success(paymentDto, 201);
        }
    }
}
