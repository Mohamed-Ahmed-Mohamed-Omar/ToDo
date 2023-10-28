using AutoMapper;
using ToDo_Zaher.Data.Entity;

namespace ToDo_Zaher.Model
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<ToDo_E, ToDoVM>();
            CreateMap<ToDoVM, ToDo_E>();
        }
    }
}
