using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recenter : MonoBehaviour
{
    [SerializeField] private Transform center;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = center.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
