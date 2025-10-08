using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lazyloading.Demo.TodoTasks
{
    public class TodoTaskUploadFileResultDto
    {
        public string FileName { get; set; }
        public string FileType { get; set; }
        public long FileSize { get; set; }
    }
}
