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

    [SerializeField] ParticleSystem crashParticle;
    [SerializeField] ParticleSystem finishParticle;

    AudioSource audiosrc;

    bool isTransitioning = false;
    bool collisionDisable = false;

    private void Start()
    {
        audiosrc = GetComponent<AudioSource>();
    }

    private void Update()
    {
        CheatLoad();
        CheatCollision();
    }
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (isTransitioning || collisionDisable) { return; }
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                break;
            case "Finish":
                FinishSequence();
                break;
            default:
                StartCrashSequence();
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == "Lava")
        {
            isTransitioning = true;
            audiosrc.Stop();
            audiosrc.PlayOneShot(crashSFX);
            crashParticle.Play();
            GetComponent<Movement>().enabled = false;
            Invoke("ReloadLevel", loadtime);
        }
    }

    void StartCrashSequence()
    {
        isTransitioning = true;
        audiosrc.Stop();
        audiosrc.PlayOneShot(crashSFX);
        crashParticle.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", loadtime);
    }

    void FinishSequence()
    {
        isTransitioning = true;
        audiosrc.Stop();
        audiosrc.PlayOneShot(finishSFX);
        finishParticle.Play();
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

    void CheatLoad()
    {
        if (Input.GetKey(KeyCode.L))
        {
            LoadNextLevel();
        }

    }

    void CheatCollision()
    {
        if (Input.GetKey(KeyCode.C))
        {
            Debug.Log("Collision deactivated");
            collisionDisable = !collisionDisable;
        }
    }

}