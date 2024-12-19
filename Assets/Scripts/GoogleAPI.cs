using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Google.Apis.Services;
using Google.Apis.CustomSearchAPI.v1;
using Google.Apis.CustomSearchAPI.v1.Data;
using Google.Apis.Requests;
using System;
using System.Threading.Tasks;
using UnityEngine.Networking;
using UnityEditor;
using static UnityEditor.Progress;
using System.IO;
using System.Net.Http;





public class GoogleAPI: MonoBehaviour
{
    private static string apiKey = "AIzaSyB_mBQObwFwO6h22mIoRfsrWi2FdHcx_HQ";
    private static string searchEngineId = "72d2bb3477cc34278";
    private static int numResults = 1;
    private static string URL;
    private static string Root = Application.persistentDataPath; // Ensure Root is initialized
    private static byte[] imageBytes;


    public static byte[] getImageBytes() {
        return imageBytes;  
    }


    private void Start()
    {
        Root = Application.persistentDataPath;
        URL = null;
    }


   

    public static async Task PerformCustomSearch(string query)
    {
        Debug.Log("Hello!");
        try
        {
            // Initialize Custom Search
            var customSearchService = new CustomSearchAPIService(new BaseClientService.Initializer
            {
                ApiKey = apiKey,
                ApplicationName = "NewCropSimAPI"
            });

            //Creates the query (we can alter the specifics - pretty sure we can filter for image formats) 
            var listRequest = customSearchService.Cse.List();
            listRequest.Q = query;
            listRequest.Cx = searchEngineId;
            listRequest.SearchType = CseResource.ListRequest.SearchTypeEnum.Image;
            listRequest.Num = numResults;

            Search searchResponse = await listRequest.ExecuteAsync().ConfigureAwait(false);

            if (searchResponse == null || searchResponse.Items == null)
            {
                Debug.Log("No results found.");
                return;
            }


            if (searchResponse.Items != null)
            {
                foreach (var item in searchResponse.Items)
                {

                    URL = item.Link;
                    Debug.Log(URL);
                    
                }
                await SaveImage(URL, query);
            }
            else
            {
                Debug.Log("No results found.");
            }
        }
        catch (Exception ex)
        {
            Debug.Log($"An error occurred: {ex.Message}");
        }
    }

    private static async Task SaveImage(string imageUrl, string fileName)
    {
        Debug.Log($"{imageUrl}");
        //Getting the image from the link and downloading it -> not sure if this is actually memory efficient -
        //will compare it to Beth's image code and see if I can improve it :))

        using (HttpClient imageClient = new HttpClient())
        {
            string filePath = Path.Combine(Root, $"{fileName}.png");
            Debug.Log(filePath);
            imageBytes = await imageClient.GetByteArrayAsync(imageUrl);
            await File.WriteAllBytesAsync(filePath, imageBytes);

            Debug.Log($"Image downloaded at {filePath}");
            


        }

    }
   

    public static Sprite UpdateSprite(byte[] imageBytes)
    {
        //Does what it says on the tin :)
        Texture2D plantTex = new Texture2D(2, 2);
        plantTex.LoadImage(imageBytes);
        Rect rect = new Rect(0, 0, 100, 100);
        Vector2 pivot = new Vector2(0.5f, 0.5f);
        Sprite sprite = Sprite.Create(plantTex, rect, pivot);
        Debug.Log("Updating sprite...");

        URL = null;
        return sprite;
    }


}
