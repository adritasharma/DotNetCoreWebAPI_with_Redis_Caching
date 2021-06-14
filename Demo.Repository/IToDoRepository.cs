using Demo.DB.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Repository
{
    public interface IToDoRepository
    {
        public IEnumerable<ToDo> GetAllToDos();
    }
}
