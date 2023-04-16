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
        if (elements.Lenght == razmer)
        {
            T[] newElements = new T[razmer * 2];
            Array.Copy(elements, newElements, razmer);
            elements = newElements;
        }

        elements[razmer] = item;
        razmer++;
    }
    
    
}