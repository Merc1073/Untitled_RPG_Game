using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudLisInstance : MonoBehaviour
{

    static AudLisInstance instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }

        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
