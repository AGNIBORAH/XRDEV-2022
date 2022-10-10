using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorLerp : MonoBehaviour
{
    [SerializeField] private float interpolationAmount = 0; //value that goes between 0 and 1
    [SerializeField] private float speed;

    [SerializeField] private Color startColor;
    [SerializeField] private Color endColor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (interpolationAmount > 1)
        {
            interpolationAmount = 0;
        }
        interpolationAmount += speed;

        Color newColor = Color.Lerp(startColor, endColor, interpolationAmount);


        GetComponent<MeshRenderer>().material.color = newColor;
    }
}
