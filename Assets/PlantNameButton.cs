using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlantNameButton : MonoBehaviour
{
    private TextMeshProUGUI buttonText;
    private PlantScript plantScript;
    [SerializeField] private GameObject simpleData;
    // Start is called before the first frame update
    void Start()
    {
        buttonText = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        plantScript = gameObject.GetComponentInParent<PlantScript>();
        buttonText.text = plantScript.GetName();
        var plantdata = plantScript.GetPlantData();
        simpleData.GetComponentInChildren<TextMeshProUGUI>().text = plantdata.sunlight[0] + "\n\n" + plantdata.watering + "\n\n" + plantdata.cycle;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FlipSimpleDataActive()
    {
        if (simpleData.activeSelf)
        {
            simpleData.SetActive(false);
        }
        else
        {
            simpleData.SetActive(true);
        }
    }
}
