using System.ComponentModel.DataAnnotations;

namespace RoomLoan.Api.Dtos
{
    public class UpdateStatusDto
    {
        [Required(ErrorMessage = "Status is required.")]
        [RegularExpression("^(Pending|Approved|Rejected)$",
            ErrorMessage = "Status must be one of: Pending, Approved, Rejected.")]
        public string Status { get; set; } = null!;
    }
}
