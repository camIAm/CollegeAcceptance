using System;
using System.Collections.Generic;

// modify for identifiing canidates

// I had a slightly more complicated case where I wanted a base class 
// to implement the non generic interface explicitly and a derived class implement the generic interface.
public interface IIdentifiable<TKey> : IIdentifiable
{
    TKey Id { get; }
}

public interface IIdentifiable
{
    object Id { get; }
}
// I solved it by declaring an abstract getter method in the base class and letting the explicit 
// implementation call it:
public abstract class ModelBase : IIdentifiable
{
    object IIdentifiable.Id
    {
        get { return GetId();  }
    }

    protected abstract object GetId();
}
// Note that the base class does not have the typed version of Id it could call.

public class Product : ModelBase, IIdentifiable<int>
{
    public int ProductID { get; set; }

    public int Id
    {
        get { return ProductID; }
    }

    protected override object GetId()
    {
        return Id;
    }
}