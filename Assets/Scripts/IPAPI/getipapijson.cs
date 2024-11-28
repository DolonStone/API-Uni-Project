using System;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using JetBrains.Annotations;
using UnityEngine;

public class getipapijson : MonoBehaviour
{
    //static void Main(string[] args)
    void Start()
    {
        using (var client = new HttpClient())
        {
            var endpoint = new Uri("http://ip-api.com/json/?fields=status,city"); // set the api to a variable
            var result = client.GetAsync(endpoint).Result; // get the result from the api
            string json = result.Content.ReadAsStringAsync().Result;// read the json file result and store it as a variable
            Debug.Log(json); // print the json variable
            ipapijson ipresponse = JsonUtility.FromJson<ipapijson>(json);
            Debug.Log(ipresponse.status);
            Debug.Log(ipresponse.city);
        }
    }

}
