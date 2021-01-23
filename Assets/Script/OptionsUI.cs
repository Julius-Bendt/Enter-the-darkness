using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class OptionsUI : MonoBehaviour {

    public Dropdown res_d, quality_d;
    public Toggle windowed;



    private List<string> resolutions = new List<string>();// = { new Vector2(1280, 720), new Vector2(1360, 768), new Vector2(1366,768) };
    private List<string> quality = new List<string>();

    public void Start()
    {
        for (int i = 0; i < QualitySettings.names.Length; i++)
        {
            quality.Add(QualitySettings.names[i]);
        }

        foreach (var res in Screen.resolutions)
        {
            Vector2 r = new Vector2((int)res.width, (int)res.height);
            resolutions.Add(r.ToString());
        }

        windowed.isOn = Screen.fullScreen;

        quality_d.ClearOptions();
        quality_d.AddOptions(quality);

        res_d.ClearOptions();
        res_d.AddOptions(resolutions);
    }

}
