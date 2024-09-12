using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelTank : MonoBehaviour
{
    public float value = 10;
    private RandomSpawner spawner;

    private void Start()
    {

        spawner = FindObjectOfType<RandomSpawner>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Car")
        {
            FuelManager.instance.AddFuel(value);
            //spawner.activeFuelTanks--;
            gameObject.SetActive(false);
        }
    }
}
