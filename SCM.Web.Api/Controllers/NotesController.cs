using Microsoft.AspNetCore.Mvc;
using SCM.Domain.Interfaces;
using SCM.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SCM.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INoteRepository _NoteRepository;

        public NotesController(INoteRepository noteRepository)
        {
            _NoteRepository = noteRepository;
        }

        [HttpGet]
        [Route("retriveallnotes")]
        public async Task<ActionResult<IEnumerable<Notes>>> GetAllNotes()
        {
            var result=  await _NoteRepository.GetAsync();

            if (result == null)
                return new NotFoundObjectResult("no notes found");

            return new OkObjectResult(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Notes>> GetNote(int id)
        {
            if (id <= 0)
                return BadRequest();

            var result = await _NoteRepository.GetAsync(id);

            if (result == null)
                return new NotFoundObjectResult("no note found");

            return new OkObjectResult(result);
        }


        [HttpPost]
        [Route("modifynote/{noteId}")]
        public async Task<IActionResult> PutEmployee(Notes notes, [FromQuery] int noteId)
        {
            if (noteId <= 0)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest();
                
            var result = await _NoteRepository.UpdateAsync(noteId,notes);

            if (!result)
                return new NotFoundObjectResult("no notes found to update");

            return new OkObjectResult(result);

         }

        [HttpPost]
        [Route("createnote")]
        public async Task<ActionResult<Notes>> PostEmployee(Notes notes)
        {
            if (ModelState.IsValid)
            {
                var result = await _NoteRepository.CreateAsync(notes);

                if (result == null || result.NoteId <= 0)
                    return new BadRequestObjectResult("`note able to create notes");

                return new OkObjectResult(result);
            }
            else
                return new BadRequestObjectResult("validation failed");
        }

        [HttpDelete("remove/{id}")]
        public async Task<ActionResult<bool>> DeleteEmployee(int id)
        {
            if (id <= 0)
                return BadRequest();

            var result = await _NoteRepository.RemoveAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return new OkResult();
        }

    }
}
