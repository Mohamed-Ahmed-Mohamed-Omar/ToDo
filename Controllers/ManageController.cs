using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Diagnostics.CodeAnalysis;
using ToDo_Zaher.Data.Entity;
using ToDo_Zaher.Model;
using ToDo_Zaher.Services;

namespace ToDo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageController : ControllerBase
    {
        private readonly IToDoRep _rep;

        public ManageController(IToDoRep rep)
        {
            _rep = rep;
        }

        [HttpPost]
        [Route("~/api/Manage/Create")]
        public async Task<IActionResult> Create(ToDoVM toDo)
        {
            var data = new ToDoVM { Date = DateTime.Now, Text = toDo.Text };

            await _rep.Add(data);

            return Ok(data);
        }

        [HttpGet]
        [Route("~/api/Manage/GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var data = await _rep.Get();

            return Ok(data);
        }

        [HttpPut]
        [Route("~/api/Manage/Update/{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] ToDoVM genre)
        {
            var data = await _rep.GetById(id);

            if (data == null)
            {
                return NotFound($"No found with ID: {id}");
            }

            data.Text = genre.Text;

            _rep.Update(data);

            return Ok(data);
        }

        [HttpDelete]
        [Route("~/api/Manage/Delete/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var data = await _rep.GetById(id);

            if (data == null)
            {
                return NotFound($"No found with ID: {id}");
            }

            _rep.Delete(data);

            return Ok(data);
        }
    }
}