using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class OurHand : MonoBehaviour
{
    //public values to set in Unity, private used only in script
    public GameObject ourHandPrefab;
    public InputDeviceCharacteristics ourControllerCharacterisitcs;

    private InputDevice ourDevice;
    private Animator ourHandAnimator;

    // Start is called before the first frame update
    void Start()
    {
        InitalizeOurHand();
    }

    void InitalizeOurHand()
    {
        // Check for our controllerscharacteristics
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(ourControllerCharacterisitcs, devices);

        // If device identitfed, Instantiant a Hand
        if (devices.Count > 0)
        {
            ourDevice = devices[0];

            GameObject newHand = Instantiate(ourHandPrefab, transform);
            ourHandAnimator = newHand.GetComponent<Animator>();
        }
    }
    // Update is called once per frame
    void Update()
    {
        // Change animate position or re-initialize
        if (ourDevice.isValid)
        {
            UpdateOurHand();
        }
        else
        {
            InitalizeOurHand();
        }
    }
    void UpdateOurHand()
    {
        if (ourDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            ourHandAnimator.SetFloat("Trigger", triggerValue);
        }
        else
        {
            ourHandAnimator.SetFloat("Trigger", 0);
        }
        if (ourDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            ourHandAnimator.SetFloat("Grip", gripValue);
        }
        else
        {
            ourHandAnimator.SetFloat("Grip", 0);
        }
    }
}


