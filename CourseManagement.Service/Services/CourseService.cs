using AutoMapper;
using CourseManagement.Core.DTOs;
using CourseManagement.Core.Entities;
using CourseManagement.Core.Repositories;
using CourseManagement.Core.Services;
using CourseManagement.Core.UnitOfWorks;
using Microsoft.EntityFrameworkCore;

namespace CourseManagement.Service.Services
{
    public class CourseService : Service<Course>, ICourseService
    {
        private readonly ICourseRepository _repository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IInstructorRepository _instructorRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IStudentCourseRepository _studentCourseRepository;
        private readonly ICourseChapterRepository _courseChapterRepository;
        private readonly IStudentChapterRepository _studentChapterRepository;
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CourseService(ICourseRepository courseRepository,
                            ICategoryRepository categoryRepository,
                            IInstructorRepository instructorRepository,
                            IStudentRepository studentRepository,
                            IStudentCourseRepository studentCourseRepository,
                            ICourseChapterRepository courseChapterRepository,
                            IStudentChapterRepository studentChapterRepository,
                            IShoppingCartRepository shoppingCartRepository,
                            IUnitOfWork unitOfWork,
                            IMapper mapper) : base(courseRepository, unitOfWork, mapper)
        {
            _repository = courseRepository;
            _categoryRepository = categoryRepository;
            _instructorRepository = instructorRepository;
            _studentRepository = studentRepository;
            _studentCourseRepository = studentCourseRepository;
            _courseChapterRepository = courseChapterRepository;
            _studentChapterRepository = studentChapterRepository;
            _shoppingCartRepository = shoppingCartRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseDTO<CourseListDTO>> AddCourseAsync(CourseCreateDTO createDto, string? userId)
        {
            if(string.IsNullOrEmpty(userId))
    {
                return ResponseDTO<CourseListDTO>.Fail("User ID cannot be null or empty.", 400, true);
            }

            bool isCategoryExists = await _categoryRepository.AnyAsync(c => c.Id == createDto.CategoryId);
            if (!isCategoryExists)
            {
                return ResponseDTO<CourseListDTO>.Fail("Category not found", 404, true);
            }

            Instructor? instructor = await _instructorRepository
                .Where(i => i.UserId == userId)
                .FirstOrDefaultAsync();
            if (instructor == null)
            {
                return ResponseDTO<CourseListDTO>
                    .Fail("You are not authorized to add a course. Only instructors can add courses.", 401, true);
            }

            Course entity = _mapper.Map<Course>(createDto);
            entity.InstructorId = instructor.Id;

            entity = await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();

            CourseListDTO dto = _mapper.Map<CourseListDTO>(entity);
            return ResponseDTO<CourseListDTO>.Success(dto, 201);
        }

        public async Task<ResponseDTO<CourseChapterDTO>> AddChapterToCourseAsync(int courseId, CourseChapterCreateDTO createDto, string? userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return ResponseDTO<CourseChapterDTO>.Fail("User ID cannot be null or empty.", 400, true);
            }

            Instructor? instructor = await _instructorRepository
                .Where(i => i.UserId == userId)
                .FirstOrDefaultAsync();

            if (instructor == null)
            {
                return ResponseDTO<CourseChapterDTO>.Fail("You are not authorized to add chapters to courses.", 401, true);
            }

            Course? course = await _repository
                .Where(c => c.Id == courseId && c.InstructorId == instructor.Id)
                .FirstOrDefaultAsync();

            if (course == null)
            {
                return ResponseDTO<CourseChapterDTO>.Fail("Course not found or you do not have permission to add chapters to this course.", 404, true);
            }

            CourseChapter newChapter = new CourseChapter
            {
                Title = createDto.Title,
                Duration = createDto.Duration,
                OrderIndex = createDto.OrderIndex,
                ImageUrl = createDto.ImageUrl,
                CourseId = courseId
            };

            await _courseChapterRepository.AddAsync(newChapter);
            await _unitOfWork.CommitAsync();

            CourseChapterDTO chapterDto = _mapper.Map<CourseChapterDTO>(newChapter);
            return ResponseDTO<CourseChapterDTO>.Success(chapterDto, 201);
        }

        public async Task<ResponseDTO<CourseListDTO>> DeleteCourseAsync(int courseId, string? userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return ResponseDTO<CourseListDTO>.Fail("User ID cannot be null or empty.", 400, true);
            }

            Instructor? instructor = await _instructorRepository
                .Where(i => i.UserId == userId)
                .FirstOrDefaultAsync();

            if (instructor == null)
            {
                return ResponseDTO<CourseListDTO>.Fail("You are not authorized to delete courses.", 401, true);
            }

            Course? course = await _repository
                .Where(c => c.Id == courseId && c.InstructorId == instructor.Id)
                .Include(c => c.Chapters)
                .FirstOrDefaultAsync();

            if (course == null)
            {
                return ResponseDTO<CourseListDTO>.Fail("Course not found or you do not have permission to delete this course.", 404, true);
            }

