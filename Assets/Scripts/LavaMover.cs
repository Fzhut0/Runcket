using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaMover : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    GameObject target;



    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Friendly");
    }

    void Update()
    {

        if (target.activeSelf)
        {
            transform.position += transform.right * moveSpeed * Time.deltaTime;
        }


    }


}
