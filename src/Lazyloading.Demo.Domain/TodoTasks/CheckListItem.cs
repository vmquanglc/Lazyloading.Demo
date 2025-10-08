using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Lazyloading.Demo.TodoTasks
{
    public class ChecklistItem : AuditedEntity<Guid>
    {
        // FK
        public Guid TodoTaskId { get; private set; }
        public string Content { get; private set; }
        public bool IsCompleted { get; private set; }

        // Navigation property (lazy loading) add Viirtual keyword
        public virtual TodoTask TodoTask { get; private set; }

        public ChecklistItem() { }
        public ChecklistItem(Guid id, Guid todoTaskId, string content, bool isCompleted) : base(id)
        {
            TodoTaskId = todoTaskId;
            Content = content;
            IsCompleted = isCompleted;
        }
    }
}
