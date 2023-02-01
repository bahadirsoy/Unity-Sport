using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfBall : MonoBehaviour
{
    private Rigidbody rb;
    public float forceAmount;
    private Vector3 forceVector;

    private Vector3 lastPosition;
    private float lastPositionTime;
    private float lastPositionTimeCounter;

    [SerializeField] private GameObject golfRacket;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        forceAmount = 30f;

        lastPositionTime = 0.1f;
        lastPositionTimeCounter = lastPositionTime;
    }

    private void Update()
    {
        calculateLastPosition();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Golf Racket"))
        {
            forceVector = (golfRacket.gameObject.transform.position - lastPosition) * forceAmount;
            rb.AddForce(forceVector, ForceMode.Impulse);
        }
    }

    private void calculateLastPosition()
    {
        if(lastPositionTimeCounter >= lastPositionTime)
        {
            lastPosition = golfRacket.gameObject.transform.position;
            lastPositionTimeCounter = 0;
        }

        lastPositionTimeCounter += Time.deltaTime;
    }
}
