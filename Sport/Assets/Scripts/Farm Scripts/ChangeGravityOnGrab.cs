using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGravityOnGrab : MonoBehaviour
{
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void ChangeGravity()
    {
        rb.isKinematic = false;
        rb.useGravity = true;
    }
}
