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
    public static string apiKey = "AIzaSyDR1b5h2h3UW0TTiMI3zzbGw_R4OHbHHqE";
    public static string searchEngineId = "b13db8adca5f34f05";
    public static string query = "bellis perennis";
    public static int numResults = 1;
    private bool isProcessing;
    private string URL; 
    public string Root;
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
            PerformCustomSearch();
        }
        if (imageBytes != null && isProcessing)
        {
            UpdateSprite(imageBytes);
        }


    }

    async Task PerformCustomSearch()
    {
        Debug.Log("Hello!");
        isProcessing = true;
        try
        {
            // Initialize the Custom Search Service
            var customSearchService = new CustomSearchAPIService(new BaseClientService.Initializer
            {
                ApiKey = apiKey,
                ApplicationName = "CropSim"
            });


            var listRequest = customSearchService.Cse.List();
            listRequest.Q = query;
            listRequest.Cx = searchEngineId;
            listRequest.SearchType = CseResource.ListRequest.SearchTypeEnum.Image;
            listRequest.Num = 1;

            Search searchResponse = await listRequest.ExecuteAsync().ConfigureAwait(false);
            Debug.Log("Hello");

            if (searchResponse.Items != null)
            {
                foreach (var item in searchResponse.Items)
                {
                    Debug.Log($"Title: {item.Title}");
                    Debug.Log($"Link: {item.Link}");
                    URL = item.Link;
                    await SaveImage(URL);
                    Debug.Log("greetings");
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
