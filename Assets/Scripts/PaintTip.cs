using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintTip : MonoBehaviour
{
    private MeshRenderer rend;

    public Material currentMaterial; // a new material method created with name currentmaterial

    private void Start()
    {
        //rend variable is going to be the Meshrenderer component that is attached to the paint tip
        rend = GetComponent<MeshRenderer>(); 
    }

    private void OnTriggerEnter(Collider other) // ON trigger will enable to dip the paint tip into the color,will also crate a new game object called other
    {
        if(other.CompareTag("Paintcolor"))
        {
            //when the tip is dipped into the color, the material of the other game object will be copied into the currentmaterial
            currentMaterial = other.GetComponent<Renderer>().material;

            rend.material = currentMaterial;

        }
    }



}
