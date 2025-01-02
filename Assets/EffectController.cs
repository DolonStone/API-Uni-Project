using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour
{
    [SerializeField] private GameObject[] particles;
    // Start is called before the first frame update
    private void Start()
    {
        DisableAllParticles();
    }
    void Update()
    {
        if (GlobalWeatherInfo.Instance.isRaining)
        {
            DisableAllParticles();
            particles[0].SetActive(true);
        }
        if (GlobalWeatherInfo.Instance.isSnowing)
        {
            DisableAllParticles();
            particles[1].SetActive(true);
        }
        if (GlobalWeatherInfo.Instance.sun != 3)
        {
            particles[2].SetActive(true);
        }
    }
    private void DisableAllParticles()
    {
        for (int i = 0; i < particles.Length; i++)
        {
            particles[i].SetActive(false);
        }
    }
}
