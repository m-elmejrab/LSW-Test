using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SingletonOneScene<T> : MonoBehaviour where T : MonoBehaviour 
{
    public static T instance { get; private set; }

    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
        }
        else
            Destroy(gameObject);
    }

    protected virtual void OnApplicationQuit()
    {
        instance = null;
        Destroy(gameObject);
    }
    
}
