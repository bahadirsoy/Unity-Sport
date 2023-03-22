using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringCan : MonoBehaviour
{
    [SerializeField] private ParticleSystem wateringParticleSystem;

    private void Start()
    {
        wateringParticleSystem.enableEmission = false;
    }

    public void EnableWatering()
    {
        wateringParticleSystem.enableEmission = true;
    }

    public void DisableWatering()
    {
        wateringParticleSystem.enableEmission = false;
    }
}
