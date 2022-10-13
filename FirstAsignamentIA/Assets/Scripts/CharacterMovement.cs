using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CharacterMovement : MonoBehaviour
{
    public GameObject target;
    private int position;
    public int maxVelocity;
    private int maxRotation;
    public float turnSpeed; 
    public float stopDistance;
    public float movSpeed;
    public float acceleration;
    private float maxTurnSpeed;
    public float maxSpeed;
    private float turnAcceleration;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    float freq = 0f;
    void Update()
    {
        if (Vector3.Distance(target.transform.position, transform.position) <
         stopDistance) return;


        /*freq += Time.deltaTime;
        if (freq > 0.5)
        {
            freq -= 0.5f;
            Seek();
        }*/

        // Seek
        Vector3 direction = target.transform.position - transform.position;
        direction.y = 0f;    // (x, z): position in the floor

        // Flee
        Vector3 movement = direction.normalized * maxVelocity;

        //Rotation
        float angle = Mathf.Rad2Deg * Mathf.Atan2(movement.x, movement.z);
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.up);  // up = y

        Seek();   // calls to this function should be reduced
        turnSpeed += turnAcceleration * Time.deltaTime;
        turnSpeed = Mathf.Min(turnSpeed, maxTurnSpeed);
        movSpeed += acceleration * Time.deltaTime;
        movSpeed = Mathf.Min(movSpeed, maxSpeed);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation,
                                      Time.deltaTime * turnSpeed);
        transform.position += movement * Time.deltaTime;

        Vector3.Distance(target.transform.position, transform.position);

        



    }

    private void Seek()
    {  // Seek
        Vector3 direction = target.transform.position - transform.position;
        direction.y = 0f;    // (x, z): position in the floor

        // Flee
        Vector3 movement = direction.normalized * maxVelocity;

        //Rotation
        float angle = Mathf.Rad2Deg * Mathf.Atan2(movement.x, movement.z);
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.up);  // up = y

        //Angle
        Mathf.Abs(Vector3.Angle(transform.forward, movement));  // forward = z
    }
}
