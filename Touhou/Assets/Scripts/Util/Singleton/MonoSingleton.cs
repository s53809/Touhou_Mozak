using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T m_instance;
    public static T Ins
    {
        get
        {
            if(m_instance == null)
            {
                m_instance = (T)FindFirstObjectByType(typeof(T));
                if(m_instance == null)
                {
                    var obj = new GameObject();
                    m_instance = obj.AddComponent<T>();
                    obj.name = $"{typeof(T)} ( Singleton )";
                    DontDestroyOnLoad(obj);
                }
            }
            return m_instance;
        }
    }

    protected virtual void Awake()
    {
        if (m_instance != null) Destroy(gameObject);
        else DontDestroyOnLoad(gameObject);
    }
}
