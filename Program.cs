namespace Assignment2;

public partial interface IMyList<T>
{
    int Size();
    bool Contains(Object o);
    void Add(T item);
    void Add(T item, int index);
    bool Remove(T item);
    T Remove(int index);
    void Clear();
    T Get(int index);
    int Indexof(Object o);
    int Lastindexof(Object o);
    void Sort();
}

public class MyArrayList<T> : IMyList<T>
{
    private T[] elements;
    private int razmer;

    public MyArrayList()
    {
        elements = new T[10];
        razmer = 0;
    }

    public int Size()
    {
        return razmer;
    }

    public bool Contains(object o)
    {
        for (int i = 0; i < razmer; i++)
        {
            if (elements[i].Equals(o))
            {
                return true;
            }
        }

        return false;
    }

    public void Add(T item)
    {
        if (elements.Length == razmer)
        {
            T[] newElements = new T[razmer * 2];
            Array.Copy(elements, newElements, razmer);
            elements = newElements;
        }

        elements[razmer] = item;
        razmer++;
    }

    public void Add(T item, int index)
    {
        if (index < 0 || index > razmer)
        {
            throw new IndexOutOfRangeException();
        }

        if (razmer == elements.Length)
        {
            T[] newElements = new T[2 * razmer];
            Array.Copy(elements, 0, newElements, 0, index);
            newElements[index] = item;
            Array.Copy(elements, index, newElements, index + 1, razmer - index);
            elements = newElements;
        }
        else
        {
            Array.Copy(elements, index, elements, index + 1, razmer - index);
            elements[index] = item;
        }

        razmer++;
    }
    
    public bool Remove(T item)
    {
        for (int i = 0; i < razmer; i++)
        {
            if (elements[i].Equals(item))
            {
                Array.Copy(elements, i + 1, elements, i, razmer - i - 1);
                razmer--;
                return true;
            }
        }
        return false;
    }
    
    public T Remove(int index)
    {
        if (index < 0 || index >= razmer)
        {
            throw new IndexOutOfRangeException();
        }
        T removedElement = elements[index];
        Array.Copy(elements, index + 1, elements, index, razmer - index - 1);
        razmer--;
        return removedElement;
    }

    public void Clear()
    {
        elements = new T[10];
        razmer = 0;
    }
    
    public T Get(int index)
    {
        if (index < 0 || index >= razmer)
        {
            throw new IndexOutOfRangeException();
        }
        return elements[index];
    }

    public int Indexof(object o)
    {
        for (int i = 0; i < razmer; i++)
        {
            if (elements[i].Equals(o))
            {
                return i;
            }
        }
        return -1;
    }

    public int Lastindexof(object o)
    {
        for (int i = razmer - 1; i >= 0; i--)
        {
            if (elements[i].Equals(o))
            {
                return i;
            }
        }
        return -1;
    }

    public void Sort()
    {
        Array.Sort(elements, 0, razmer);
    }
}

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
    
    public bool Contains(T item)
    {
        Node current = head;
        while (current != null)
        {
            if (current.Data.Equals(item))
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
}