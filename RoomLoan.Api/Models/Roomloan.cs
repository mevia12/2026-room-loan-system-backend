using System;

namespace RoomLoan.Api.Models
{
    public class RoomLoan
    {
        public int Id { get; set; }

        public string RoomName { get; set; } = string.Empty;

        public string BorrowerName { get; set; } = string.Empty;

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string Status { get; set; } = "Pending";

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
