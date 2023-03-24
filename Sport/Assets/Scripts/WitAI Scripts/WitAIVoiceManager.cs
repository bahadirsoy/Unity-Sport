using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Oculus.Voice;

public class WitAIVoiceManager : MonoBehaviour
{
    [SerializeField] InputActionReference voiceInput;
    [SerializeField] GameObject appVoice;

    private void Awake()
    {
        voiceInput.action.started += ActivateVoice;
    }

    void ActivateVoice(InputAction.CallbackContext context)
    {
        ActivateWit();
    }

    void ActivateWit()
    {
        appVoice.GetComponent<AppVoiceExperience>().Activate();
    }
}
