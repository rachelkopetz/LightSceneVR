using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PourCoffee : MonoBehaviour
{


    public GameObject coffeeStream;
    public Transform coffeePot;
    public Transform coffeeLid;

    private bool isPouring = false;
    private bool pourCheck;
    public float potTopHeight;
    public float potMidHeight;

    // Update is called once per frame
    void Update()
    {
        potMidHeight = coffeePot.position.y;
        potTopHeight = coffeeLid.position.y;

        if ((potTopHeight - potMidHeight) > 0)
        {
            pourCheck = true;
        }
        else
        {
            pourCheck = false;
        }

        if (isPouring != pourCheck)
        {
            isPouring = pourCheck;

            if (isPouring)
            {
                StartPour();
            }
            else
            {
                EndPour();
            }
        }


    }
    private void StartPour()
    {
        coffeeStream.SetActive(true);
    }
    private void EndPour()
    {
        coffeeStream.SetActive(false);
    }
}



         