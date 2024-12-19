using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalWeatherInfo : MonoBehaviour
{
    private static GlobalWeatherInfo instance;

    public static GlobalWeatherInfo Instance { get { return instance; } }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    public int sun = 1;

}
