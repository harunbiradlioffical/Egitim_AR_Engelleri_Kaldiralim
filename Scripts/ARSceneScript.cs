using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class ARSceneScript : MonoBehaviour
{
    //ARScene GameObject declaration
    GameObject inventionPrefab;

    //ARScene Button declaration
    public Button exitButton;
    public Button backButton;
    public Button[] arSceneScholarButtons = new Button[5];
    public Button[] arSceneVideoButtons = new Button[6];

    public Button inventionAButton;
    public Button inventionBButton;

    //ARScene Sprite declaration
    public Sprite audioOnSprite;
    public Sprite audioOffSprite;

    //ARScene TextMeshProUIGUI declaration
    public TextMeshProUGUI lifeTMP;
    public TextMeshProUGUI worksTMP;
    public TextMeshProUGUI scientificTMP;
    public TextMeshProUGUI inventionsTMP;
    public TextMeshProUGUI referencesTMP;
    public TextMeshProUGUI inventionATMP;
    public TextMeshProUGUI inventionBTMP;

    //ARScene declaration for video player
    public RawImage videoRawImage;
    public VideoPlayer videoPlayer;

    string scholarName;

    string inventionName;

    string lang;

    bool controlScholarButtons;
    bool controlVideoButtons;

    MeshRenderer shcolarMeshRend;
    GameObject[] shcolarObjects;
    MeshRenderer[] scholarMeshs;

    MeshRenderer inventionMeshRend;

    Dictionary<string, string> inventionDict= new Dictionary<string, string>(){
        {"Variable Shape Fountain", "Değişken Şekilli Fıskiye"},
        {"Elephant Water Clock", "Filli Su Saati"},
        {"Scales of Wisdom", "Hikmet Terazisi"},
        {"Minute Scale", "Zaman Terazisi"},
        {"Light Reflection Observer", "Işık Yansımasını Gözlemleme Aleti"},
        {"Darkroom", "Karanlık Oda"},
        {"Blood Circulation", "Kan Dolaşımı"},
        {"Al Usal", "El Usal"},
        {"Retort", "İmbik"}
    };

    void Start()
    {

        Debug.Log("*********************ARScene Başladı************************\n\n\n"); //SİLİNECEK
        scholarName = MainSceneScript.scholarName;
        lang = SettingsScript.lang;
        controlScholarButtons = true;
        controlVideoButtons = false;

        shcolarMeshRend = GameObject.Find(scholarName + "Prefab").GetComponentInChildren<MeshRenderer>();
        shcolarObjects = GameObject.FindGameObjectsWithTag(scholarName);
        videoRawImage = videoRawImage.GetComponent<RawImage>();
        videoPlayer.GetComponent<VideoPlayer>();

        //Declaration of all buttons is SetActive(false)
        backButton.gameObject.SetActive(false);

        for (int i = 0; i < arSceneScholarButtons.Length; i++)
        {
            arSceneScholarButtons[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < arSceneVideoButtons.Length; i++)
        {
            arSceneVideoButtons[i].gameObject.SetActive(false);
        }

        inventionAButton.gameObject.SetActive(false);
        inventionBButton.gameObject.SetActive(false);

        videoRawImage.gameObject.SetActive(false);
        videoPlayer.gameObject.SetActive(false);
        //

        switch (lang)
        {
            case "TR":
                lifeTMP.text = "Hayatı";
                worksTMP.text = "Çalışmaları";
                scientificTMP.text = "Bilimsel Kişiliği";
                inventionsTMP.text = "Buluşları";
                referencesTMP.text = "Kaynakça";
                break;

            case "EN":
                lifeTMP.text = "Life";
                worksTMP.text = "Works";
                scientificTMP.text = "Scientific Personality";
                inventionsTMP.text = "Inventions";
                referencesTMP.text = "References";
                break;
        }

        // 
        switch (scholarName)
        {
            case "CezeriButton":
                switch (lang)
                {
                    case "TR":
                        inventionATMP.text = "Değişken Şekilli Fıskiye";
                        inventionBTMP.text = "Filli Su Saati";
                        break;

                    case "EN":
                        inventionATMP.text = "Variable Shape Fountain";
                        inventionBTMP.text = "Elephant Water Clock";
                        break;
                }
                break;

            case "HaziniButton":
                switch (lang)
                {
                    case "TR":
                        inventionATMP.text = "Hikmet Terazisi";
                        inventionBTMP.text = "Zaman Terazisi";
                        break;

                    case "EN":
                        inventionATMP.text = "Scales of Wisdom";
                        inventionBTMP.text = "Minute Scale";

                        break;
                }
                break;

            case "HeysemButton":
                switch (lang)
                {
                    case "TR":
                        inventionATMP.text = "Işık Yansımasını Gözlemleme Aleti";
                        inventionBTMP.text = "Karanlık Oda";
                        break;

                    case "EN":
                        inventionATMP.text = "Light Reflection Observer";
                        inventionBTMP.text = "Darkroom";
                        break;
                }
                break;

            case "NefisButton":
                switch (lang)
                {
                    case "TR":
                        inventionATMP.text = "Kan Dolaşımı";
                        break;

                    case "EN":
                        inventionATMP.text = "Blood Circulation";
                        break;
                }
                break;

            case "RaziButton":
                switch (lang)
                {
                    case "TR":
                        inventionATMP.text = "El Usal";
                        inventionBTMP.text = "İmbik";
                        break;

                    case "EN":
                        inventionATMP.text = "Al Usal";
                        inventionBTMP.text = "Retort";
                        break;
                }
                break;
        }
    }

    void Update()
    {
        if (controlScholarButtons == true && controlVideoButtons == false)
        {
            backButton.gameObject.SetActive(false);
            inventionAButton.gameObject.SetActive(false);
            inventionBButton.gameObject.SetActive(false);

            videoRawImage.gameObject.SetActive(false);
            videoPlayer.gameObject.SetActive(false);

            for (int i = 0; i < arSceneVideoButtons.Length; i++)
            {
                arSceneVideoButtons[i].gameObject.SetActive(false);
            }

            if (shcolarMeshRend.enabled == true)
            {
                for (int j = 0; j < shcolarObjects.Length; j++)
                {
                    shcolarObjects[j].GetComponent<MeshRenderer>().enabled = true;
                }

                for (int i = 0; i < arSceneScholarButtons.Length; i++)
                {
                    arSceneScholarButtons[i].gameObject.SetActive(true);
                }
            }

            else
            {
                for (int j = 0; j < shcolarObjects.Length; j++)
                {
                    shcolarObjects[j].GetComponent<MeshRenderer>().enabled = false;
                }
                
                for (int i = 0; i < arSceneScholarButtons.Length; i++)
                {
                    arSceneScholarButtons[i].gameObject.SetActive(false);
                }
            }
        }

        else if (controlScholarButtons == false && controlVideoButtons == true)
        {

            for (int i = 0; i < arSceneScholarButtons.Length; i++)
            {
                arSceneScholarButtons[i].gameObject.SetActive(false);
            }

            inventionAButton.gameObject.SetActive(false);
            inventionBButton.gameObject.SetActive(false);

            if (shcolarMeshRend.enabled == true)
            {
                backButton.gameObject.SetActive(true);

                videoRawImage.gameObject.SetActive(true);
                videoPlayer.gameObject.SetActive(true);

                for (int i = 0; i < arSceneVideoButtons.Length; i++)
                {
                    arSceneVideoButtons[i].gameObject.SetActive(true);
                }
            }

            else
            {
                backButton.gameObject.SetActive(false);

                for (int i = 0; i < arSceneVideoButtons.Length; i++)
                {
                    arSceneVideoButtons[i].gameObject.SetActive(false);
                }

                videoRawImage.gameObject.SetActive(false);
                videoPlayer.gameObject.SetActive(false);
            }
        }

        else if (controlScholarButtons == false && controlVideoButtons == false)
        {
            for (int i = 0; i < arSceneScholarButtons.Length; i++)
            {
                arSceneScholarButtons[i].gameObject.SetActive(false);
            }

            for (int i = 0; i < arSceneVideoButtons.Length; i++)
            {
                arSceneVideoButtons[i].gameObject.SetActive(false);
            }

            videoRawImage.gameObject.SetActive(false);
            videoPlayer.gameObject.SetActive(false);

            if (shcolarMeshRend.enabled == true)
            {
                backButton.gameObject.SetActive(true);
                inventionAButton.gameObject.SetActive(true);
                if (scholarName == "NefisButton")
                    inventionBButton.gameObject.SetActive(false);
                else
                    inventionBButton.gameObject.SetActive(true);
            }

            else
            {
                backButton.gameObject.SetActive(false);
                inventionAButton.gameObject.SetActive(false);
                inventionBButton.gameObject.SetActive(false);
            }
        }

        else
        {
            for (int i = 0; i < arSceneScholarButtons.Length; i++)
            {
                arSceneScholarButtons[i].gameObject.SetActive(false);
            }

            inventionAButton.gameObject.SetActive(false);
            inventionBButton.gameObject.SetActive(false);

            if (inventionMeshRend.enabled == true)
            {
                backButton.gameObject.SetActive(true);

                videoRawImage.gameObject.SetActive(true);
                videoPlayer.gameObject.SetActive(true);

                for (int i = 0; i < arSceneVideoButtons.Length; i++)
                {
                    arSceneVideoButtons[i].gameObject.SetActive(true);
                }
            }

            else
            {
                backButton.gameObject.SetActive(false);

                for (int i = 0; i < arSceneVideoButtons.Length; i++)
                {
                    arSceneVideoButtons[i].gameObject.SetActive(false);
                }

                videoRawImage.gameObject.SetActive(false);
                videoPlayer.gameObject.SetActive(false);
            }
        }
    }

    public void clickExitButton()
    {
        SceneManager.LoadScene("2-MainScene");
    }

    public void clickBackButton()
    {
        SceneManager.LoadScene("3-ARScene");
    }

    public void clickLifeButton()
    {
        controlScholarButtons = false;
        controlVideoButtons = true;

        videoRawImage.texture = (RenderTexture)Resources.Load(scholarName + "/" + scholarName + "Texture");
        videoPlayer.clip = (VideoClip)Resources.Load(scholarName + "/" + lang + "/" + scholarName + "LifeVideo" + lang);
        videoPlayer.targetTexture = (RenderTexture)Resources.Load(scholarName + "/" + scholarName + "Texture");
    }

    public void clickWorksButton()
    {
        controlScholarButtons = false;
        controlVideoButtons = true;

        videoRawImage.texture = (RenderTexture)Resources.Load(scholarName + "/" + scholarName + "Texture");
        videoPlayer.clip = (VideoClip)Resources.Load(scholarName + "/" + lang + "/" + scholarName + "WorksVideo" + lang);
        videoPlayer.targetTexture = (RenderTexture)Resources.Load(scholarName + "/" + scholarName + "Texture");
    }

    public void clickScientificButton()
    {
        controlScholarButtons = false;
        controlVideoButtons = true;

        videoRawImage.texture = (RenderTexture)Resources.Load(scholarName + "/" + scholarName + "Texture");
        videoPlayer.clip = (VideoClip)Resources.Load(scholarName + "/" + lang + "/" + scholarName + "ScientificVideo" + lang);
        videoPlayer.targetTexture = (RenderTexture)Resources.Load(scholarName + "/" + scholarName + "Texture");
    }

    public void clickInventionsButton()
    {
        controlScholarButtons = false;
        controlVideoButtons = false;
    }

    public void clickReferencesButton()
    {
        controlScholarButtons = false;
        controlVideoButtons = true;

        videoRawImage.texture = (RenderTexture)Resources.Load(scholarName + "/" + scholarName + "Texture");
        videoPlayer.clip = (VideoClip)Resources.Load(scholarName + "/" + lang + "/" + scholarName + "ReferencesVideo" + lang);
        videoPlayer.targetTexture = (RenderTexture)Resources.Load(scholarName + "/" + scholarName + "Texture");
    }

    public void clickInventionAButton()
    {
        controlScholarButtons = true;
        controlVideoButtons = true;

        if (lang == "TR")
        {
            inventionName = inventionATMP.text;
        }

        else
        {
            inventionName = inventionDict[inventionATMP.text];
        }

        inventionMeshRend = GameObject.Find(inventionName).GetComponentInChildren<MeshRenderer>();

        videoRawImage.texture = (RenderTexture)Resources.Load(scholarName + "/" + scholarName + "Texture");
        videoPlayer.clip = (VideoClip)Resources.Load(scholarName + "/" + lang + "/" + scholarName + inventionName + "Video" + lang);
        videoPlayer.targetTexture = (RenderTexture)Resources.Load(scholarName + "/" + scholarName + "Texture");
    }

    public void clickInventionBButton()
    {
        controlScholarButtons = true;
        controlVideoButtons = true;

        if (lang == "TR")
        {
            inventionName = inventionBTMP.text;
        }

        else
        {
            inventionName = inventionDict[inventionBTMP.text];
        }

        inventionMeshRend = GameObject.Find(inventionName).GetComponentInChildren<MeshRenderer>();

        videoRawImage.texture = (RenderTexture)Resources.Load(scholarName + "/" + scholarName + "Texture");
        videoPlayer.clip = (VideoClip)Resources.Load(scholarName + "/" + lang + "/" + scholarName + inventionName + "Video" + lang);
        videoPlayer.targetTexture = (RenderTexture)Resources.Load(scholarName + "/" + scholarName + "Texture");
    }

    public void clickStepBackwardButton()
    {
        videoPlayer.frame = videoPlayer.frame - 25 * 10;
    }

    public void clickAudioButton()
    {
        if (arSceneVideoButtons[4].image.sprite.name == "audioOn")
        {
            arSceneVideoButtons[4].image.sprite = audioOffSprite;
            videoPlayer.GetComponent<VideoPlayer>().SetDirectAudioMute(0, true);
        }

        else
        {
            arSceneVideoButtons[4].image.sprite = audioOnSprite;
            videoPlayer.GetComponent<VideoPlayer>().SetDirectAudioMute(0, false);
        }
    }

    public void clickStepForwardButton()
    {
        videoPlayer.frame = videoPlayer.frame + 25 * 10;
    }
}