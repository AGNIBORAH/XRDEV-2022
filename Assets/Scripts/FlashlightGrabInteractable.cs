using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FlashlightGrabInteractable : XRGrabInteractable
{
    [SerializeField] private GameObject spotlight;
    [SerializeField] private MeshRenderer flashLightGlass;

    [SerializeField] private Material glassMaterial, flashMaterial;

    private bool isOn = false; //by default the flashlight is turned off

    // to turn ON and OFF the flashlight
    protected override void OnActivated(ActivateEventArgs args)
    {
        base.OnActivated(args);

        if(isOn)
        {
            // we need to turn OFF
            flashLightGlass.material = glassMaterial;
            spotlight.SetActive(false); //activate the spotlight gameobject
            isOn = false;
        }
        else //if the flashlight is OFF, turn it ON
        {
            flashLightGlass.material = flashMaterial;
            spotlight.SetActive(true); //activate the spotlight gameobject
            isOn = true;
        }

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
