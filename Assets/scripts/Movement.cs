using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationThrust = 1f;
    [SerializeField] AudioClip mainEngine;

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
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);

            if (!audiosrc.isPlaying)
            {
                audiosrc.PlayOneShot(mainEngine);
            }
        }
        else
        {
            audiosrc.Stop();
        }


    }
    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationThrust);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationThrust);

        }

        void ApplyRotation(float rotationThisFrame)
        {
            rb.freezeRotation = true; //freezing for manual rotation

            transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);

            rb.freezeRotation = false; //unfreezing after manual rotation
        }


    }

}
