using Application.Common.Model;
using Domain.DTOs;
using Domain.Entities;
using Domain.Persistence.Enrollments;
using Domain.Persistence.Users;

namespace Application.Courses.EnrollStudent
{
    public sealed class EnrollStudentRequestHandler : RequestHandler<EnrollStudentRequest, EnrollmentDTO>
    {
        private readonly IEnrollmentRepository _enrollmentRepository;
        private readonly IUserRepository _userRepository;

        public EnrollStudentRequestHandler(IEnrollmentRepository enrollmentRepository, IUserRepository userRepository)
        {
            _enrollmentRepository = enrollmentRepository;
            _userRepository = userRepository;
        }

        protected override async Task<Result<EnrollmentDTO>> HandleRequestAsync(EnrollStudentRequest request, Result<EnrollmentDTO> result)
        {
            var profesor = await _userRepository.GetById(request.ProfesorId);

            if (profesor == null || profesor.Role != Domain.Enums.Role.Profesor)
            {
                result.SetValidationResult(Domain.Common.Validation.ValidationResult.Error("PROFESSOR_NOT_FOUND", "Profesor ne postoji."));
                return result;
            }

            var enrollment = new Enrollment
            {
                StudentId = request.StudentId,
                CourseId = request.CourseId
            };

            _enrollmentRepository.Add(enrollment);

            result.SetResult(new EnrollmentDTO
            {
                Id = enrollment.Id,
                StudentId = enrollment.StudentId,
                CourseId = enrollment.CourseId
            });

            return result;
        }
    }
}
