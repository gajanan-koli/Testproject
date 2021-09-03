using Microsoft.EntityFrameworkCore;
using SCM.Domain.Interfaces;
using SCM.Domain.Models;
using SCM.Repository.Dbcontext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SCM.Repository.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private ApplicationContext _context;

        public NoteRepository(ApplicationContext applicationContext)
        {
            _context = applicationContext;
        }
        
        public async Task<Notes> CreateAsync(Notes note)
        {
            _context.Notes.Add(note);
            await _context.SaveChangesAsync();

            return note;
        }

        public async Task<List<Notes>> GetAsync()
        {
            var result = await _context.Notes.ToListAsync();

            if (result == null || result.Count <= 0)
                return null;

            return result;
        }

        public async Task<Notes> GetAsync(int id)
        {
            var result = await _context.Notes.FindAsync(id);

            if (result == null)
            {
                return null;
            }

            return result;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var notes = await _context.Notes.FindAsync(id);
            if (notes == null)
            {
                return false;
            }

            _context.Notes.Remove(notes);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateAsync(int id, Notes note)
        {
            _context.Entry(note).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (! await EmployeeExists(note.NoteId))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return true;
        }

        private async Task< bool> EmployeeExists(int id)
        {
            return await _context.Notes.AnyAsync(e => e.NoteId == id);
        }
    }
}
