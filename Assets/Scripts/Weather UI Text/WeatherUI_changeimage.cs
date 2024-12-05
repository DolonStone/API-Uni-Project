using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeatherUI_changeimage : MonoBehaviour
{
    public Image weatherimage;
    public Sprite newSprite;
    // Start is called before the first frame update
    void Start()
    {
        weatherimage.sprite = newSprite;
        //6schangeimage(APIHelper.GetWeather(APIHelper.GetLocation()).days[0].icon);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadImageFromResources()
    {
        // Load a sprite from Resources/Images
        Sprite spriteFromResources = Resources.Load<Sprite>("Images/rainsprite");
        if (spriteFromResources != null)
        {
            weatherimage.sprite = spriteFromResources;
        }
    }

    public void changeimage(string current_W)
    {
        if (current_W == "rain")
        {
        }
    }
}
