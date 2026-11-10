using System;

namespace myHeatingViewer.Services
{
    internal class CachedFile<T>
    {
        public DateTime LastWriteTime { get; set; }

        public T Data { get; set; }
    }
}
