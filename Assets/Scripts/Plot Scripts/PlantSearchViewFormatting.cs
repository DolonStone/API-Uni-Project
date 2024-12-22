using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlantSearchViewFormatting : MonoBehaviour
{
    private PlantData plantData;
    [SerializeField] private TextMeshProUGUI dataField;
    [SerializeField] private PlantScript plant;
    [SerializeField] private Image PlantPicture;
    void Start()
    {
        plantData = gameObject.GetComponent<PlantData>();
        gameObject.GetComponentInChildren<TextMeshProUGUI>().text = plantData.data.common_name;
        dataField.text += FormatDataToText(plantData.data);
        //plant = gameObject.GetComponentInChildren<PlantScript>();


    }


    async void ImageGen()
    {
        PlantPicture.sprite = await APIHelper.GetImage(plantData.data.scientific_name[0].ToString());
        PlantPicture.preserveAspect = true;
        Debug.Log("GENERATED");
    }

    public void ShowData()
    {
        ImageGen();
        GiveDataToPlant(plantData.data, plant);
        GameObject responseDataObject = dataField.gameObject.transform.parent.gameObject;
        if (responseDataObject.activeSelf)
        {
            responseDataObject.SetActive(false);
            responseDataObject.transform.SetParent(gameObject.transform.parent);
        }
        else
        {
            responseDataObject.SetActive(true);
            responseDataObject.transform.SetParent(gameObject.transform.parent.parent);
            responseDataObject.transform.SetSiblingIndex(gameObject.transform.parent.transform.GetSiblingIndex() + 1);
        }
        
        
    }
    public string FormatDataToText(DataPerenualResponse data)
    {
        string outPut = data.id + "\n";

        for (int i = 0; i < data.scientific_name.Length; i++)
        {
            outPut += data.scientific_name[i];
        }
        outPut += "\n";

        for (int i = 0; i < data.other_name.Length; i++)
        {
            outPut += data.other_name[i];
            if (i > 3)
            {
                break;
            }
        }
        outPut += "\n";
        outPut += data.cycle + "\n";
        outPut += data.watering + "\n";

        for (int i = 0; i < data.sunlight.Length; i++)
        {
            outPut += data.sunlight[i];
        }


        return outPut;
    }
    public void GiveDataToPlant(DataPerenualResponse data, PlantScript plant)
    {

        plant.ParseParenialResponse(data);
    }
}
