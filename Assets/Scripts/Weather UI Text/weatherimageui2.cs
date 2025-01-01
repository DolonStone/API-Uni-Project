using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class WeatherImageUI2 : MonoBehaviour
{
    public Image Image;
    public AssetReferenceSprite[] weatherImages;  // Array of AssetReferenceSprites
    private string weathername;
    private int arrayindex = 0;

    private string[] weathertypes = {
        "clear-day", "clear-night", "cloudy", "fog", "hail", "null",
        "partly-cloudy-day", "partly-cloudy-night", "rain", "showers-day",
        "showers-night", "snow", "snow-day", "snow-night", "snow-showers",
        "snow-showers-day", "snow-showers-night", "thunder", "thunder-rain",
        "thunder-showers-day", "thunder-showers-night", "wind"
    };

    // Start is called before the first frame update
    void Start()
    {
        weathername = APIHelper.GetWeather(APIHelper.GetLocation()).days[0].icon;
        FindWeather();
        LoadWeatherImage();
    }

    // Load the relevant weather image asynchronously
    void LoadWeatherImage()
    {
        if (arrayindex < 0 || arrayindex >= weatherImages.Length) // checking that findweather has executed properly
        {
            Debug.LogError("Invalid weather type index");
            return;
        }

        weatherImages[arrayindex].LoadAssetAsync().Completed += OnImageLoaded;
    }

    // Callback when the image has been loaded
    private void OnImageLoaded(AsyncOperationHandle<Sprite> handle)
    {
        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            Image.sprite = handle.Result;
        }
        else
        {
            Debug.LogError("Failed to load addressable sprite");
        }
    }

    // Find the index corresponding to the weather type
    void FindWeather()
    {
        for (int i = 0; i < weathertypes.Length; i++)
        {
            if (weathertypes[i] == weathername)
            {
                arrayindex = i;
                Debug.Log("Weather found: " + weathername + " at index: " + arrayindex);
                return;
            }
        }

        Debug.LogWarning("Weather type not found, defaulting to index 0");
        arrayindex = 5; // Default to clear-day if not found
    }
}

