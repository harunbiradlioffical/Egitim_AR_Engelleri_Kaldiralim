using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneStart : MonoBehaviour
{
    string lang;
    public GameObject mapTR;
    public GameObject mapEN;

    void Start()
    {
        lang = SettingsScript.lang;
        mapTR=GameObject.Find("Map-TR");
        mapEN=GameObject.Find("Map-EN");

        if(lang=="TR")
        {
            mapTR.gameObject.SetActive(true);
            mapEN.gameObject.SetActive(false);
        }

        else
        {
            mapTR.gameObject.SetActive(false);
            mapEN.gameObject.SetActive(true);
        }
    }
}
