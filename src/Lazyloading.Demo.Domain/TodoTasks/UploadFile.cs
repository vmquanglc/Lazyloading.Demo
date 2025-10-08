using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Lazyloading.Demo.TodoTasks
{
    public class UploadFile : AuditedEntity<Guid>
    {
        public Guid TodoTaskId { get; private set; }
        public string FileName { get; private set; }
        public string FileType { get; private set; }
        public long FileSize { get; private set; }//bytes
        public byte[] Content { get; private set; }

        // Navigation property
        public virtual TodoTask TodoTask { get; private set; }

        public UploadFile()
        {

        }
        public UploadFile(Guid todoTaskId, string fileName, string fileType, long fileSize, byte[] content)
        {
            TodoTaskId = todoTaskId;
            FileName = fileName;
            FileType = fileType;
            FileSize = fileSize;
            Content = content;
        }
    }
}
