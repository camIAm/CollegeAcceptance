using System.Collections.Generic;
using System.Collections;

class ObservableList<T> : IList<T>
{
    private readonly IList<T> _list = new List<T>();

    #region Implementation of IEnumerable
    public IEnumerator<T> GetEnumerator()
    {
        foreach (var s in _list)
        {
            yield return s;
        }
        //return _list.GetEnumerator();
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
    #endregion
    #region Implementation of ICollection<T>
    public void Add(T item)
    {
        _list.Add(item);
    }
    public void Clear()
    {
        _list.Clear();
    }
    public bool Contains(T item)
    {
        return _list.Contains(item);
    }
    public void CopyTo(T[] array, int arrayIndex)
    {
        _list.CopyTo(array, arrayIndex);
    }
    public bool Remove(T item)
    {
        return _list.Remove(item);
    }
    public int Count
    {
        get { return _list.Count; }
    }
    public bool IsReadOnly
    {
        get { return _list.IsReadOnly; }
    }
    #endregion
    #region Implementation of IList<T>
    public int IndexOf(T item)
    {
        return _list.IndexOf(item);
    }
    public void Insert(int index, T item)
    {
        _list.Insert(index, item);
    }
    public void RemoveAt(int index)
    {
        _list.RemoveAt(index);
    }
    public T this[int index]
    {
        get { return _list[index]; }
        set { _list[index] = value; }
    }
    #endregion
    #region Your Added Stuff
    // Add new features to your collection.
    #endregion
}