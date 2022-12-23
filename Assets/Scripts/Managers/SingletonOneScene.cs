using UnityEngine;

//instances are accessible in scene, get destroyed on scene change
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
