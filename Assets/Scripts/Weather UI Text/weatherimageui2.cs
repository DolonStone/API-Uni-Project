using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.Sprites;
using UnityEngine.U2D;
using System;
using static UnityEngine.Rendering.VirtualTexturing.Debugging;

public class weatherimageui2 : MonoBehaviour
{
    //public AssetReferenceSprite WeatherIcons;
    public Image Image;
    public AssetReferenceSprite weatherimage0, weatherimage1, weatherimage2, weatherimage3, weatherimage4, weatherimage5,
        weatherimage6, weatherimage7, weatherimage8, weatherimage9, weatherimage10,
        weatherimage11, weatherimage12, weatherimage13, weatherimage14, weatherimage15,
        weatherimage16, weatherimage17, weatherimage18, weatherimage19, weatherimage20
        , weatherimage21, weatherimage22;
    private string weathername = (APIHelper.GetWeather(APIHelper.GetLocation()).days[0].icon);
    private int arrayindex = 0;
    public string[] weathertypes = {
        "clear-day",
        "clear-night",
        "cloudy",
        "fog",
        "hail",
        "null",
        "partly-cloudy-day",
        "partly-cloudy-night",
        "rain",
        "showers-day",
        "showers-night",
        "snow",
        "snow-day",
        "snow-night",
        "snow-showers",
        "snow-showers-day",
        "snow-showers-night",
        "thunder",
        "thunder-rain",
        "thunder-showers-day",
        "thunder-showers-night",
        "wind"
        };
    //private string weathername = (APIHelper.GetWeather(APIHelper.GetLocation()).days[0].icon + ":UnityEngine.Sprite");
    //public string imageAddress;
    // Start is called before the first frame update
    void Start()
    {
        LoadAsset();
        FindWeather();
    }

    void LoadAsset()
    {
        //WeatherIcons.LoadAssetAsync().Completed += OnImageLoaded;
        weatherimage0.LoadAssetAsync().Completed += OnImageLoaded;
        weatherimage1.LoadAssetAsync().Completed += OnImageLoaded;
        weatherimage2.LoadAssetAsync().Completed += OnImageLoaded;
        weatherimage3.LoadAssetAsync().Completed += OnImageLoaded;
        weatherimage4.LoadAssetAsync().Completed += OnImageLoaded;
        weatherimage5.LoadAssetAsync().Completed += OnImageLoaded;
        weatherimage6.LoadAssetAsync().Completed += OnImageLoaded;
        weatherimage7.LoadAssetAsync().Completed += OnImageLoaded;
        weatherimage8.LoadAssetAsync().Completed += OnImageLoaded;
        weatherimage9.LoadAssetAsync().Completed += OnImageLoaded;
        weatherimage10.LoadAssetAsync().Completed += OnImageLoaded;
        weatherimage11.LoadAssetAsync().Completed += OnImageLoaded;
        weatherimage12.LoadAssetAsync().Completed += OnImageLoaded;
        weatherimage13.LoadAssetAsync().Completed += OnImageLoaded;
        weatherimage14.LoadAssetAsync().Completed += OnImageLoaded;
        weatherimage15.LoadAssetAsync().Completed += OnImageLoaded;
        weatherimage16.LoadAssetAsync().Completed += OnImageLoaded;
        weatherimage17.LoadAssetAsync().Completed += OnImageLoaded;
        weatherimage18.LoadAssetAsync().Completed += OnImageLoaded;
        weatherimage19.LoadAssetAsync().Completed += OnImageLoaded;
        weatherimage20.LoadAssetAsync().Completed += OnImageLoaded;
        weatherimage21.LoadAssetAsync().Completed += OnImageLoaded;
        weatherimage22.LoadAssetAsync().Completed += OnImageLoaded;
        //Addressables.LoadAssetAsync<Sprite>(weathername).Completed += OnImageLoaded;

    }

