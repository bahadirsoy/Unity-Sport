using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SportButton : MonoBehaviour
{
    public void LoadSportScene()
    {
        SceneManager.LoadScene("SportScene");
    }
}
