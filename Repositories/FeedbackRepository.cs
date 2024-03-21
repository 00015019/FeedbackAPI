using Feedback_system.DAL;
using Feedback_system.Model;
using Microsoft.EntityFrameworkCore;


namespace Feedback_system.Repositories
{
    public class FeedbackRepository : IFeedbackRepository<Feedback>
    {
        private readonly FeedbackDbContext _context;
        public FeedbackRepository(FeedbackDbContext context)
        {
            _context = context;
        }


        public async Task AddAsync(Feedback entity)
        {
            await _context.cFeedbacks.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var a2dl = await _context.cFeedbacks.FindAsync(id);
            if (a2dl != null)
            {
                _context.cFeedbacks.Remove(a2dl);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Feedback>> GetAllAsync()
        {
            return await _context.cFeedbacks.ToArrayAsync();
        }

        public async Task<Feedback> GetByIDAsync(int id)
        {
            return await _context.cFeedbacks.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task UpdateAsync(Feedback entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
