using SCM.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SCM.Domain.Interfaces
{
    public interface INoteRepository
    {
        Task<List<Notes>> GetAsync();
        Task<Notes> GetAsync(int id);
        Task<Notes> CreateAsync(Notes note);
        Task<bool> UpdateAsync(int id, Notes note);
        Task<bool> RemoveAsync(int id);
    }
}
