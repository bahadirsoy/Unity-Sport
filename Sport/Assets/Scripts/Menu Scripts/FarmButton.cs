using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FarmButton : MonoBehaviour
{
    public void LoadFarmScene()
    {
        SceneManager.LoadScene("FarmScene");
    }
}
