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
    public class InstructorService : Service<Instructor>, IInstructorService
    {
        private readonly IInstructorRepository _instructorRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InstructorService(IInstructorRepository instructorRepository,
                                IUnitOfWork unitOfWork,
                                IMapper mapper) : base(instructorRepository, unitOfWork)
        {
            _instructorRepository = instructorRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<InstructorDTO>> GetAllAsync()
        {
            var instructors = await _instructorRepository.GetAllAsync();
            return _mapper.Map<List<InstructorDTO>>(instructors);
        }

        public async Task<InstructorDTO> GetByIdAsync(int id)
        {
            var instructor = await _instructorRepository.GetByIdAsync(id);
            return _mapper.Map<InstructorDTO>(instructor);
        }

        public async Task<InstructorDTO> CreateAsync(InstructorDTO dto)
        {
            var instructor = _mapper.Map<Instructor>(dto);
            await _instructorRepository.AddAsync(instructor);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<InstructorDTO>(instructor);
        }

        public async Task<InstructorDTO> UpdateAsync(int id, InstructorDTO dto)
        {
            var existingInstructor = await _instructorRepository.GetByIdAsync(id);
            if (existingInstructor == null) throw new Exception("Instructor not found");

            var updatedInstructor = _mapper.Map(dto, existingInstructor);
            _instructorRepository.Update(updatedInstructor);
            await _unitOfWork.CommitAsync();

            return _mapper.Map<InstructorDTO>(updatedInstructor);
        }

        public async Task DeleteAsync(int id)
        {
            var instructor = await _instructorRepository.GetByIdAsync(id);
            if (instructor == null) throw new Exception("Instructor not found");

            _instructorRepository.Remove(instructor);
            await _unitOfWork.CommitAsync();
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
