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

        if (Vector3.Distance(transform.position, target.transform.position) < 200f)
        {
            transform.position += transform.right * moveSpeed * Time.deltaTime;
        }


    }


}
