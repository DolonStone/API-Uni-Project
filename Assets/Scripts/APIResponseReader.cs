using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class APIResponseReader : MonoBehaviour
{
    public string[] test12 = { "test", "{test,1,2,3}" } ;
    public TextMeshProUGUI responseText;
    // Start is called before the first frame update
    void Start()
    {
        
        PerenualResponse plantresponse = APIHelper.GetPlant("Cucumis_sativus");
        
        //DataPerenualResponse data = JsonUtility.FromJson<DataPerenualResponse>(plantresponse.data[0]);
        print(plantresponse.data[0]);
        //responseText.text = plantresponse.data;

        //print(plantresponse.data[0].Length);
        //print(plantresponse.data);
        //print(plantresponse.to);
        //print(plantresponse.per_page);
        //print(plantresponse.current_page);
        //print(plantresponse.from);
        //print(plantresponse.last_page);
        //print(plantresponse.total);
    }


}
