using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceFloor : MonoBehaviour
{
    //Instantiate Dance Floor
    public GameObject dancefloorPrefab;

    public void CreateDanceFloor()
    {
        GameObject newFloor = Instantiate(dancefloorPrefab);
    }
} 