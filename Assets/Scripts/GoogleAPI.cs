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





public class GoogleAPI : MonoBehaviour
{
    private static string apiKey = "AIzaSyDR1b5h2h3UW0TTiMI3zzbGw_R4OHbHHqE";
    private static string searchEngineId = "b13db8adca5f34f05";
    private static int numResults = 1;
    private bool isProcessing;
    private string URL; 
    private string Root;
    byte[] imageBytes;


    // Start is called before the first frame update
    void Start()
    {
        isProcessing = false;
        Root = Application.persistentDataPath;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isProcessing && Input.GetKeyDown(KeyCode.Space))
        {
            PerformCustomSearch("bellis perennis"); //Passed through the Query ->
                                                    //thought we could just call this method when needed?
        }
        if (imageBytes != null && isProcessing)
        {
            //Update Sprite MUST be called in the main thread (Unity gets funny if you try and change sprite within async)
            UpdateSprite(imageBytes); 
        }


    }

    public async Task PerformCustomSearch(string query)
    {
        Debug.Log("Hello!");
        isProcessing = true;
        try
        {
            // Initialize Custom Search
            var customSearchService = new CustomSearchAPIService(new BaseClientService.Initializer
            {
                ApiKey = apiKey,
                ApplicationName = "CropSim"
            });

            //Creates the query (we can alter the specifics - pretty sure we can filter for image formats) 
            var listRequest = customSearchService.Cse.List();
            listRequest.Q = query;
            listRequest.Cx = searchEngineId;
            listRequest.SearchType = CseResource.ListRequest.SearchTypeEnum.Image;
            listRequest.Num = numResults;

            Search searchResponse = await listRequest.ExecuteAsync().ConfigureAwait(false);
            Debug.Log("Hello");

            if (searchResponse.Items != null)
            {
                foreach (var item in searchResponse.Items)
                {

                    URL = item.Link;
                    await SaveImage(URL);
                }

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

    public async Task SaveImage(string imageUrl)
    {
        //Getting the image from the link and downloading it -> not sure if this is actually memory efficient -
        //will compare it to Beth's image code and see if I can improve it :))
        using (HttpClient imageClient = new HttpClient())
        {
            string filePath = Path.Combine(Root, "savedTexture.png"); 

            imageBytes = await imageClient.GetByteArrayAsync(imageUrl);
            await File.WriteAllBytesAsync(filePath, imageBytes);

            Debug.Log($"Image downloaded at {filePath}");
            


        }

    }
   

    private void UpdateSprite(byte[] imageBytes)
    {
        //Does what it says on the tin :)
        //This should probably be in the plant prefab but need to check with group :))
        Texture2D plantTex = new Texture2D(2, 2);
        plantTex.LoadImage(imageBytes);

        Rect rect = new Rect(0, 0, plantTex.width, plantTex.height);
        Vector2 pivot = new Vector2(0.5f, 0.5f);
        Sprite sprite = Sprite.Create(plantTex, rect, pivot);
        Debug.Log("Updating sprite...");

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        }
        spriteRenderer.sprite = sprite;
        isProcessing = false;
        URL = null;
    }


}
