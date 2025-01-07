using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class WeatherUI_changewtext : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;

    // Start is called before the first frame update
    void Start()
    {
        //sets text to the weather returned by the weather api
        textMeshPro.text = APIHelper.GetWeather(APIHelper.GetLocation()).days[0].icon;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
