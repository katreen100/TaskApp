using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.core.model;
using TaskApp.core.Reposatories;

namespace TaskApp.core
{
    public interface Iunitofwork:IDisposable
    {
        IbaseRepo<Taskmodel> Tasks {  get; }
        int complete();
    }
}
