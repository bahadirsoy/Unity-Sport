using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TennisBall : MonoBehaviour
{
    private Rigidbody rb;
    public float forceAmount;
    private Vector3 forceVector;

    private Vector3 lastPosition;
    private float lastPositionTime;
    private float lastPositionTimeCounter;

    [SerializeField] private GameObject tennisRacket;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        forceAmount = 40;

        lastPositionTime = 0.1f;
        lastPositionTimeCounter = lastPositionTime;
    }

    // Update is called once per frame
    void Update()
    {
        calculateLastPosition();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Tennis Racket"))
        {
            Debug.Log("hop");
            forceVector = (tennisRacket.gameObject.transform.position - lastPosition) * forceAmount;
            //forceVector.y *= 5;
            rb.AddForce(forceVector, ForceMode.Impulse);
        }
    }

    private void calculateLastPosition()
    {
        if (lastPositionTimeCounter >= lastPositionTime)
        {
            lastPosition = tennisRacket.gameObject.transform.position;
            lastPositionTimeCounter = 0;
        }

        lastPositionTimeCounter += Time.deltaTime;
    }
}
