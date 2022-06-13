using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using UnityEngine.Android;


public class TargetLibScripts : MonoBehaviour
{
    string[] pathList = new string[15];
    string path = "Map/Images/Map-TR,CezeriButton/Images/Cezeri,CezeriButton/Images/Fiskiye,CezeriButton/Images/FilliSuSaati,HaziniButton/Images/Hazini,HaziniButton/Images/HikmetTerazisi,HaziniButton/Images/ZamanTerazisi,HeysemButton/Images/Heysem,HeysemButton/Images/IsikYansimasi,HeysemButton/Images/KaranlikOda,NefisButton/Images/Nefis,NefisButton/Images/AkcigerDolasimi,RaziButton/Images/Razi,RaziButton/Images/ElUsal,RaziButton/Images/Imbik";
    [SerializeField] Image targetImage;
    [SerializeField] string fileName;

    public TextMeshProUGUI tmp;
    public TextMeshProUGUI infoDownload;
    public TextMeshProUGUI prev;
    public TextMeshProUGUI share;
    public TextMeshProUGUI download;
    public TextMeshProUGUI next;
    int current = 0;


    void Start()
    {
        if(SettingsScript.lang=="EN")
        {
            infoDownload.text="The picture has been saved to the gallery.";
            prev.text="Prev";
            share.text="Share";
            download.text="Download";
            next.text="Next";
        }

        infoDownload.gameObject.SetActive(false);
        if (!Permission.HasUserAuthorizedPermission(Permission.ExternalStorageWrite))
        {
            Permission.RequestUserPermission(Permission.ExternalStorageWrite);
        }

        pathList = path.Split(',');
        targetImage.GetComponent<Image>().sprite = Resources.Load<Sprite>(pathList[0]);
        targetImage.GetComponent<Image>().SetNativeSize();
    }


    public void clickExitButton()
    {
        SceneManager.LoadScene("2-MainScene");
    }

    public void clickBackButton()
    {
        SceneManager.LoadScene("4-SettingsScene");
    }

    public void clickPrevButton()
    {
        infoDownload.gameObject.SetActive(false);
        if (current == 0)
        {
            current = 14;
        }

        else
        {
            current -= 1;
        }

        targetImage.GetComponent<Image>().sprite = Resources.Load<Sprite>(pathList[current]);
        targetImage.GetComponent<Image>().SetNativeSize();
    }

    public void clickNextButton()
    {
        infoDownload.gameObject.SetActive(false);

        if (current == 14)
        {
            current = 0;
        }

        else
        {
            current += 1;
        }

        targetImage.GetComponent<Image>().sprite = Resources.Load<Sprite>(pathList[current]);
        targetImage.GetComponent<Image>().SetNativeSize();
    }

    public void clickShareButton()
    {
        shareImage();
    }

    public void clikcDownloadButton()
    {
        writeImageOnDisk(); ;
    }

    void writeImageOnDisk()
    {
        infoDownload.gameObject.SetActive(true);
        fileName = pathList[current].Split('/')[2];
        byte[] textureBytes = Resources.Load<Sprite>(pathList[current]).texture.EncodeToJPG();

        string name = string.Format(fileName + ".jpg");
        Debug.Log("Permission result: " + NativeGallery.SaveImageToGallery(textureBytes, Application.productName + " Captures", name));
    }

    void shareImage()
    {
        fileName = pathList[current].Split('/')[2];
        byte[] textureBytes = Resources.Load<Sprite>(pathList[current]).texture.EncodeToJPG();

        string path = Path.Combine(Application.temporaryCachePath, fileName + ".jpg");
        File.WriteAllBytes(path, textureBytes);

        new NativeShare().AddFile(path).SetSubject(fileName).SetText("").Share();
    }
}
