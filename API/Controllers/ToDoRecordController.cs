using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoRecordController(DataContext context) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoRecord>>> GetToDoRecords(){

            var todoRecords = await context.ToDoRecords.ToListAsync();

            if(todoRecords == null){
                return NotFound();
            }

            return todoRecords;
        }

        [HttpGet("id/{Id:int}")]
        public async Task<ActionResult<ToDoRecord>> GetToDoRecordsByID(int Id){

            var todoRecord = await context.ToDoRecords.FindAsync(Id);

            if(todoRecord == null){
                return NotFound();
            }

            return todoRecord;
        }

        [HttpPost]
        public async Task<ActionResult> PostToDoRecords([FromBody] ToDoRecord toDoRecord){

            context.ToDoRecords.Add(toDoRecord);
            await context.SaveChangesAsync();

            return Ok("Data inserted Successfully");
        }

    }
}
