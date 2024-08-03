using Microsoft.EntityFrameworkCore;

namespace BlazorApp4.Data
{
    public class MeetingService
    {
        private readonly ApplicationDbContext _context;

        public MeetingService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddMeetingAsync(Meeting meeting)
        {
            _context.Meetings.Add(meeting);
            await _context.SaveChangesAsync();
        }

        public async Task<Meeting> GetMeetingAsync(int id)
        {
            return await _context.Meetings.FindAsync(id);
        }

        public async Task<List<Meeting>> GetMeetingsAsync()
        {
            return await _context.Meetings.ToListAsync();
        }

        public async Task UpdateMeetingAsync(Meeting meeting)
        {
            _context.Entry(meeting).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMeetingAsync(int id)
        {
            var meeting = await _context.Meetings.FindAsync(id);
            _context.Meetings.Remove(meeting);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Meeting>> GetMeetingsByUserAsync(string userId)
        {
            return await _context.Meetings.Where(c => c.Creator.Id == userId).ToListAsync();
        }

        public async Task<List<Meeting>> GetMeetingsByRoomAsync(int roomId)
        {
            return await _context.Meetings.Where(c => c.Room.Id == roomId).ToListAsync();
        }
    }
}
