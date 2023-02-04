using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dig : MonoBehaviour
{
    [SerializeField] private GameObject shovel;
    [SerializeField] private Image dirtImage;
    [SerializeField] private AudioSource diggingSound;

    private float digCooldown;
    private float digCooldownCounter;
    
    void Start()
    {
        digCooldown = diggingSound.clip.length + 1f;
        digCooldownCounter = digCooldown;
    }
    
    void Update()
    {
        digCooldownCounter += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(digCooldownCounter >= digCooldown)
        {
            StartCoroutine(ShovelDig());

            digCooldownCounter = 0f;
        }
    }

    IEnumerator ShovelDig()
    {
        DigSound();

        yield return new WaitForSeconds(diggingSound.clip.length - 0.6f);

        dirtImage.gameObject.SetActive(false);
    }

    private void DigSound()
    {
        diggingSound.Play();
    }
}
