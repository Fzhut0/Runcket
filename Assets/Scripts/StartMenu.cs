using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{

    public void StartGame()
    {
        GameObject.FindGameObjectWithTag("StartMenu").SetActive(false);
        Time.timeScale = 1f;
    }


}