            _repository.Remove(course);
            await _unitOfWork.CommitAsync();

            CourseListDTO courseDto = _mapper.Map<CourseListDTO>(course);
            return ResponseDTO<CourseListDTO>.Success(courseDto, 200);
        }

        public async Task<ResponseDTO<List<CourseChapterDTO>>> GetCourseChapters(int courseId)
        {
            var courseExists = await _repository.AnyAsync(c => c.Id == courseId);
            if (!courseExists)
            {
                return ResponseDTO<List<CourseChapterDTO>>.Fail("Course not found", 404, true);
            }

            List<CourseChapter> chapters = await _courseChapterRepository
                .Where(cc => cc.CourseId == courseId)
                .OrderBy(cc => cc.OrderIndex)
                .ToListAsync();

            if (!chapters.Any())
            {
                return ResponseDTO<List<CourseChapterDTO>>.Fail("No chapters found for this course.", 404, true);
            }

            List<CourseChapterDTO> chapterDtos = _mapper.Map<List<CourseChapterDTO>>(chapters);
            return ResponseDTO<List<CourseChapterDTO>>.Success(chapterDtos, 200);
        }


        public async Task<ResponseDTO<List<CourseListDTO>>> GetEnrolledCourses(string? userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return ResponseDTO<List<CourseListDTO>>.Fail("User ID cannot be null or empty.", 400, true);
            }

            var enrolledCourses = await _studentCourseRepository
                .Where(sc => sc.Student.UserId == userId)
                .Include(sc => sc.Course)
                    .ThenInclude(c => c.Category)
                .Select(sc => sc.Course)
                .ToListAsync();

            if (!enrolledCourses.Any())
            {
                return ResponseDTO<List<CourseListDTO>>.Fail("No enrolled courses found for the user.", 404, true);
            }

            var courseListDtos = _mapper.Map<List<CourseListDTO>>(enrolledCourses);

            foreach (var courseDto in courseListDtos)
            {
                var totalChapters = await _courseChapterRepository
                    .Where(cc => cc.CourseId == courseDto.Id)
                    .CountAsync();

                var completedChapters = await _studentChapterRepository
                    .Where(sc => sc.CourseChapter.CourseId == courseDto.Id && sc.Student.UserId == userId && sc.IsCompleted)
                    .CountAsync();

                courseDto.CompletionPercentage = totalChapters == 0
                    ? null
                    : (int?)((completedChapters * 100) / totalChapters);
            }

