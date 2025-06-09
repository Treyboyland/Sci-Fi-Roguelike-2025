using System.Collections.Generic;
using UnityEngine;

public class GameEventGeneric<T> : GameEvent
{
    private List<GameEventListenerGeneric<T>> listeners = new List<GameEventListenerGeneric<T>>();

    public T Value;

    public void AddListener(GameEventListenerGeneric<T> listener)
    {
        listeners.Add(listener);
    }

    public void RemoveListener(GameEventListenerGeneric<T> listener)
    {
        listeners.Remove(listener);
    }

    public void Invoke(T val)
    {
        Value = val;
        Invoke();
    }

    public override void Invoke()
    {
        foreach (var listener in listeners)
        {
            if (listener != null)
            {
                listener.Response.Invoke(Value);
            }
        }
    }
}
