using Application.Common.Model;
using Domain.Common.Validation;
using Domain.DTOs;
using Domain.Entities;
using Domain.Persistence.Courses;
using Domain.Persistence.Materials;
using Domain.Persistence.Users;

namespace Application.Materials.CreateMaterial
{
    public sealed class CreateMaterialRequestHandler : RequestHandler<CreateMaterialRequest, MaterialDTO>
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IUserRepository _userRepository;

        public CreateMaterialRequestHandler(IMaterialRepository materialRepository, ICourseRepository courseRepository, IUserRepository userRepository)
        {
            _materialRepository = materialRepository;
            _courseRepository = courseRepository;
            _userRepository = userRepository;
        }

        protected override async Task<Result<MaterialDTO>> HandleRequestAsync(CreateMaterialRequest request, Result<MaterialDTO> result)
        {
            var profesor = await _userRepository.GetById(request.ProfesorId);
            if (profesor == null || profesor.Role != Domain.Enums.Role.Profesor)
            {
                result.SetValidationResult(ValidationResult.Error("PROFESSOR_NOT_FOUND", "Profesor ne postoji."));
                return result;
            }

            var course = await _courseRepository.GetById(request.CourseId);
            if (course == null)
            {
                result.SetValidationResult(ValidationResult.Error("COURSE_NOT_FOUND", "Kolegij ne postoji."));
                return result;
            }

            if (course.ProfessorId != profesor.Id)
            {
                result.SetValidationResult(ValidationResult.Error("UNAUTHORIZED", "Profesor ne predaje ovaj kolegij."));
                return result;
            }

            var material = new Material
            {
                Name = request.Name,
                Url = request.Url,
                CreatedAt = DateTime.UtcNow,
                CourseId = request.CourseId,
                ProfessorId = request.ProfesorId
            };

            _materialRepository.Add(material);

            result.SetResult(new MaterialDTO
            {
                Id = material.Id,
                Name = material.Name,
                Url = material.Url,
                CreatedAt = material.CreatedAt,
                CourseId = material.CourseId,
                ProfesorId = material.ProfessorId
            });

            return result;
        }
    }
}
