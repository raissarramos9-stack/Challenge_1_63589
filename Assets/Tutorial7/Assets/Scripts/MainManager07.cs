using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager07 : MonoBehaviour
{
    public static MainManager07 Instance;

    public Color TeamColor;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}