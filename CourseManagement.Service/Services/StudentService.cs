using AutoMapper;
using CourseManagement.Core.DTOs;
using CourseManagement.Core.Entities;
using CourseManagement.Core.Repositories;
using CourseManagement.Core.Services;
using CourseManagement.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Service.Services
{
    public class StudentService : Service<Student>, IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository studentRepository,
                             IUnitOfWork unitOfWork,
                             IMapper mapper) : base(studentRepository, unitOfWork)
        {
            _studentRepository = studentRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<StudentDTO>> GetAllAsync()
        {
            var students = await _studentRepository.GetAllAsync();
            return _mapper.Map<List<StudentDTO>>(students);
        }

        public async Task<StudentDTO> GetByIdAsync(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            return _mapper.Map<StudentDTO>(student);
        }

        public async Task<StudentDTO> CreateAsync(StudentDTO dto)
        {
            var student = _mapper.Map<Student>(dto);
            await _studentRepository.AddAsync(student);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<StudentDTO>(student);
        }

        Task<List<Student>> IStudentService.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<Student> IStudentService.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Student> AddAsync(Student entity)
        {
            throw new NotImplementedException();
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
