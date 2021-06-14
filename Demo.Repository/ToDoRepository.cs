using Demo.DB;
using Demo.DB.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.Repository
{
    public class ToDoRepository : IToDoRepository
    {
        protected ToDoDbContext _context;
        protected DbSet<ToDo> DbSet;
        public ToDoRepository(ToDoDbContext context)
        {
            _context = context;
            DbSet = _context.Set<ToDo>();
        }
        public IEnumerable<ToDo> GetAllToDos()
        {
            return DbSet.AsEnumerable<ToDo>();
        }
    }
}
