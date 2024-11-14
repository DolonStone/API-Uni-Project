using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class APIResponseReader : MonoBehaviour
{

    public TextMeshProUGUI responseText;
    // Start is called before the first frame update
    void Start()
    {
        
        (PerenualResponse plantresponse,string output) = APIHelper.GetPlant("cucumber");
        //responseText.text = plantresponse.data[0,0];
        output.Replace("[", "");
        output.Replace("]", "");
        print(output);
        Debug.Log(plantresponse.data[0,0]);

    }


}
