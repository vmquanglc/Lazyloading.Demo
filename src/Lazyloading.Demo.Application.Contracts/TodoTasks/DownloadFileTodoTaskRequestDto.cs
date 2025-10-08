using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lazyloading.Demo.TodoTasks
{
    public class DownloadFileTodoTaskRequestDto
    {
        public Guid todoTaskId { get; set; }
        public Guid todoTaskUploadFileId { get; set; }
    }
}
