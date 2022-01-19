using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuel : MonoBehaviour
{

    [SerializeField] int fuelUsage = 1;
    [SerializeField] int maxFuel = 1000;
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
            currentFuel -= fuelUsage;
            yield return new WaitForSeconds(100f);

        }



    }

}
