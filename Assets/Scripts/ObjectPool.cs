using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    Dictionary<MonoBehaviour, List<MonoBehaviour>> pool = new Dictionary<MonoBehaviour, List<MonoBehaviour>>();

    public T GetObject<T>(T prefab) where T : MonoBehaviour
    {
        if (!pool.ContainsKey(prefab))
        {
            return CreateObject(prefab);
        }
        var list = pool[prefab];
        foreach (var item in list)
        {
            if (!item.gameObject.activeInHierarchy)
            {
                return (T)item;
            }
        }
        return CreateObject(prefab);
    }

    private T CreateObject<T>(T prefab) where T : MonoBehaviour
    {
        var newObj = Instantiate(prefab, transform);
        newObj.gameObject.SetActive(false);
        if (!pool.ContainsKey(prefab))
        {
            pool.Add(prefab, new List<MonoBehaviour>() { newObj });
        }
        else
        {
            pool[prefab].Add(newObj);
        }
        return newObj;
    }
}
