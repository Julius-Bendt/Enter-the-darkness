using UnityEngine;
using System.Collections;
using System;

public class manager : MonoBehaviour {

    public GameObject menuContainer, objectivs;

    public AudioController ac;

    public static bool isPaused;

    void Start()
    {
        if(Application.loadedLevelName == "scene")
        {
            Time.timeScale = 1;
            menuContainer.SetActive(false);
            objectivs.SetActive(true);

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    bool obj = true;
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.F12))
            screenshot();
        if (Input.GetKeyDown(KeyCode.Escape))
            menu();
        if (Input.GetKeyDown(KeyCode.Q))
            setObj();

    }

    public void menu()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            menuContainer.SetActive(true);
            objectivs.SetActive(false);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            isPaused = true;
        }
        else
        {
            Time.timeScale = 1;
            menuContainer.SetActive(false);
            objectivs.SetActive(obj);

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            isPaused = false;
        }


        if(ac != null)
            ac.trigger(Time.timeScale);

    }

    public void setObj()
    {
        obj = !obj;

        objectivs.SetActive(obj);
    }

    public void screenshot()
    {
        string file = DateTime.Now.ToString("HH:mm:ss");
        file.Replace(" ", "_");
        file += ".png";

        Debug.Log(file);
        file = "high res.png";
        ScreenCapture.CaptureScreenshot(file);
        Debug.Log("name: " + file);
    }
}
