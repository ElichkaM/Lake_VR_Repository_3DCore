using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SplashScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadMainGame", 6f);
    }


    void LoadMainGame()
    {
        SceneManager.LoadScene(1);
    }
}
