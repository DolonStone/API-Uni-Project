using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Collections;
using System.Net.Http;

public class APIConnector : MonoBehaviour
{
    //private string apiURL = "http://ip-api.com/json/?fields=status,city,query"; // Replace with your API URL

    static void Main(string[] args)
    {
        using(var client = new HttpClient())
        {
            var endpoint = new Uri("http://ip-api.com/json/?fields=status,city,query");
            var result = client.GetAsync(endpoint).Result;
            var json = result.Content.ReadAsStringAsync().Result;

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        // Start the API request coroutine
        //StartCoroutine(GetDataFromAPI());
    }

}
// gonna try and usee website https://youtu.be/Yi-O-HBGPeU?si=U_OJbBivDJw3DsV3 to help
