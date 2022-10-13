using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockingManager : MonoBehaviour
{
    public GameObject beePrefab;
    public int numBee;
    public GameObject[] allBee;
    public Vector3 zoomLimits = new Vector3(20, 20, 20);

    [Header("Bee Settings")]
    [Range(0.0f, 50.0f)]
    public float minSpeed;
    [Range(0.0f, 50.0f)]
    public float maxSpeed;

    [Range(1.0f, 50.0f)]
    public float neighbourDistance;
    [Range(0.0f, 50.0f)]
    public float rotationSpeed;


    void Start () {

        allBee = new GameObject[numBee];
       for (int i = 0; i < numBee; i++)
        {
            Vector3 pos = this.transform.position +
                new Vector3(Random.Range(-zoomLimits.x, zoomLimits.x),
                Random.Range(-zoomLimits.y, zoomLimits.y),
                Random.Range(-zoomLimits.z, zoomLimits.z));
            allBee[i] = (GameObject)Instantiate(beePrefab, pos, Quaternion.identity);
            allBee[i].GetComponent<Flock>().myManager = this;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}