using System;
using System.ComponentModel.DataAnnotations;

namespace RoomLoan.Api.Dtos
{
    public class CreateRoomLoanDto : IValidatableObject
    {
        [Required(ErrorMessage = "RoomName is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "RoomName must be 2-100 characters.")]
        public string RoomName { get; set; } = null!;

        [Required(ErrorMessage = "BorrowerName is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "BorrowerName must be 2-100 characters.")]
        public string BorrowerName { get; set; } = null!;

        [Required(ErrorMessage = "StartTime is required.")]
        public DateTime StartTime { get; set; }

        [Required(ErrorMessage = "EndTime is required.")]
        public DateTime EndTime { get; set; }

        // Business rule validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (EndTime <= StartTime)
            {
                yield return new ValidationResult(
                    "EndTime must be greater than StartTime.",
                    new[] { nameof(EndTime), nameof(StartTime) }
                );
            }
        }
    }
}