    private void OnImageLoaded(AsyncOperationHandle<Sprite> handle)
    {
        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            switch (arrayindex)
            {
                case 0:
                    weatherimage0.sprite = handle.Result;
                    break;
                case 1:
                    weatherimage1.sprite = handle.Result;
                    break;
                case 2:
                    weatherimage2.sprite = handle.Result;
                    break;
                case 3:
                    weatherimage3.sprite = handle.Result;
                    break;
                case 4:
                    weatherimage4.sprite = handle.Result;
                    break;
                case 5:
                    weatherimage5.sprite = handle.Result;
                    break;
                case 6:
                    weatherimage6.sprite = handle.Result;
                    break;
                case 7:
                    weatherimage7.sprite = handle.Result;
                    break;
                case 8:
                    weatherimage8.sprite = handle.Result;
                    break;
                case 9:
                    weatherimage9.sprite = handle.Result;
                    break;
                case 10:
                    weatherimage10.sprite = handle.Result;
                    break;
                case 11:
                    weatherimage11.sprite = handle.Result;
                    break;
                case 12:
                    weatherimage12.sprite = handle.Result;
                    break;
                case 13:
                    weatherimage13.sprite = handle.Result;
                    break;
                case 14:
                    weatherimage14.sprite = handle.Result;
                    break;
                case 15:
                    weatherimage15.sprite = handle.Result;
                    break;
                case 16:
                    weatherimage16.sprite = handle.Result;
                    break;
                case 17:
                    weatherimage17.sprite = handle.Result;
                    break;
                case 18:
                    weatherimage18.sprite = handle.Result;
                    break;
                case 19:
                    weatherimage19.sprite = handle.Result;
                    break;
                case 20:
                    weatherimage20.sprite = handle.Result;
                    break;
                case 21:
                    weatherimage21.sprite = handle.Result;
                    break;
                case 22:
                    weatherimage22.sprite = handle.Result;
                    break;
                default:
                    weatherimage5.sprite = handle.Result;
                    break;
            }
        }
        else
        {
            Debug.LogError("Failed to load adressable");
            Addressables.LoadAssetAsync<Sprite>(WeatherIcons).Completed += OnImageLoaded;

        }
    }

    public void FindWeather()
    {
        for (int i = 0; i < weathertypes.Length; i++)
        {
            if (weathertypes[i] == weathername)
            {
                arrayindex = i;
                Debug.Log("array: " + arrayindex);
                return;

            }
        }
        Debug.Log(weathertypes.Length);
        Debug.Log(weathertypes[arrayindex]);
    }

    /*public void ImageSwitchcase(AsyncOperationHandle<Sprite> handle)
    {
        switch (arrayindex)
        {
            case 0:
                weatherimage0.sprite = handle.Result;
                break;
            case 1:
                weatherimage1.sprite = handle.Result;
                break;
            case 2:
                weatherimage2.sprite = handle.Result;
                break;
            case 3:
                weatherimage3.sprite = handle.Result;
                break;
            case 4:
                weatherimage4.sprite = handle.Result;
                break;
            case 5:
                weatherimage5.sprite = handle.Result;
                break;
            case 6:
                weatherimage6.sprite = handle.Result;
                break;
            case 7:
                weatherimage7.sprite = handle.Result;
                break;
            case 8:
                weatherimage8.sprite = handle.Result;
                break;
            case 9:
                weatherimage9.sprite = handle.Result;
                break;
            case 10:
                weatherimage10.sprite = handle.Result;
                break;
            case 11:
                weatherimage11.sprite = handle.Result;
                break;
            case 12:
                weatherimage12.sprite = handle.Result;
                break;
            case 13:
                weatherimage13.sprite = handle.Result;
                break;
            case 14:
                weatherimage14.sprite = handle.Result;
                break;
            case 15:
                weatherimage15.sprite = handle.Result;
                break;
            case 16:
                weatherimage16.sprite = handle.Result;
                break;
            case 17:
                weatherimage17.sprite = handle.Result;
                break;
            case 18:
                weatherimage18.sprite = handle.Result;
                break;
            case 19:
                weatherimage19.sprite = handle.Result;
                break;
            case 20:
                weatherimage20.sprite = handle.Result;
                break;
            case 21:
                weatherimage21.sprite = handle.Result;
                break;
            case 22:
                weatherimage22.sprite = handle.Result;
                break;
            default:
                weatherimage5.sprite = handle.Result;
                break;


        }
    }*/
}
