using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlantScript : MonoBehaviour,IPointerClickHandler
{
    //Attributes
    public bool isGrowing = false;
    private bool planted = false;
    PlantBaseState currentState;
    PlantSeedState seedState = new PlantSeedState();
    PlantGrowingState growingState = new PlantGrowingState();
    PlantHarvestState plantHarvestState = new PlantHarvestState();
    PlantDeadState deadState = new PlantDeadState();
    [SerializeField]
    private float WateredPercentage = 50;

    private string PlantName;
    private WaterNeed WaterNeed;
    private SunlightNeed SunlightNeed;
    private GrowthRate cycle;
    
    private float growthRate;
    private DataPerenualResponse plantData;
    private Slider waterBar;
    private Slider growBar;
    private Slider sunBar;
    private GameObject plantMenu;
    private float timer = 0.0f;
    private float currentGrowTime;

    // Start is called before the first frame update
    void Start()
    {
        WateredPercentage = 50;
        currentState = seedState;
        currentState.EnterState(this);

        FindSliders();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("space"))
        {
            WateredPercentage = 100;

        }
        

        if(planted == true)
        {
            TickPlant();
        }
        
    }
    private void FindSliders()
    {
        Slider[] sliders = GetComponentsInChildren<Slider>(true);
        for (int i = 0; i < sliders.Length; i++)
        {
            if (sliders[i].gameObject.name == "Water")
            {
                waterBar = sliders[i];
            }
            else if (sliders[i].gameObject.name == "Growth")
            {
                growBar = sliders[i];
            }
            else if (sliders[i].gameObject.name == "Sun")
            {
                sunBar = sliders[i];
            }
        }
        plantMenu = GetComponentsInChildren<Transform>(true)[1].gameObject;
    }
    private void TickPlant()
    {
        currentState.UpdateState(this);

        timer += Time.deltaTime;
        if (timer > 1)
        {
            if (GlobalWeatherInfo.Instance.isRaining)
            {
                WateredPercentage = (float)(WateredPercentage * (1 + ((float)(int)WaterNeed / 100)));
            }
            else
            {
                WateredPercentage = (float)(WateredPercentage * (1 - ((float)(int)WaterNeed / 100)));
            }
            UpdateSlider(waterBar, WateredPercentage);
            timer = 0;
        }
        UpdateSlider(growBar, currentGrowTime/growthRate);
        UpdateSlider(sunBar, (-1.0f/3.0f*(float)(Mathf.Abs(GlobalWeatherInfo.Instance.sun - (int)SunlightNeed)) + 1.0f));
    }
    public float GetGrowthRate()
    { return growthRate; }

    public PlantBaseState GetCurrentState() { return currentState; }
    public void SetCurrentState(PlantBaseState _newState)
    {
        currentState = _newState;
    }
    public float GetCurrerntGrowTime() { return currentGrowTime; }
    public void SetCurrentGrowTime(float growtime)
    {
        currentGrowTime = growtime;
    }
    public string GetName() { return PlantName; }
    public PlantSeedState GetCurrentSeedState() { return seedState; }

    public PlantGrowingState GetGrowingState() { return growingState; }

    public PlantHarvestState GetHarvestState() { return plantHarvestState; }
    public PlantDeadState GetDeadState() { return deadState; }
    public DataPerenualResponse GetPlantData() { return plantData;  }
    public void PlantSeed() { planted = true; }
    public float GetWateredPercentage() { return WateredPercentage; }
    public float GetSunlightNeed() { return (int)SunlightNeed; }

    public void ParseParenialResponse(DataPerenualResponse data)
    {
        plantData = data;
        PlantName = data.common_name;
        WaterNeed = (WaterNeed)Enum.Parse(typeof(WaterNeed), data.watering, ignoreCase: true);
        cycle = (GrowthRate)Enum.Parse(typeof(GrowthRate), String.Join("_", data.cycle.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries)), ignoreCase: true);
        if ((int)cycle%2==0 || (int)cycle % 3 == 0)
        {
            growthRate = 2000;
        }
        else
        {
            growthRate = 1000;
        }
        
        
        SunlightNeed = (SunlightNeed)Enum.Parse(typeof(SunlightNeed), String.Join("_", data.sunlight[0].Split(default(string[]), StringSplitOptions.RemoveEmptyEntries)), ignoreCase: true);
    }
    private void UpdateSlider(Slider slider, float value)
    {
        slider.value = value;
    }

    public void OnPointerClick(PointerEventData eventData)
    {

        if (plantMenu.activeSelf)
        {
            plantMenu.SetActive(false);
        }
        else
        {
            plantMenu.SetActive(true);
        }
    }
}

public enum WaterNeed
{
    NONE,
    MIN,
    AVERAGE,
    FREQUENT
}

public enum SunlightNeed
{
    FULL_SHADE,
    PART_SHADE,
    PART_SUN,
    FULL_SUN
}
public enum GrowthRate
{
    perennial, 
    annual, 
    biennial, 
    biannual,
    herbaceous_Perennial,
}