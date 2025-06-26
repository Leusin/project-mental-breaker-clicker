using UnityEngine;

public abstract class CGSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    private static readonly object lockObj = new object();

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                lock (lockObj)
                {
                    instance = FindFirstObjectByType<T>();

                    if (instance == null)
                    {
                        GameObject singletonObj = new GameObject(typeof(T).Name);
                        instance = singletonObj.AddComponent<T>();
                        DontDestroyOnLoad(singletonObj);
                    }
                }
            }
            return instance;
        }
    }

    protected virtual void Awake()
    {
        // 중복 인스턴스 제거
        if (instance == null)
        {
            instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        
        OnAwake();
    }

    protected virtual void OnAwake() { }
}
