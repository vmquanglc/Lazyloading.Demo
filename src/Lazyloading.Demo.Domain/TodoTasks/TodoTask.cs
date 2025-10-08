using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Lazyloading.Demo.TodoTasks
{
    public class TodoTask : AuditedAggregateRoot<Guid>
    {
        public string Title { get; private set; }
        public string? Description { get; private set; }
        public TodoTaskStatus Status { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }
        public virtual ICollection<ChecklistItem> ChecklistItems { get; private set; } = new List<ChecklistItem>();
        public virtual ICollection<UploadFile> UploadFiles { get; private set; } = new List<UploadFile>();
        public TodoTask()
        {

        }
        public TodoTask(Guid id, string title, string description, TodoTaskStatus status, DateTime startDate, DateTime endDate)
                : base(id)
        {
            Title = title;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            ChecklistItems = new List<ChecklistItem>();
            UploadFiles = new List<UploadFile>();
            Status = status;
        }
        public void AddChecklistItem(ChecklistItem content)
        {
            ChecklistItems.Add(content);
        }

        public void AddUploadFile( string fileName, string fileType, long fileSize, byte[] content)
        {
            UploadFiles.Add(new UploadFile(Id, fileName, fileType, fileSize, content));
        }

    }
}
