using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantArea : MonoBehaviour
{
    [SerializeField] private GameObject shovel;
    [SerializeField] private GameObject dirtPile;
    private GameObject plant;

    [SerializeField] private AudioSource diggingSound;
    [SerializeField] private AudioSource plantCropSound;
    
    [SerializeField] private Image diggingImage;
    [SerializeField] private Image plantImage;
    [SerializeField] private Image irrigationImage;

    private float plantActionCooldown;
    private float plantActionCooldownCounter;
    public static string plantState;
    
    void Start()
    {
        plantActionCooldown = 2.5f;
        plantActionCooldownCounter = plantActionCooldown;

        plantState = "Dig";
    }

    void Update()
    {
        plantActionCooldownCounter += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(plantActionCooldownCounter >= plantActionCooldown)
        {
            if(plantState == "Dig" && other.gameObject.CompareTag("Shovel"))
            {
                StartCoroutine(ShovelDig());
                plantState = "Plant";
            } else if(plantState == "Plant" && other.gameObject.CompareTag("Plant"))
            {
                StartCoroutine(PlantCrop());

                plant = Instantiate(other.gameObject, dirtPile.transform.position, Quaternion.identity);
                plant.layer = LayerMask.NameToLayer("Default");

                plantState = "Irrigation";
            }

            plantActionCooldownCounter = 0f;
        }
    }

    IEnumerator PlantCrop()
    {
        PlantCropSound();

        yield return new WaitForSeconds(1f);

        plantImage.gameObject.SetActive(false);
        irrigationImage.gameObject.SetActive(true);
    }

    private void PlantCropSound()
    {
        plantCropSound.Play();
    }

    IEnumerator ShovelDig()
    {
        DigSound();

        yield return new WaitForSeconds(diggingSound.clip.length - 0.6f);

        dirtPile.gameObject.SetActive(true);
        diggingImage.gameObject.SetActive(false);
        plantImage.gameObject.SetActive(true);
    }

    private void DigSound()
    {
        diggingSound.Play();
    }
}
