using Application.Announcements.GetCourseAnnouncements;
using Application.Common.Model;
using Domain.DTOs;
using Domain.Persistence.Announcements;
using Domain.Persistence.Materials;

namespace Application.Materials.GetCourseMaterials
{
    public sealed class GetCourseMaterialsRequestHandler : RequestHandler<GetCourseMaterialsRequest, List<MaterialDTO>>
    {
        private readonly IMaterialRepository _materialRepository;

        public GetCourseMaterialsRequestHandler(IMaterialRepository materialRepository)
        {
            _materialRepository = materialRepository;
        }

        protected override async Task<Result<List<MaterialDTO>>> HandleRequestAsync(GetCourseMaterialsRequest request, Result<List<MaterialDTO>> result)
        {
            var materials = await _materialRepository.GetByCourse(request.CourseId);

            result.SetResult(materials.Select(m => new MaterialDTO
            {
                Id = m.Id,
                Name = m.Name,
                Url = m.Url,
                CreatedAt = m.CreatedAt
            }).ToList()
            );

            return result;
        }
    }
}
