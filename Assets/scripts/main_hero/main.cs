using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour
{    
    public float rotationSpeed = 30f;
    public float deadZoneDegrees = 15f;
    public float speed = 10.0f;
 
    private Transform cameraT;
    private Vector3 cameraDirection;
    private Vector3 playerDirection;
    private Quaternion targetRotation;
 
    private void Awake()
    {
        cameraT = Camera.main.transform;
    }
 
    private void Update()
    {   
        float deltaZ = Input.GetAxis("Vertical") * speed;
        transform.Translate(0, 0, deltaZ * Time.deltaTime);

        float deltaX = Input.GetAxis("Horizontal");
        Vector3 rot_Vector;
        if(deltaX > 0) rot_Vector = new Vector3(90, 0, 0);
        else if(deltaX < 0) rot_Vector = new Vector3(-90, 0, 0);
        else rot_Vector = new Vector3(0, 0, 0);

        cameraDirection = new Vector3(cameraT.forward.x, 0f, cameraT.forward.z);
        playerDirection = new Vector3(transform.forward.x, 0f, transform.forward.z);

        if(Vector3.Angle(cameraDirection + arot_Vector, playerDirection) > deadZoneDegrees)
        {
            targetRotation = Quaternion.LookRotation(cameraDirection + rot_Vector, transform.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime * Mathf.Pow(1.1f, 
                                                                                                            (Vector3.Angle(cameraDirection, playerDirection) / 10)));
        }

    }
}




//     public float speedH = 2.0f;
//     public float speedV = 2.0f;
 
//     private float yaw = 0.0f;
//     private float pitch = 0.0f;
//     public float maxDegreesDelta = 15f;
 
 
//     private void Start()
//     {
       
 
//     }
 
//     void Update()
//     {
        
 
//     }
// }
// }