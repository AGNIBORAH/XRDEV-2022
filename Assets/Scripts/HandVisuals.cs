using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandVisuals : MonoBehaviour
{
    [SerializeField] private Animator handAnim; //hand animation controller
    [SerializeField] private string gripButton; //name of the button

      
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown(gripButton))
        {
            handAnim.SetBool("Gripped", true); 
        }
        if(Input.GetButtonUp(gripButton))
        {
            handAnim.SetBool("Gripped", false);
        }
    }

}
