using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public GameObject particles;
    ParticleSystem PARTS;

    void Start()
    {   
        PARTS = particles.GetComponent<ParticleSystem>();
    }
}
