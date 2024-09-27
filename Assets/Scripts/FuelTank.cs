using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelTank : MonoBehaviour
{
    public float value = 10;
    private RandomSpawner spawner;

    private void Start()
    {
        spawner = FindAnyObjectByType<RandomSpawner>();
    }

    private void OnTriggerEnter(Collider other)
    {


        if (other.CompareTag("Player"))
        {
            FuelManager.instance.AddFuel(value);
            spawner.activeFuelTanks--;
            gameObject.SetActive(false);
            gameObject.transform.position = RandomSpawner.instance.GetRandomPosition();
            gameObject.SetActive(true);
            spawner.activeFuelTanks++;
        }
    }
}
