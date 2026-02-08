using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoomLoan.Api.Data;
using RoomLoan.Api.Dtos;
using RoomLoan.Api.Models;

namespace RoomLoan.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomLoansController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RoomLoansController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/roomloans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomLoanEntity>>> GetRoomLoans(
            [FromQuery] string? status,
            [FromQuery] string? q,
            [FromQuery] string? sortBy = "createdAt",
            [FromQuery] string? order = "desc"
        )
        {
            IQueryable<RoomLoanEntity> query = _context.RoomLoans;

            // Filter by status
            if (!string.IsNullOrWhiteSpace(status))
            {
                query = query.Where(x => x.Status == status);
            }

            // Search by keyword (room name or borrower name)
            if (!string.IsNullOrWhiteSpace(q))
            {
                var keyword = q.ToLower();
                query = query.Where(x =>
                    x.RoomName.ToLower().Contains(keyword) ||
                    x.BorrowerName.ToLower().Contains(keyword)
                );
            }

            // Sorting
            if (sortBy?.ToLower() == "createdat")
            {
                query = order?.ToLower() == "asc"
                    ? query.OrderBy(x => x.CreatedAt)
                    : query.OrderByDescending(x => x.CreatedAt);
            }

            return await query.ToListAsync();
        }

        // GET: api/roomloans/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<RoomLoanEntity>> GetRoomLoan(int id)
        {
            var roomLoan = await _context.RoomLoans.FindAsync(id);
            if (roomLoan == null) return NotFound();
            return roomLoan;
        }

        // POST: api/roomloans
        // Pakai DTO supaya client tidak bisa mengirim Id
        [HttpPost]
        public async Task<ActionResult<RoomLoanEntity>> CreateRoomLoan([FromBody] CreateRoomLoanDto dto)
        {
            // Validasi tambahan (opsional tapi bagus)
            if (dto.EndTime <= dto.StartTime)
            {
                return BadRequest(new { message = "EndTime harus lebih besar dari StartTime." });
            }

            var entity = new RoomLoanEntity
            {
                RoomName = dto.RoomName,
                BorrowerName = dto.BorrowerName,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime,
                Status = "Pending",
                CreatedAt = DateTime.UtcNow
            };

            _context.RoomLoans.Add(entity);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRoomLoan), new { id = entity.Id }, entity);
        }

        // PUT: api/roomloans/5/status
        [HttpPut("{id:int}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] UpdateStatusDto dto)
        {
            var roomLoan = await _context.RoomLoans.FindAsync(id);
            if (roomLoan == null) return NotFound();

            // (Opsional) batasi status yang boleh
            var allowed = new[] { "Pending", "Approved", "Rejected" };
            if (!allowed.Contains(dto.Status))
            {
                return BadRequest(new { message = "Status harus salah satu dari: Pending, Approved, Rejected." });
            }

            roomLoan.Status = dto.Status;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/roomloans/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteRoomLoan(int id)
        {
            var roomLoan = await _context.RoomLoans.FindAsync(id);
            if (roomLoan == null) return NotFound();

            _context.RoomLoans.Remove(roomLoan);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
