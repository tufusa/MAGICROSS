using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void GoToStart()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("Score_Stg", 4));
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Load(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void Reset()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("Score_Res", 0);
        PlayerPrefs.SetFloat("Score_Vol", 1);
        PlayerPrefs.SetInt("Score_Stg", 4);
        PlayerPrefs.SetInt("Score_Scm", 0);
        PlayerPrefs.Save();
        Screen.SetResolution(960, 540, false, 60);
    }
}
