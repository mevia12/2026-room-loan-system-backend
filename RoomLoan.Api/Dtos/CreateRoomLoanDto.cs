using System;
using System.ComponentModel.DataAnnotations;

namespace RoomLoan.Api.Dtos
{
    public class CreateRoomLoanDto
    {
        [Required]
        [MaxLength(200)]
        public string RoomName { get; set; } = default!;

        [Required]
        [MaxLength(200)]
        public string BorrowerName { get; set; } = default!;

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }
    }
}
