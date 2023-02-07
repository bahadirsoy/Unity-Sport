using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGrow : MonoBehaviour
{
    [SerializeField] private GameObject growedCornPlant;

    private int waterParticleCount;

    // Start is called before the first frame update
    void Start()
    {
        waterParticleCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        if (GetComponent<PlantArea>().plantState == "Irrigation" && waterParticleCount <= 150)
        {
            transform.localScale += new Vector3(0.0001f, 0.001f, 0.0001f);
            waterParticleCount++;
        }

        if(waterParticleCount >= 150)
        {
            Instantiate(growedCornPlant, transform.position, transform.rotation);
            Destroy(gameObject);

            GetComponent<PlantArea>().plantState = "Growed";
        }
    }
}
