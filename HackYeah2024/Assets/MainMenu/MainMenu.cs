using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGmae() {
        if (!string.IsNullOrEmpty("SampleScene")) {
            SceneManager.LoadScene("SampleScene");
        }
        else {
            Debug.LogError("Scene name is null or empty!");
        }
    }
}
