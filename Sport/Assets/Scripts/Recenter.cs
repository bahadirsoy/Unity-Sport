using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recenter : MonoBehaviour
{
    [SerializeField] private Transform center;

    public void RecenterObject()
    {
        transform.position = center.position;
    }
}
