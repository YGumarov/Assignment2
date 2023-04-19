namespace Assignment2;

public class LinkedList
{
    public class MyLinkedList<T> : IMyList<T>
    {
        private class Node
        {
            public T Data { get; set; }
            public Node Next { get; set; }
            public Node Prev { get; set; }

            public Node(T data)
            {
                Data = data;
                Next = null;
                Prev = null;
            }
        }

        private Node head;
        private Node tail;
        private int size;

        public MyLinkedList()
        {
            head = null;
            tail = null;
            size = 0;
        }

        public int Size()
        {
            return size;
        }

        public bool Contains(Object o)
        {
            Node current = head;
            while (current != null)
            {
                if (current.Data.Equals(o))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public void Add(T item)
        {
            Node newNode = new Node(item);
            if (tail == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                newNode.Prev = tail;
                tail = newNode;
            }

            size++;
        }

        public void Add(T item, int index)
        {
            if (index < 0 || index > size)
            {
                throw new IndexOutOfRangeException();
            }

            if (index == size)
            {
                Add(item);
            }
            else if (index == 0)
            {
                Node newNode = new Node(item);
                newNode.Next = head;
                head.Prev = newNode;
                head = newNode;
                size++;
            }
            else
            {
                Node current = head;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }

                Node newNode = new Node(item);
                newNode.Next = current;
                newNode.Prev = current.Prev;
                current.Prev.Next = newNode;
                current.Prev = newNode;
                size++;
            }
        }

        public bool Remove(T item)
        {
            Node current = head;
            while (current != null)
            {
                if (current.Data.Equals(item))
                {
                    if (current == head)
                    {
                        head = current.Next;
                        if (head != null)
                        {
                            head.Prev = null;
                        }
                    }
                    else if (current == tail)
                    {
                        tail = current.Prev;
                        tail.Next = null;
                    }
                    else
                    {
                        current.Prev.Next = current.Next;
                        current.Next.Prev = current.Prev;
                    }

                    size--;
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public T Remove(int index)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException();
            }

            Node current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            if (current == head)
            {
                head = current.Next;
                if (head != null)
                {
                    head.Prev = null;
                }
            }
            else if (current == tail)
            {
                tail = current.Prev;
                tail.Next = null;
            }
            else
            {
                current.Prev.Next = current.Next;
                current.Next.Prev = current.Prev;
            }

            size--;
            return current.Data;
        }

        public void Clear()
        {
            head = null;
            tail = null;
            size = 0;
        }

        public T Get(int index)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException();
            }

            Node current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            return current.Data;
        }

        public int Indexof(Object o)
        {
            Node current = head;
            for (int i = 0; i < size; i++)
            {
                if (current.Data.Equals(o))
                {
                    return i;
                }

                current = current.Next;
            }

            return -1;
        }

        public int Lastindexof(Object o)
        {
            Node current = tail;
            for (int i = size - 1; i >= 0; i--)
            {
                if (current.Data.Equals(o))
                {
                    return i;
                }

                current = current.Prev;
            }

            return -1;
        }

        public void Sort()
        {
            MyLinkedList<T> sortedList = new MyLinkedList<T>();

            Node current = head;
            while (current != null)
            {
                Node next = current.Next;
                if (sortedList.size == 0 || current.Data.Equals(sortedList.head.Data))
                {
                    sortedList.AddFirst(current.Data);
                }
                else
                {
                    Node sortedCurrent = sortedList.head;
                    while (sortedCurrent.Next != null && !current.Data.Equals(sortedCurrent.Next.Data))
                    {
                        sortedCurrent = sortedCurrent.Next;
                    }

                    sortedList.AddAfter(sortedCurrent, current.Data);
                }

                current = next;
            }

            head = sortedList.head;
            tail = sortedList.tail;
        }
        
        private void AddFirst(T item)
        {
            Node newNode = new Node(item);

            if (size == 0)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.Next = head;
                head.Prev = newNode;
                head = newNode;
            }

            size++;
        }

        private void AddAfter(Node node, T item)
        {
            Node newNode = new Node(item);

            newNode.Prev = node;
            newNode.Next = node.Next;
            if (node.Next == null)
            {
                tail = newNode;
            }
            else
            {
                node.Next.Prev = newNode;
            }
            node.Next = newNode;

            size++;
        }
    }
}