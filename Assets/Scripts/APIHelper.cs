using UnityEngine;
using System.Net;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;


public static class APIHelper
{
    
    public static PerenualResponse GetPlant(string plantName)
    {
        HttpWebRequest firstrequest = (HttpWebRequest)WebRequest.Create("https://perenual.com/api/species-list?key=sk-M3JX6734996178fc17621&q=" + plantName); //sends request to the link
        HttpWebResponse firstresponse = (HttpWebResponse)firstrequest.GetResponse(); //gets the response from the request
        StreamReader firstreader = new StreamReader(firstresponse.GetResponseStream()); //puts the responce in a reader
        string firstjson = firstreader.ReadToEnd(); //reads the response into a string
        
        PerenualResponse firstResponse = JsonUtility.FromJson<PerenualResponse>(firstjson);

        List<DataPerenualResponse[]> allDataResponses = new List<DataPerenualResponse[]>();
        allDataResponses.Add(firstResponse.data);
        for (int i = 1; i < firstResponse.last_page;i++)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://perenual.com/api/species-list?key=sk-M3JX6734996178fc17621&q=" + plantName+"&page="+i); //sends request to the link
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

    }
    public static weatherapijson GetWeather(string location)
    {

    }
}
