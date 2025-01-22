using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TFGSingleton<T> : TFGMonoBehaviour where T : TFGMonoBehaviour
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null) Debug.LogError("Singleton instance has not been created yet!");
            return _instance;
        }
    }

    protected override void Awake()
    {
        base.Awake();
        this.LoadInstance();
    }

    protected virtual void LoadInstance()
    {
        if (_instance == null)
        {
            _instance = this as T;
            DontDestroyOnLoad(gameObject);
            return;
        }

        if (_instance != this) Debug.LogError("Another instance of Singleton already exists!");
    }
}
