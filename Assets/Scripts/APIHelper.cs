using UnityEngine;
using System.Net;
using System.IO;



public static class APIHelper
{
    
    public static (PerenualResponse, string) GetPlant(string plantName)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://perenual.com/api/species-list?key=sk-M3JX6734996178fc17621&q=" + plantName); //sends request to the link
        HttpWebResponse response = (HttpWebResponse)request.GetResponse(); //gets the response from the request
        StreamReader reader = new StreamReader(response.GetResponseStream()); //puts the responce in a reader
        string json = reader.ReadToEnd(); //reads the response into a string

        return (JsonUtility.FromJson<PerenualResponse>(json),json); //returns the responce

    }
}
