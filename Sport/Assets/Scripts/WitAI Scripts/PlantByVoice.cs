using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantByVoice : MonoBehaviour
{
    public void PlantCommand(string[] values)
    {
        Debug.Log("Intent: " + values[0]);
        Debug.Log("Place: " + values[1]);
    }
}
