namespace Assignment2;

public interface IMyList<T>
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

    public void add(T item)
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
    
    public T remove(int index)
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
}