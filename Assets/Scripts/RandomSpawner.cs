using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public GameObject fuelTankPrefab;

    public List<GameObject> coinPool;
    public List<GameObject> fuelTankPool;

    public int maxCoins; 
    public int activeCoins;
    public int maxFuelTanks;
    public int activeFuelTanks;

    //public GameObject spawnedCar;

    public static RandomSpawner instance;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        for (int i = 0; i < maxCoins; i++)
        {
            coinPool.Add(coinPrefab);
            Instantiate(coinPrefab, GetRandomPosition(), Quaternion.identity);
            activeCoins++;
        }

        for (int i = 0; i < maxFuelTanks; i++)
        {
            fuelTankPool.Add(fuelTankPrefab);
            Instantiate(fuelTankPrefab, GetRandomPosition(), Quaternion.identity);
            activeFuelTanks++;
        }
    }

    public Vector3 GetRandomPosition()
    {
        return new Vector3(Random.Range(-99, 99), 1, Random.Range(-99, 99)); //+ car.transform.position; //(creates a position depending on the car)
    }
}
