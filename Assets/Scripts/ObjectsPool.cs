using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsPool<T> where T:MonoBehaviour
{
    public T prefab { get; }
    public bool autoExpand { get; set; }
    public Transform container { get; }
    private List<T> pool;



    public ObjectsPool(T prefab, int count, Transform container)
    {
        this.prefab = prefab;
        this.container = container;
        CreatePool(count);
    }

    private void CreatePool(int count)
    {
        pool = new List<T>();
        for (int i = 0; i < count; i++)
        {
            CreateObjectInPool();
        }
    }

    private T CreateObjectInPool(bool defaultInActive = false)
    {
        T objInPool = UnityEngine.Object.Instantiate(prefab, container);
        objInPool.gameObject.SetActive(defaultInActive);
        pool.Add(objInPool);
        return objInPool;
    }

    private bool HasFreeElement(out T element)
    {
        foreach (T obj in pool)
        {
            if (!obj.gameObject.activeInHierarchy)
            {
                element = obj;
                element.gameObject.SetActive(true);
                return true;
            }
        }
        element = null;
        return false;
    }

    public T GetFreeElement()
    {
        if (HasFreeElement(out var element))
        {
            return element;
        }

        if (autoExpand)
            return CreateObjectInPool(true);
        else
            throw new Exception("Not autoexpand");
    }

}
