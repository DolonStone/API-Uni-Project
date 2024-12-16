using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using Unity.AddressableAssets;


public class WeatherUI_changeimage : MonoBehaviour
{
    public Image weatherimage;
    private string weathertype = APIHelper.GetWeather(APIHelper.GetLocation()).days[0].icon;

    // Start is called before the first frame update
    void Start()
    {
        //weatherimage.sprite = newSprite;
        UpdateImage(weathertype); // calls the update image function taking the weather type from
        //Debug.Log(weathertype);
    }

    public void UpdateImage(string current_W)
    {
        Debug.Log(current_W + " image");
        //Sprite newSprite = Resources.Load<Sprite>("Assets / Images / " + current_W + "sprite.png");
        Sprite newSprite = Resources.Load<Sprite>(current_W + "sprite.png");
        //Sprite unknownsprite = Resources.Load<Sprite>("Assets / Images / unknownsprite.png");
        Sprite unknownsprite = Resources.Load<Sprite>("unknownsprite.png");
        Debug.Log("Assets / Images / " + current_W + "sprite.png");

        if (newSprite != null)
        {
            weatherimage.sprite = newSprite;
            Debug.Log("1");
        }

        else
        {
            weatherimage.sprite = unknownsprite;
            Debug.Log("0");
        }
    }
}
