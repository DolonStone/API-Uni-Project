using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deserialisejson : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string json = getipapijson.json;
        ipapijson ipresponse = JsonUtility.FromJson<ipapijson>(json);
        Debug.Log(ipresponse.status);
        Debug.Log(ipresponse.city);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
