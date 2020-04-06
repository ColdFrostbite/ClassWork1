using System;
using System.Collections;


namespace LinkedList.Model
{
    public  class LinkedList<T> : IEnumerable
    {
        public Item<T> Head { get; private set; }
        public Item<T> Tail { get; private set; }
        public int Count { get; private set; }

        public LinkedList()
        {
            Clear();
        }

        public LinkedList(T data)
        {        
            SetHeadAndTail(data);
        }

        public void Add(T data)
        {
            
            if(Tail != null)
            {
                var item = new Item<T>(data);
                Tail.Next = item;
                Tail = item;
                Count++;
            }
            else
            {
                SetHeadAndTail(data);
            }
        }

        public void Delete(T data)
        {
            if(Head != null)
            {
                if(Head.Data.Equals(data))
                {
                    Head = Head.Next;
                    Count--;
                    return;
                }

                var current = Head.Next;
                var previous = Head;


                while (current.Next != null)
                {
                    if(current.Data.Equals(data))
                    {
                        previous.Next = current.Next;
                        Count--;

                    }

                    previous = current;
                    current = current.Next;
                }

            }
            else
            {
                SetHeadAndTail(data);
            }
        }

        public void AppendHead(T data)
        {
            var item = new Item<T>(data);
            item.Next = Head;
            Head = item;
            Count++;
        }

        public void InsertAfter(T target, T data)
        {

            var item = new Item<T>(data);
            var current = Head;
            if (current.Equals(data))
            {
                item.Next = Head.Next;
                Head.Next = item;
                Count++;
                return;
            }
            else
            {
                current = current.Next;
            }

            
            var previous = Head;


            while (current.Next != null)
            {
                if (current.Data.Equals(data))
                {
                    previous.Next = current.Next;
                    Count--;

                }

                previous = current;
                current = current.Next;
            }
        }


        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        private void SetHeadAndTail(T data)
        {
            var item = new Item<T>(data);
            Head = item;
            Tail = item;
            Count = 1;
        }

        private void ClearAll()
        {
           
        }

        public IEnumerator GetEnumerator()
        {
            var current = Head;
            while(current != null)
            {
                yield return current.Data;
                current = current.Next;
            }

        }

        public override string ToString()
        {
            return "Linked List" + Count + "Элементов";

        }
    }
}
