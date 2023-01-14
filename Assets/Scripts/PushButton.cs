using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PushButton : MonoBehaviour
{

    [SerializeField] private Transform button;
    [SerializeField] private Transform upPosition, downPosition;

    [SerializeField] private float movementSpeed = 0.3f;

    // create two events 
    public UnityEvent OnHandIn;
    public UnityEvent OnHandOut;




    private Vector3 targetPosition;
    // Start is called before the first frame update
    
    private void Start()
    {
        button.position = upPosition.position; //button will be in up position at the start 
        targetPosition = upPosition.position;
    }
    //create two method(function) for hands up and hands down position

    public void HandIn()
    {
        targetPosition = downPosition.position;

        //invoke the OnHandIn event
        //? checks for error before executing
        OnHandIn?.Invoke();
    }

    public void HandOut()
    {
        targetPosition = upPosition.position;
        //invoke the OnHandOut event
        OnHandOut?.Invoke();
    }


    // Update is called once per frame
    void Update()
    {
       //switching between button position and target position using lerp
        button.position = Vector3.Lerp(button.position, targetPosition, movementSpeed);
    }
}
