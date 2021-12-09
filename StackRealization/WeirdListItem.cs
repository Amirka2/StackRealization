using System;
using System.Collections.Generic;
using System.Text;

namespace StackRealization
{
    class WeirdListItem<T>
    {
        public T Data { get; set; }
        public WeirdListItem(T data)
        {
            Data = data;
        }
        public WeirdListItem<T> Next { get; set; }
        public WeirdListItem<T> Previous { get; set; }

    }
}
