using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class APIResponseReader : MonoBehaviour
{
    [SerializeField] private GameObject plantNameResponsePrefab;
    [SerializeField] private TMP_InputField inputText;
    [SerializeField] private GameObject scrollBarContent;
    // Start is called before the first frame update
    private void Start()
    {
        inputText = gameObject.GetComponentInChildren<TMP_InputField>();
        scrollBarContent = GameObject.Find("Content");

    }
    public void SearchAPI()
    {
        foreach (Transform child in scrollBarContent.transform)
        {
            Destroy(child.gameObject);
        }
        
        PerenualResponse plantresponse = APIHelper.GetPlant(inputText.text);

        for(int i = 0; i < plantresponse.data.Length; i++)
        {
            
            GameObject prefab = Instantiate(plantNameResponsePrefab);
            prefab.transform.SetParent(scrollBarContent.transform);
            //prefab.transform.position = scrollBarContent.transform.position;
            prefab.transform.localPosition = new Vector3(255.46f, -26.8f, 0f);
            prefab.transform.localPosition += (new Vector3(0, -50, 0)) * i;
            prefab.GetComponentInChildren<PlantData>().data = plantresponse.data[i];



        }
        inputText.text = "";
    }
}
