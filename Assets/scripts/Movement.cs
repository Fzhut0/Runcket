using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationThrust = 1f;
    [SerializeField] AudioClip mainEngine;

    [SerializeField] ParticleSystem mainBooster;
    [SerializeField] ParticleSystem leftBooster;
    [SerializeField] ParticleSystem rightBooster;

    Rigidbody rb;
    AudioSource audiosrc;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audiosrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }

    }
    private void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);

        if (!audiosrc.isPlaying)
        {
            audiosrc.PlayOneShot(mainEngine);
        }
        if (!mainBooster.isPlaying)
        {
            mainBooster.Play();
        }
    }
    private void StopThrusting()
    {
        mainBooster.Stop();
        audiosrc.Stop();
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationThrust);
            if (!leftBooster.isPlaying)
            {
                leftBooster.Play();
            }
            else
            {
                leftBooster.Stop();
            }
        }

        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationThrust);
            if (!rightBooster.isPlaying)
            {
                rightBooster.Play();
            }
            else
            {
                rightBooster.Stop();
            }
        }

        void ApplyRotation(float rotationThisFrame)
        {
            rb.freezeRotation = true; //freezing for manual rotation

            transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);

            rb.freezeRotation = false; //unfreezing after manual rotation
        }


    }

}

