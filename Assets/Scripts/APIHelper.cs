using UnityEngine;
using System.Net;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System;
using System.Numerics;
using System.Threading.Tasks;





public static class APIHelper
{
    public static PerenualResponse GetPlant(string plantName)
    {
        HttpWebRequest firstrequest = (HttpWebRequest)WebRequest.Create("https://perenual.com/api/species-list?key=sk-c5lj6762bf40387307981&q=" + plantName); //sends request to the link
        HttpWebResponse firstresponse = (HttpWebResponse)firstrequest.GetResponse(); //gets the response from the request
        StreamReader firstreader = new StreamReader(firstresponse.GetResponseStream()); //puts the responce in a reader
        string firstjson = firstreader.ReadToEnd(); //reads the response into a string

        PerenualResponse firstResponse = JsonUtility.FromJson<PerenualResponse>(firstjson);

        List<DataPerenualResponse[]> allDataResponses = new List<DataPerenualResponse[]>();
        allDataResponses.Add(firstResponse.data);
        for (int i = 1; i < firstResponse.last_page; i++)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://perenual.com/api/species-list?key=sk-c5lj6762bf40387307981&q=" + plantName + "&page=" + i); //sends request to the link
            HttpWebResponse response = (HttpWebResponse)request.GetResponse(); //gets the response from the request
            StreamReader reader = new StreamReader(response.GetResponseStream()); //puts the responce in a reader
            string json = reader.ReadToEnd(); //reads the response into a string

            allDataResponses.Add(JsonUtility.FromJson<PerenualResponse>(json).data);

        }
        firstResponse.data = allDataResponses.SelectMany(array => array).ToArray();

        return firstResponse; //returns the responce


    }

    public static string GetLocation()
    {
        using (var client = new HttpClient())
        {
            var endpoint = new Uri("http://ip-api.com/json/?fields=status,city"); // set the api to a variable
            var result = client.GetAsync(endpoint).Result; // get the result from the api
            string json = result.Content.ReadAsStringAsync().Result;// read the json file result and store it as a variable
            //Debug.Log(json); // print the json variable
            ipapijson ipresponse = JsonUtility.FromJson<ipapijson>(json);
            //Debug.Log(ipresponse.status);
            //Debug.Log(ipresponse.city);
            if (ipresponse.status == "success")
            {
                return ipresponse.city;
            }

            else
            {
                return null;
            }
        }
    }
    public static weatherapijson GetWeather(string location)
    {
        using (var client = new HttpClient())
        {
            var endpoint = new Uri("https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/timeline/"+ location +"?unitGroup=metric&elements=temp%2Cpreciptype%2Cconditions%2Cicon&include=current%2Cfcst&key=466QJLZG8Q4DZBHSXG7V2ZLJV&options=nonulls%2Cstnslevel1&contentType=json"); // set the api to a variable
            var result = client.GetAsync(endpoint).Result; // get the result from the api
            string json = result.Content.ReadAsStringAsync().Result;// read the json file result and store it as a variable
            //Debug.Log(json); // print the json variable
            weatherapijson weatherresponse = JsonUtility.FromJson<weatherapijson>(json);
            //Debug.Log(weatherresponse.days[0].preciptype[0]);
            //Debug.Log(weatherresponse.address);
            //Debug.Log(weatherresponse.days[0].temp);
            //Debug.Log(weatherresponse.days[0].conditions);
            //Debug.Log(weatherresponse.days[0].icon);
            return weatherresponse;
        }
    }

    public static async Task<Sprite> GetImage(string Query)
    {
        await GoogleAPI.PerformCustomSearch(Query);
        return GoogleAPI.UpdateSprite(GoogleAPI.getImageBytes());
    }



}
