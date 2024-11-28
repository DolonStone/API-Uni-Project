using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test123 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        print(APIHelper.GetWeather(APIHelper.GetLocation()).days[0].icon);
    }


}
