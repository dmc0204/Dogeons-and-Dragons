using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RuntimeSet<T> : ScriptableObject
{
    public List<T> Things = new List<T>();
    public void Add(T t) {
        if(!Things.Contains(t)) Things.Add(t);
    }
    public void Remove(T t){
        if (Things.Contains(t)) Things.Remove(t);
    }
}
