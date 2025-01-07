using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeatherUI_changecity : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;

    // Start is called before the first frame update
    void Start()
    {
        // sets the text to the city given by the ip-api
        textMeshPro.text = APIHelper.GetLocation();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
