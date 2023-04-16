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
    private int size;

    public MyArrayList()
    {
        elements = new T[10];
        size = 0;
    }

    public int size()
    {
        return size;
    }

    public bool contanins(object o)
    {
        
    }

}