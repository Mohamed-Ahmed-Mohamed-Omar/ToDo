using AutoMapper;
using Humanizer.Localisation;
using Microsoft.EntityFrameworkCore;
using ToDo_Zaher.Data;
using ToDo_Zaher.Data.Entity;
using ToDo_Zaher.Model;

namespace ToDo_Zaher.Services
{
    public class ToDoRep : IToDoRep
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ToDoRep(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Add(ToDoVM toDoVM)
        {
            var data = _mapper.Map<ToDo_E>(toDoVM);

            _context.toDo_Es.Add(data);
            _context.SaveChanges();
        }

        public async Task<IQueryable<ToDoVM>> Get()
        {
            var data = _context.toDo_Es.Select(m => new ToDoVM { Id = m.Id, Text = m.Text, Date = DateTime.Now });

            return data;
        }

        public async Task<ToDoVM> GetById(int id)
        {
            var data = await _context.toDo_Es.Where(a => a.Id == id)
                                             .Select(a => new ToDoVM { Id = a.Id, Text = a.Text, Date = DateTime.Now })
                                             .FirstOrDefaultAsync();

            return data;
        }

        public async Task Delete(ToDoVM toDoVM)
        {
            var data = _mapper.Map<ToDo_E>(toDoVM);

            _context.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;

            _context.SaveChanges();
        }

        public async Task Update(ToDoVM toDoVM)
        {
            var data = _mapper.Map<ToDo_E>(toDoVM);

            _context.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            _context.SaveChanges();
        }
    }
}
