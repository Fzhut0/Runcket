using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour
{

    [SerializeField] float loadtime = 2f;
    //todo find better audio
    [SerializeField] AudioClip crashSFX;
    [SerializeField] AudioClip finishSFX;

    AudioSource audiosrc;

    bool isTransitioning = false;

    private void Start()
    {
        audiosrc = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (isTransitioning) { return; }
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("this thing is friendly");
                break;
            case "Finish":
                Debug.Log("Brawo");
                FinishSequence();
                break;
            default:
                StartCrashSequence();
                break;
        }
    }

    void StartCrashSequence()
    {
        isTransitioning = true;
        audiosrc.Stop();
        audiosrc.PlayOneShot(crashSFX);
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", loadtime);
    }

    void FinishSequence()
    {
        isTransitioning = true;
        audiosrc.Stop();
        audiosrc.PlayOneShot(finishSFX);
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", loadtime);
    }
    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
}
