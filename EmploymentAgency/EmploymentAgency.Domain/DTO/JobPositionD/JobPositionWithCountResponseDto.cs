
namespace EmploymentAgency.Domain.Dto.JobPositionD;

public class JobPositionWithCountResponseDto
{
    public JobPositionGetDto JobPosition { get; set; } = null!;
    public int Count { get; set; }
}
