using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CourseApi.Data;
using CourseApi.Models;

namespace CourseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonsController : ControllerBase
    {
        private readonly CourseContext _context;

        public LessonsController(CourseContext context)
        {
            _context = context;
        }

        // GET: api/lessons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lesson>>> GetLessons()
        {
            return await _context.Lessons.Include(l => l.Videos).ToListAsync();
        }

        // GET: api/lessons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lesson>> GetLesson(int id)
        {
            var lesson = await _context.Lessons.Include(l => l.Videos).FirstOrDefaultAsync(l => l.Id == id);

            if (lesson == null)
            {
                return NotFound();
            }

            return lesson;
        }

        // POST: api/lessons
        [HttpPost]
        public async Task<ActionResult<Lesson>> PostLesson(Lesson lesson)
        {
            _context.Lessons.Add(lesson);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLesson", new { id = lesson.Id }, lesson);
        }

        // PUT: api/lessons/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLesson(int id, Lesson lesson)
        {
            if (id != lesson.Id)
            {
                return BadRequest();
            }

            _context.Entry(lesson).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LessonExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/lessons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLesson(int id)
        {
            var lesson = await _context.Lessons.FindAsync(id);
            if (lesson == null)
            {
                return NotFound();
            }

            _context.Lessons.Remove(lesson);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LessonExists(int id)
        {
            return _context.Lessons.Any(e => e.Id == id);
        }
    }
}
