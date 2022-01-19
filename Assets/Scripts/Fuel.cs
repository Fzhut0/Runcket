using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuel : MonoBehaviour
{

    [SerializeField] float fuelUsage = 2f;
    [SerializeField] int maxFuel = 100;
    [SerializeField] int currentFuel = 100;

    private void Start()
    {
        currentFuel = maxFuel;

    }

    private void Update()
    {
        StartCoroutine("LosingFuel");
    }


    IEnumerator LosingFuel()
    {
        while (Input.anyKey)
        {
            currentFuel--;
            yield return new WaitForSeconds(fuelUsage);
        }



    }

}