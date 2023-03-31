using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateByVoice : MonoBehaviour
{
    [SerializeField] GameObject carrot;

    public void CreateCommand(string[] values)
    {
        Debug.Log("Create Manager: " + "Object: " + values[0]);
    }
}
