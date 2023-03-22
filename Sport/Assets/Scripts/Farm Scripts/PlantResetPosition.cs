using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantResetPosition : MonoBehaviour
{
    private Pose pose;

    private void Start()
    {
        pose.position = transform.position;
        pose.rotation = transform.rotation;
    }

    public void ResetPosition()
    {
        transform.position = pose.position;
        transform.rotation = pose.rotation;
    }
}
