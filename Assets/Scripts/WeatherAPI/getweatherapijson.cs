using System;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class getweatherapijson : MonoBehaviour
{
    //static void Main(string[] args)
    public string getWeather(string ipresponsecity)
    {
        using (var client = new HttpClient())
        {
            var endpoint = new Uri("https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/timeline/"+ ipresponsecity +"?unitGroup=metric&elements=temp%2Cpreciptype%2Cconditions%2Cicon&include=current%2Cfcst&key=466QJLZG8Q4DZBHSXG7V2ZLJV&options=nonulls%2Cstnslevel1&contentType=json"); // set the api to a variable
            var result = client.GetAsync(endpoint).Result; // get the result from the api
            string json = result.Content.ReadAsStringAsync().Result;// read the json file result and store it as a variable
            Debug.Log(json); // print the json variable
            weatherapijson weatherresponse = JsonUtility.FromJson<weatherapijson>(json);
            Debug.Log(weatherresponse.days[0].preciptype[0]);
            Debug.Log(weatherresponse.address);
            Debug.Log(weatherresponse.days[0].temp);
            Debug.Log(weatherresponse.days[0].conditions);
            Debug.Log(weatherresponse.days[0].icon);
            return weatherresponse.days[0].icon;
        }
    }

}
