using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dig : MonoBehaviour
{
    [SerializeField] private GameObject shovel;
    [SerializeField] private GameObject dirt;
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

        dirt.SetActive(true);
    }

    private void DigSound()
    {
        diggingSound.Play();
    }
}
