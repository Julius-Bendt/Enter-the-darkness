using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour {

    public OptionsUI oUI;


    public GameObject warningContainer;
    void Start()
    {
        if(Application.loadedLevelName == "menu" || Application.loadedLevelName == "dead")
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void OnStartGame()
    {
        SceneManager.LoadSceneAsync("scene");
    }

    public void ShowWarning()
    {
        warningContainer.SetActive(true);
    }




    public void OnOptions()
    {

    }

    public void OnOptionsSetWindowed()
    {
        bool windowed = false;
        Screen.SetResolution(Screen.width,Screen.height,windowed);
    }

    public void OnOptionsSetQuality()
    {
        bool windowed = false;
        Screen.SetResolution(Screen.width, Screen.height, windowed);
    }

    public void OnOptionsSetRes()
    {
        int x = 0, y = 0;


        Screen.SetResolution(x,y,Screen.fullScreen);
    }


    public void OnCredit()
    {

    }

    public void StartTheGame()
    {
        SceneManager.LoadSceneAsync("start");
    }

    public void OnMenu()
    {
        SceneManager.LoadSceneAsync("menu",LoadSceneMode.Single);
    }

    public void OnExit()
    {
        Application.Quit();
    }
}
