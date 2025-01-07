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
        var weathername = APIHelper.GetWeather(APIHelper.GetLocation()).days[0].icon;
        for (int i = 0; i < weathertypes.Length; i++)
        {
            if (weathertypes[i] == weathername)
            {
                GlobaliseInfo(i);
            }
        }
    }
    public int sun;
    public bool isRaining= false;
    public int weatherType;
    public bool isSnowing = false;
    public bool isFoggy=false;
    private string[] weathertypes = {
        "clear-day", "clear-night", "cloudy", "fog", "hail", "null",
        "partly-cloudy-day", "partly-cloudy-night", "rain", "showers-day",
        "showers-night", "snow", "snow-day", "snow-night", "snow-showers",
        "snow-showers-day", "snow-showers-night", "thunder", "thunder-rain",
        "thunder-showers-day", "thunder-showers-night", "wind"
    };
    private void GlobaliseInfo(int index)
    {
        int sunType;
        if (index == 0 || index == 21)
        {
            sunType = 3;
        }
        else if (index == 6 || index == 9 || index == 11 || index == 12)
        {
            sunType = 2;
        }
        else if (index == 2 || index == 3)
        {
            sunType = 1;
        }
        else
        {
            sunType = 0;
        }
        GlobalWeatherInfo.Instance.sun = sunType;
        if (index == 3)
        {
            GlobalWeatherInfo.Instance.isFoggy = true;
        }
        
        if (APIHelper.GetWeather(APIHelper.GetLocation()).days[0].preciptype != null)
        {
            
            if (APIHelper.GetWeather(APIHelper.GetLocation()).days[0].preciptype[0] == "rain")
            {
                GlobalWeatherInfo.Instance.isRaining = true;
            }
            if (APIHelper.GetWeather(APIHelper.GetLocation()).days[0].preciptype[0] == "snow")
            {
                GlobalWeatherInfo.Instance.isSnowing = true;
            }
        }

    }
}
