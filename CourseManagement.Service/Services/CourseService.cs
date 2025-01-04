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
        private readonly ICourseRepository _repository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IInstructorRepository _instructorRepository;
        private readonly IStudentCourseRepository _studentCourseRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CourseService(ICourseRepository courseRepository,
                            ICategoryRepository categoryRepository,
                            IInstructorRepository instructorRepository,
                            IStudentCourseRepository studentCourseRepository,
                            IUnitOfWork unitOfWork,
                            IMapper mapper) : base(courseRepository, unitOfWork, mapper)
        {
            _repository = courseRepository;
            _categoryRepository = categoryRepository;
            _instructorRepository = instructorRepository;
            _studentCourseRepository = studentCourseRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseDTO<CourseListDTO>> AddCourseAsync(CourseCreateDTO createDto)
        {
            Course entity = _mapper.Map<Course>(createDto);

            bool isCategoryExists = await _categoryRepository.AnyAsync(c => c.Id == createDto.CategoryId);
            if (!isCategoryExists)
            {
                return ResponseDTO<CourseListDTO>.Fail("Category not found", 404, true);
            }

            bool isInstructorExists = await _instructorRepository.AnyAsync(i => i.Id == createDto.InstructorId);
            if (!isInstructorExists)
            {
                return ResponseDTO<CourseListDTO>.Fail("Instructor not found", 404, true);
            }

            Course newEntity = await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();

            CourseListDTO dto = _mapper.Map<CourseListDTO>(newEntity);
            return ResponseDTO<CourseListDTO>.Success(dto, 201);
        }

        public Task<ResponseDTO<CourseListDTO>> GetEnrolledCourses()
        {
            throw new NotImplementedException();
        }
    }
}
