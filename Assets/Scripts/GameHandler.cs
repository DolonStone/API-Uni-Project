using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    List<GameObject> Plants;
    GameObject plant;
    int Plots;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && Plants.Count < Plots)
        {
            Plants.Add(Instantiate(plant));
        }
        else if (Input.GetKeyDown(KeyCode.P) && Plants.Count >= Plots)
        {
            Debug.Log("No room at the inn!");
        }
    }
}
