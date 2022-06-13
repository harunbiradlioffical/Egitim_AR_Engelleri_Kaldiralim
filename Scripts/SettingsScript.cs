using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class SettingsScript : MonoBehaviour
{
    static bool langTR=true;
    public static string lang="TR";
    public TextMeshProUGUI guideTMP;
    public TextMeshProUGUI aboutTMP;
    public TextMeshProUGUI libraryTMP;

    void Start()
    {
        if(langTR==true)
        {
            guideTMP.text="Kullanım Kılavuzu";
            aboutTMP.text="Hakkında";
            libraryTMP.text="Kütüphane";
        }

        else
        {
            guideTMP.text="Guide";
            aboutTMP.text="About";
            libraryTMP.text="Library";
        }
    }

    public void clickBackButton()
    {
        SceneManager.LoadScene("2-MainScene");
    }

    public void clickTrLangButton()
    {
        if(langTR==false)
        {
            langTR=true;
            lang="TR";
            guideTMP.text="Kullanım Kılavuzu";
            aboutTMP.text="Hakkında";
            libraryTMP.text="Kütüphane";
        }
    }

    public void clickEnLangButton()
    {
        if(langTR==true)
        {
            langTR=false;
            lang="EN";
            guideTMP.text="Guide";
            aboutTMP.text="About";
            libraryTMP.text="Library";
        }
    }

    public void clickGuideButton()
    {
        SceneManager.LoadScene("5-GuideScene");
    }

    public void clickLibButton()
    {
        SceneManager.LoadScene("6-TargetLibScene");
    }

    public void clickAboutButton()
    {
        SceneManager.LoadScene("7-AboutScene");
    }
}
