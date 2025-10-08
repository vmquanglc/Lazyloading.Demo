using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lazyloading.Demo.TodoTasks
{
    public class ListTodoTask
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public TodoTaskStatus Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int ChecklistCount { get; set; }
        public int UploadFileCount { get; set; }
    }
}
