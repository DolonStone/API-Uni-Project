using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public GameObject rain;
    public GameObject snow;
    public GameObject clouds;
    private ParticleSystem rs;
    private ParticleSystem ss;
    private ParticleSystem cs;
    
    private void checkWeather()
    {
        ParticleSystem rs = rain.GetComponent<ParticleSystem>();
        ParticleSystem ss = snow.GetComponent<ParticleSystem>();
        ParticleSystem cs = clouds.GetComponent<ParticleSystem>();

        var weather = APIHelper.GetWeather(APIHelper.GetLocation());
        if (weather.days[0].preciptype != null)
        {
            if (weather.days[0].preciptype[0] == "rain")
            {
                Debug.Log("rain activated");
                if(rs != null)
                {
                    rs.Play(true);
                }
            }
            if (weather.days[0].preciptype[0] == "snow")
            {
                ss.Play(true);
            }
        }
        else if(weather.days[0].icon == "partly-cloudy-day" || weather.days[0].icon == "cloudy" || weather.days[0].icon == "partly-cloudy-night")
        {
            cs.Play(true);
        }   
    }

    void Start()
    {
        checkWeather();
    }

    void Update()
    {
        
    }
}