using System;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    /// <summary>
    /// Sets the color of the specified transform.
    /// </summary>
    /// <param name="trans"></param>
    /// <param name="color"></param>
    private void SetColor(Transform trans, Color color)
    {
        trans.GetComponent<Renderer>().material.color = color;
    }

    /// <summary>
    /// Updates the color of GameObject with the names specified in the input values.
    /// </summary>
    /// <param name="values"></param>
    public void UpdateColor(string[] values)
    {
        var color = values[0];
        var shape = values[1];
        var function = values[2];

        Debug.Log("Color: " + color);
        Debug.Log("Shape: " + shape);
        Debug.Log("Function: " + values[2]);

    }
}