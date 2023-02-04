using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantArea : MonoBehaviour
{
    [SerializeField] private GameObject shovel;
    [SerializeField] private GameObject dirtPile;
    [SerializeField] private AudioSource diggingSound;
    
    [SerializeField] private Image diggingImage;
    [SerializeField] private Image plantImage;

    private float plantActionCooldown;
    private float plantActionCooldownCounter;
    private string plantState;
    
    void Start()
    {
        plantActionCooldown = 5f;
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
            Debug.Log(other.gameObject.tag);
            if(plantState == "Dig" && other.gameObject.CompareTag("Shovel"))
            {
                StartCoroutine(ShovelDig());
                plantState = "Plant";
            } else if(plantState == "Plant")
            {

            }

            plantActionCooldownCounter = 0f;
        }
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
