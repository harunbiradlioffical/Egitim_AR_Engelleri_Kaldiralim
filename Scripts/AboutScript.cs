using UnityEngine;
using UnityEngine.SceneManagement;

public class AboutScript : MonoBehaviour
{
    public void clickExitButton()
    {
        SceneManager.LoadScene("2-MainScene");
    }

    public void clickBackButton()
    {
        SceneManager.LoadScene("4-SettingsScene");
    }
}
