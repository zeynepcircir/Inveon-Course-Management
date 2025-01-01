using AutoMapper;
using CourseManagement.Core.DTOs;
using CourseManagement.Core.Entities;
using CourseManagement.Core.Repositories;
using CourseManagement.Core.Services;
using CourseManagement.Core.UnitOfWorks;

namespace CourseManagement.Service.Services
{
    public class StudentService : Service<Student>, IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository studentRepository,
                             IUnitOfWork unitOfWork,
                             IMapper mapper) : base(studentRepository, unitOfWork, mapper)
        {
            _studentRepository = studentRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<List<Student>> GetStudentsWithCoursesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Student> GetStudentByIdWithDetailsAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
    }
