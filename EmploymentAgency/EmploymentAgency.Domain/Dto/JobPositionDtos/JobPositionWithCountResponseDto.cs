
namespace EmploymentAgency.Domain.Dto.JobPositionDtos;

public class JobPositionWithCountResponseDto
{
    public JobPositionGetDto JobPosition { get; set; } = null!;
    public int Count { get; set; }
}
