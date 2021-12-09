using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace StackRealization
{
    class WeirdList<T> : IEnumerable<T>
    {
        private WeirdListItem<T> head;
        private WeirdListItem<T> tail;
        private int count = 0;

        public int Count { get { return count; } }
        private bool Empty { get { return count == 0; } }
        public void AddFirst(WeirdListItem<T> item)
        {
            if (Empty) tail = item;

            head.Previous = item;
            item.Next = head;
            head = item;
            count++;
        }
        public void Add(WeirdListItem<T> item) 
        {
            if (Empty)
            {
                head = item;
                tail = item;
                item.Previous = null;
                item.Next = null;
            }
            head.Next = item;
            item.Previous = head;
            tail = item;
            count++;
        }
        public void AddLast(WeirdListItem<T> item)
        {
            if (Empty) head = item;

            item.Previous = tail;
            tail.Next = item;
            tail = item;
            count++;
        }
        public void Delete(WeirdListItem<T> item)
        {
            if (Empty) throw new Exception();

            WeirdListItem<T> current = head;
            while (current != null)
            {
                if(current == item)
                {
                    if (current == head)
                    {
                        head = head.Next;
                        head.Previous = null;
                        count--;
                    }
                    else if(current == tail)
                    {
                        tail = tail.Previous;
                        tail.Next = null;
                        count--;
                    }
                    else 
                    {
                        current.Previous.Next = current.Next;
                        current.Next.Previous = current.Previous;
                        count--;
                    }
                }
                current = current.Next;
            }
        }
        public void DeleteLast()
        {
            if (Empty) throw new Exception();
            if (count == 1)
            {
                head = null;
                tail = null;
            }
            else if(count > 1)
            {
                tail = tail.Previous;
                tail.Next = null;
            }
            count--;
        }
        public void DeleteFirst()
        {
            if (Empty) throw new Exception();
            if (count == 1)
            {
                head = null;
                tail = null;
            }
            else
            {
                head = head.Next;
                head.Previous = null;
            }
            count--;
        }
        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            WeirdListItem<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public IEnumerable<T> BackEnumerator()
        {
            WeirdListItem<T> current = tail;
            while (current != null)
            {
                yield return current.Data;
                current = current.Previous;
            }
        }
    }
}
