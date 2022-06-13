using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneScript : MonoBehaviour
{
    public static string scholarName;

    string lang;

    public void clickScholarTouch()
    {
        scholarName = this.gameObject.name;
        SceneManager.LoadScene("3-ARScene");
    }

    public void clickSettingsButton()
    {
        SceneManager.LoadScene("4-SettingsScene");
    }

    public void clickExitButton()
    {
        Application.Quit();
    }
}
