﻿using Microsoft.EntityFrameworkCore;


namespace BlazorApp4.Data
{
    public class ComplaintService
    {
        private readonly ApplicationDbContext _context;

        public ComplaintService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddComplaintAsync(Complaint complaint)
        {            
            _context.Complaints.Add(complaint);
            await _context.SaveChangesAsync();
        }

        public async Task<Complaint> GetComplaintAsync(int id)
        {
            return await _context.Complaints.FindAsync(id);
        }

        public async Task<List<Complaint>> GetComplaintsAsync()
        {
            return await _context.Complaints.Include(c => c.Sender).ToListAsync();
        }


        public async Task UpdateComplaintAsync(Complaint complaint)
        {
            _context.Entry(complaint).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteComplaintAsync(int id)
        {
            var complaint = await _context.Complaints.FindAsync(id);
            _context.Complaints.Remove(complaint);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Complaint>> GetComplaintsByUserAsync(string userId)
        {
            return await _context.Complaints.Where(c => c.Sender.Id == userId).ToListAsync();
        }
    }
}
