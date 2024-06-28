using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject TextObject;
    [SerializeField] string TextString;
    [SerializeField] Dropdown Resolution;
    [SerializeField] Dropdown ScreenMode;
    [SerializeField] Slider Volume;
    [SerializeField] GameObject VolumeIcon;
    [SerializeField] Sprite[] VolumeIcons;
    float alpha = 0;

    private void Start()
    {
        TextObject.GetComponent<Text>().text = null;
        Resolution.value = PlayerPrefs.GetInt("Score_Res", 0);
        ScreenMode.value = PlayerPrefs.GetInt("Score_Scm", 0);
        Volume.value = PlayerPrefs.GetFloat("Score_Vol", 1);
        VolumeUpdate();
    }

    public void Clear()
    {
        TextObject.GetComponent<Text>().text = TextString;
        InvokeRepeating("FadeIn",0,0.05f);
    }

    public void FadeIn()
    {
        alpha += 0.01f;
        TextObject.GetComponent<Text>().color = new Color(1, 1, 1, alpha);
        if (alpha > 1) CancelInvoke("FadeIn");
    }

    public void ResolutionUpdate()
    {
        switch(Resolution.value)
        {
            case 1:
                Screen.SetResolution(640, 360, Screen.fullScreen, 60);
                break;
            case 2:
                Screen.SetResolution(960, 540, Screen.fullScreen, 60);
                break;
            case 3:
                Screen.SetResolution(1280, 720, Screen.fullScreen, 60);
                break;
            case 4:
                Screen.SetResolution(1440, 810, Screen.fullScreen, 60);
                break;
            case 5:
                Screen.SetResolution(1920, 1080, Screen.fullScreen, 60);
                break;
            case 6:
                Screen.SetResolution(2560, 1440, Screen.fullScreen, 60);
                break;
        }
        PlayerPrefs.SetInt("Score_Res", Resolution.value);
        PlayerPrefs.Save();
    }

    public void ScreenModeUpdate()
    {
        switch(ScreenMode.value)
        {
            case 0:
                Screen.fullScreen = false;
                break;
            case 1:
                Screen.fullScreen = true;
                break;
        }
        PlayerPrefs.SetInt("Score_Scm", ScreenMode.value);
        PlayerPrefs.Save();
    }

    public void VolumeUpdate()
    {
        float v = Volume.value;
        AudioListener.volume = v;
        if(v == 0)
        {
            VolumeIcon.GetComponent<SpriteRenderer>().sprite = VolumeIcons[0];
        }
        else if(v < 0.5)
        {
            VolumeIcon.GetComponent<SpriteRenderer>().sprite = VolumeIcons[1];
        }
        else if(v < 1)
        {
            VolumeIcon.GetComponent<SpriteRenderer>().sprite = VolumeIcons[2];
        }
        else if(v == 1)
        {
            VolumeIcon.GetComponent<SpriteRenderer>().sprite = VolumeIcons[3];
        }
        PlayerPrefs.SetFloat("Score_Vol", v);
        PlayerPrefs.Save();
    }
}