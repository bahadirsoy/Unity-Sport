using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateByVoice : MonoBehaviour
{
    //Objects to create
    [SerializeField] GameObject tomato;
    [SerializeField] GameObject eggplant;
    [SerializeField] GameObject corn;
    [SerializeField] GameObject chair;

    //Create location
    [SerializeField] Transform createPosition;

    public void CreateCommand(string[] values)
    {
        Debug.Log("Create Manager: " + "Object: " + values[0]);

        switch (values[0])
        {
            case "tomato":
                CreateObject(tomato);
                break;
            case "eggplant":
                CreateObject(eggplant);
                break;
            case "corn":
                CreateObject(corn);
                break;
            case "chair":
                CreateObject(chair);
                break;
        }
    }

    void CreateObject(GameObject objectToCreate)
    {
        GameObject obj = Instantiate(objectToCreate, createPosition.position, Quaternion.identity);
        Rigidbody rb = obj.GetComponent<Rigidbody>();

        rb.isKinematic = false;
        rb.useGravity = true;
    }
}