            return ResponseDTO<List<CourseListDTO>>.Success(courseListDtos, 200);
        }

        public async Task<ResponseDTO<List<StudentChapterDTO>>> GetStudentCourseChapters(int courseId, string? userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return ResponseDTO<List<StudentChapterDTO>>.Fail("User ID cannot be null or empty.", 400, true);
            }

            Student? student = await _studentRepository
                .Where(s => s.UserId == userId)
                .FirstOrDefaultAsync();

            if (student == null)
            {
                return ResponseDTO<List<StudentChapterDTO>>.Fail("Student not found.", 404, true);
            }

            List<CourseChapter> courseChapters = await _courseChapterRepository
                .Where(cc => cc.CourseId == courseId)
                .OrderBy(cc => cc.OrderIndex)
                .ToListAsync();

            if (!courseChapters.Any())
            {
                return ResponseDTO<List<StudentChapterDTO>>.Fail("No chapters found for this course.", 404, true);
            }

            List<StudentChapterDTO> studentChapterDtos = _mapper.Map<List<StudentChapterDTO>>(courseChapters);

            List<StudentChapter> studentChapters = await _studentChapterRepository
                .Where(sc => sc.StudentId == student.Id && sc.CourseChapter.CourseId == courseId)
                .ToListAsync();

            foreach (StudentChapterDTO studentChapterDto in studentChapterDtos)
            {
                StudentChapter? studentChapter = studentChapters.FirstOrDefault(
                    sc => sc.CourseChapterId == studentChapterDto.Id);
                if (studentChapter != null)
                {
                    studentChapterDto.CompletionDate = studentChapter.CompletionDate;
                    studentChapterDto.IsCompleted = studentChapter.IsCompleted;
                } 
                else
                {
                    studentChapterDto.IsCompleted = false;
                }
            }

            return ResponseDTO<List<StudentChapterDTO>>.Success(studentChapterDtos, 200);
        }

        public async Task<ResponseDTO<CourseListDTO>> UpdateCourseAsync(int courseId,CourseCreateDTO dto, string? userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return ResponseDTO<CourseListDTO>.Fail("User ID cannot be null or empty.", 400, true);
            }

            var instructor = await _instructorRepository
                .Where(i => i.UserId == userId)
                .FirstOrDefaultAsync();

            if (instructor == null)
            {
                return ResponseDTO<CourseListDTO>.Fail("You are not authorized to update courses.", 401, true);
            }

            var course = await _repository
                .Where(c => c.Id == courseId && c.InstructorId == instructor.Id)
                .FirstOrDefaultAsync();

            if (course == null)
            {
                return ResponseDTO<CourseListDTO>.Fail("Course not found or you do not have permission to update this course.", 404, true);
            }

            bool isCategoryExists = await _categoryRepository.AnyAsync(c => c.Id == dto.CategoryId);
            if (!isCategoryExists)
            {
                return ResponseDTO<CourseListDTO>.Fail("Category not found.", 404, true);
            }

            _mapper.Map(dto, course);

            _repository.Update(course);
            await _unitOfWork.CommitAsync();

            var courseDto = _mapper.Map<CourseListDTO>(course);
            return ResponseDTO<CourseListDTO>.Success(courseDto, 200);
        }

        public async Task<ResponseDTO<List<CourseListDTO>>> GetInstructorCourses(string? userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return ResponseDTO<List<CourseListDTO>>.Fail("User ID cannot be null or empty.", 400, true);
            }

            Instructor? instructor = await _instructorRepository
                .Where(i => i.UserId == userId)
                .FirstOrDefaultAsync();

            if (instructor == null)
            {
                return ResponseDTO<List<CourseListDTO>>.Fail("Instructor not found.", 404, true);
            }

            List<Course> courses = await _repository
                .Where(c => c.InstructorId == instructor.Id)
                .Include(c => c.Category)
                .ToListAsync();

            if (!courses.Any())
            {
                return ResponseDTO<List<CourseListDTO>>.Fail("No courses found for this instructor.", 404, true);
            }

            List<CourseListDTO> courseListDtos = _mapper.Map<List<CourseListDTO>>(courses);
            return ResponseDTO<List<CourseListDTO>>.Success(courseListDtos, 200);
        }

        public async Task<ResponseDTO<CourseListDTO>> AddToCart(int courseId, string? userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return ResponseDTO<CourseListDTO>.Fail("User ID cannot be null or empty.", 400, true);
            }

            var student = await _studentRepository.Where(s => s.UserId == userId).FirstOrDefaultAsync();
            if (student == null)
            {
                return ResponseDTO<CourseListDTO>.Fail("Student not found.", 404, true);
            }

            var course = await _repository.Where(c => c.Id == courseId).FirstOrDefaultAsync();
            if (course == null)
            {
                return ResponseDTO<CourseListDTO>.Fail("Course not found.", 404, true);
            }

            var shoppingCart = await _shoppingCartRepository
                .Where(sc => sc.StudentId == student.Id)
                .Include(sc => sc.ShoppingCartCourses)
                .FirstOrDefaultAsync();

            if (shoppingCart == null)
            {
                shoppingCart = new ShoppingCart
                {
                    StudentId = student.Id,
                    ShoppingCartCourses = new List<ShoppingCartCourse>()
                };

                await _shoppingCartRepository.AddAsync(shoppingCart);
                await _unitOfWork.CommitAsync();
            }

            bool isCourseAlreadyInCart = shoppingCart.ShoppingCartCourses
                .Any(scc => scc.CourseId == courseId);

            if (isCourseAlreadyInCart)
            {
                return ResponseDTO<CourseListDTO>.Fail("Course is already in the cart.", 409, true);
            }

            var shoppingCartCourse = new ShoppingCartCourse
            {
                ShoppingCartId = shoppingCart.Id,
                CourseId = course.Id
            };

            shoppingCart.ShoppingCartCourses.Add(shoppingCartCourse);
            await _unitOfWork.CommitAsync();

            var courseDto = _mapper.Map<CourseListDTO>(course);
            return ResponseDTO<CourseListDTO>.Success(courseDto, 200);
        }

        public async Task<ResponseDTO<List<CourseListDTO>>> GetCartCourses(string? userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return ResponseDTO<List<CourseListDTO>>.Fail("User ID cannot be null or empty.", 400, true);
            }

            var student = await _studentRepository.Where(s => s.UserId == userId).FirstOrDefaultAsync();
            if (student == null)
            {
                return ResponseDTO<List<CourseListDTO>>.Fail("Student not found.", 404, true);
            }

            var shoppingCart = await _shoppingCartRepository
                .Where(sc => sc.StudentId == student.Id)
                .Include(sc => sc.ShoppingCartCourses)
                    .ThenInclude(scc => scc.Course)
                .FirstOrDefaultAsync();

            if (shoppingCart == null || !shoppingCart.ShoppingCartCourses.Any())
            {
                return ResponseDTO<List<CourseListDTO>>.Fail("No courses found in the cart.", 404, true);
            }

            var courses = shoppingCart.ShoppingCartCourses.Select(scc => scc.Course).ToList();
            var courseListDtos = _mapper.Map<List<CourseListDTO>>(courses);

            return ResponseDTO<List<CourseListDTO>>.Success(courseListDtos, 200);
        }
    }
}
