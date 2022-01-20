using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlaying : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] objcts = GameObject.FindGameObjectsWithTag("Music");
        if (objcts.Length > 1)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);


    }
}
