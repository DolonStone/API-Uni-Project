using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class APIConnector : MonoBehaviour
{
    private string apiURL = "http://ip-api.com/json/?fields=status,lon,lat,query"; // Replace with your API URL

    // Start is called before the first frame update
    void Start()
    {
        // Start the API request coroutine
        //StartCoroutine(GetDataFromAPI());
    }

    // Coroutine to make the GET request
    IEnumerator GetDataFromAPI()
    {
        // Send the GET request to the API
        using (UnityWebRequest request = UnityWebRequest.Get(apiURL))
        {
            // Wait for the request to complete
            yield return request.SendWebRequest();

            // Check for errors
            if (request.isNetworkError || request.isHttpError)
            {
                Debug.LogError("Error: " + request.error);
            }
            else
            {
                // Parse the response
                string response = request.downloadHandler.text;
                Debug.Log("Response from API: " + response);

                // You can further process the response, e.g., parsing JSON:
                //YourJsonData myData = JsonUtility.FromJson<YourJsonData>(response);
            }
        }
    }
}