using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuel : MonoBehaviour
{

    [SerializeField] int fuelUsage = 1;
    [SerializeField] int maxFuel = 1000;
    [SerializeField] public int currentFuel = 100;
    [SerializeField] int addFuel = 100;


    Collision crashSequence;

    private void Start()
    {
        currentFuel = maxFuel;
        crashSequence = GetComponent<Collision>();

    }

    private void Update()
    {
        StartCoroutine("LosingFuel");
        if (currentFuel <= 0)
        {
            crashSequence.StartCrashSequence();
        }
    }


    IEnumerator LosingFuel()
    {
        while (Input.anyKey)
        {
            currentFuel -= fuelUsage;
            yield return new WaitForSeconds(100f);
        }
    }

    public void AddFuel()
    {
        currentFuel += addFuel;

    }

}
