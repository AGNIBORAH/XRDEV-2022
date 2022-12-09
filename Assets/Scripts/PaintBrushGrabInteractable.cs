using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PaintBrushGrabInteractable : XRGrabInteractable
{
    [SerializeField] private GameObject paintPrefab; // We instantiate a paint prefab with trigger
    [SerializeField] private Transform paintTip;    // Reference to the paint tip for the paint prefab to follow
    [SerializeField] private PaintTip tip;        //using the paintbrushgrabinteractble script
   
    private GameObject tempPaint;//a gameobject which will render the paint

    protected override void OnActivated(ActivateEventArgs args)
    {
        
        base.OnActivated(args);

        // instantiate a paint prefab and follow the paintTip position and rotation
        tempPaint = Instantiate(paintPrefab, paintTip.position, paintTip.rotation);

        //put the tempPaint into the PaintTip
        tempPaint.transform.SetParent(paintTip);    

        if(tip.currentMaterial != null)
        {
            tempPaint.GetComponent<TrailRenderer>().material = tip.currentMaterial; //access to the trail renderer of the tempPaint game object

        }
    }

    protected override void OnDeactivated(DeactivateEventArgs args)
    {
        base.OnDeactivated(args);
        //check whether the tempPaint is available
        if(tempPaint != null)
        {
            //release the paint from the paint tip
            tempPaint.transform.SetParent(null);
            tempPaint = null;
        }
    }
}
