using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fuel : MonoBehaviour
{

    [SerializeField] int fuelUsage = 1;
    [SerializeField] int maxFuel = 1000;
    [SerializeField] public int currentFuel = 100;
    [SerializeField] int addFuel = 100;
    [SerializeField] float fuellWaitTime = 300f;

    [SerializeField] Slider fuelSlider;
    Collision crashSequence;

    private void Start()
    {
        currentFuel = maxFuel;
        crashSequence = GetComponent<Collision>();

    }

    private void Update()
    {
        StartCoroutine("LosingFuel");
        if (currentFuel == 0)
        {

            crashSequence.StartCrashSequence();
        }
        HandleSlider();
    }


    public IEnumerator LosingFuel()
    {
        while (Input.anyKey)
        {
            if (Input.GetKey(KeyCode.Mouse0) || Input.GetKey(KeyCode.Mouse1)) { yield return null; }
            else
            {
                currentFuel -= fuelUsage;
                yield return new WaitForSeconds(fuellWaitTime);
            }
        }
    }

    public void AddFuel()
    {
        currentFuel += addFuel;

    }

    void HandleSlider()
    {
        fuelSlider.value = currentFuel;

    }


}
