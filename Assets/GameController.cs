using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex >= 4)
        {
            PlayerPrefs.SetInt("Score_Stg", SceneManager.GetActiveScene().buildIndex);
            PlayerPrefs.Save();
        }
    }

    public void Clear()
    {
        GameObject.FindGameObjectWithTag("UIController").GetComponent<UIController>().Clear();
        foreach(GameObject number in GameObject.FindGameObjectsWithTag("Number"))
        {
            number.GetComponent<NumberController>().Clear();
        }
        GetComponent<AudioSource>().Play();
        PlayerPrefs.SetInt("Score_Stg", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.Save();
    }
}
