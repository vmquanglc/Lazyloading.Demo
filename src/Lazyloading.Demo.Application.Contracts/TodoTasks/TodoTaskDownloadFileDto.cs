using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lazyloading.Demo.TodoTasks
{
    public class TodoTaskDownloadFileDto
    {
        public string FileName { get; private set; }
        public string FileType { get; private set; }
        public long FileSize { get; private set; }//bytes
        public byte[] Content { get; private set; }
    }
}
