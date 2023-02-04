using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dig : MonoBehaviour
{
    [SerializeField] private GameObject shovel;
    [SerializeField] private Image dirtImage;
    [SerializeField] private AudioSource diggingSound;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(ShovelDig());
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
