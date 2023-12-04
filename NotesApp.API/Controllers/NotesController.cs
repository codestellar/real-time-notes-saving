using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class NotesController : ControllerBase
{
    private readonly NotesDbContext _context;

    public NotesController(NotesDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult Post([FromBody] Note note)
    {

        if (note.Id > 0)
        {
            var existingNote = _context.Notes.FirstOrDefault(x => x.Id == note.Id);
            if (existingNote == null)
            {
                _context.Add(note);
            }
            else
            {
                existingNote.Content = note.Content;
            }
        }
        else
        {
            _context.Add(note);
        }


        _context.SaveChanges();

        return Ok(note);
    }

    [HttpGet]
    public IActionResult GetNotes()
    {
        return Ok(_context.Notes.ToList());
    }

    [HttpGet()]
    [Route("id")]
    public IActionResult GetNoteById([FromQuery] int id)
    {
        return Ok(_context.Notes.Where(x => x.Id == id).ToList());
    }

    // Implement CRUD operations...
}