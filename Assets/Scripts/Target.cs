using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private BoxCollider spawnArea; //box collider.this is required for the target movement
    [SerializeField] private GameManager manager; //reference to game manager
    
    //for linear interpolation
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform endPoint;

    private float interpolationAmount = 0; //value that goes between 0 and 1
    [SerializeField] private float speed;


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("fooditem"))
        {
            // will destroy the food item with tag fooditem
            Destroy(collision.gameObject);

            //change the position
            MoveToRandomPosition(); // will execute the method below

            //add a point
            manager.AddPoint();
        }
    }

    private void MoveToRandomPosition()   //movement of target
    {
        // will generate minimum x,y and z value for the box collider of the target
        var x = Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x);
        var y = Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y);
        var z = Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z);

        transform.position = new Vector3(x, y, z); //set the position of the transform component to new x,y,z value
    }

    
    // Update is called once per frame
    void Update()
    {
        if(interpolationAmount > 1)
        {
            interpolationAmount = 0;
        }
        interpolationAmount += speed;

        transform.position = Vector3.Lerp(startPoint.position, endPoint.position, interpolationAmount);
    }


}
