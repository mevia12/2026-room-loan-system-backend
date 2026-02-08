using System.ComponentModel.DataAnnotations;

namespace RoomLoan.Api.Dtos
{
    public class UpdateStatusDto
    {
        [Required]
        [MaxLength(50)]
        public string Status { get; set; } = default!;
    }
}
