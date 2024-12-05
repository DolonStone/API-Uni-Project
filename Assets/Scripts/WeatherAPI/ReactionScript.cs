using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactionScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(APIHelper.GetWeather(APIHelper.GetLocation()).days[0].icon == "snow")
        {
            Debug.Log("It's snowing");
        }
        if(APIHelper.GetWeather(APIHelper.GetLocation()).days[0].icon == "rain")
        {
            Debug.Log("It's raining");
        }
        if(APIHelper.GetWeather(APIHelper.GetLocation()).days[0].icon == "fog")
        {
            Debug.Log("It's foggy");
        }
        if(APIHelper.GetWeather(APIHelper.GetLocation()).days[0].icon == "wind")
        {
            Debug.Log("It's windy");
        }
        if(APIHelper.GetWeather(APIHelper.GetLocation()).days[0].icon == "cloudy")
        {
            Debug.Log("It's cloudy");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
