using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGrow : MonoBehaviour
{
    [SerializeField] private GameObject growedPlant;

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
        if (transform.parent.gameObject.GetComponent<PlantArea>().plantState == "Irrigation" && waterParticleCount <= 150)
        {
            transform.localScale += new Vector3(0.001f, 0.01f, 0.001f);
            waterParticleCount++;
        }

        if(waterParticleCount >= 150)
        {
            Debug.Log("burdayiz");
            GameObject obj = Instantiate(growedPlant, transform.position, transform.rotation);
            obj.GetComponent<Recenter>().RecenterObject();

            Destroy(gameObject);

            transform.parent.gameObject.GetComponent<PlantArea>().plantState = "Growed";
        }
    }
}
