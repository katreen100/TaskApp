using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TaskApp.core;
using TaskApp.core.model;
using TaskApp.core.Reposatories;
using TaskApp.Ef.Reposatory;


namespace task.Ef
{
    public class UnitOfWork : Iunitofwork
    {
        public IbaseRepo<Taskmodel> Tasks { get; private set; }

        private readonly TaskContext _context;
        public UnitOfWork(TaskContext context)
        {
            _context = context;
            Tasks = new baseRepo<Taskmodel>(_context);
        }


        public int complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
