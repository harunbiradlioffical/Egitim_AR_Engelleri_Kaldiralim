using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginScript : MonoBehaviour
{
    public GameObject map;
    
    void Update()
    {
        if(map.gameObject.GetComponent<MeshRenderer>().enabled==true)
        {
            SceneManager.LoadScene("2-MainScene");
        }
    }
}
