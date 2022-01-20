using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelPick : MonoBehaviour
{



    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<Fuel>().AddFuel();
        Destroy(gameObject);
    }


}
