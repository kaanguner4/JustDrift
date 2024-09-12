//coin almadan fuelTank  yeniden olluþturamýyorum





using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject car;
    public GameObject coinPrefab;
    public GameObject fuelTankPrefab;

    public int maxCoins = 5; 
    public int activeCoins;
    public int maxFuelTanks = 5;
    public int activeFuelTanks;


    private List<GameObject> coinPool = new List<GameObject>();
    private List<GameObject> fuelTankPool = new List<GameObject>();

    private void Start()
    {
        for (int i = 0; i < maxCoins; i++)
        {
            GameObject newCoin = Instantiate(coinPrefab, GetRandomPosition(), Quaternion.identity);
            newCoin.SetActive(false); 
            coinPool.Add(newCoin);
        }
        
        for (int i = 0; i < maxCoins; i++)
        {
            SpawnCollectiable();
        }
        
        for (int i = 0; i < maxFuelTanks; i++)
        {
            GameObject newFuelTank = Instantiate(fuelTankPrefab, GetRandomPosition(), Quaternion.identity);
            newFuelTank.SetActive(false);
            fuelTankPool.Add(newFuelTank);
        }

        for (int i = 0; i < maxFuelTanks; i++)
        {
            SpawnCollectiable();
        }
    }

    private void Update()
    {
        if (activeFuelTanks < maxFuelTanks)
        {
            SpawnCollectiable();
        }
        if (activeCoins < maxCoins)
        {
            SpawnCollectiable();
        }

    }
    

    private void SpawnCollectiable()
    {
        foreach (GameObject coin in coinPool)
        {
            if (!coin.activeInHierarchy) 
            {
                coin.transform.position = GetRandomPosition(); 
                coin.SetActive(true); 
                activeCoins++; 
                break;
            }
        }
        foreach (GameObject fuelTank in fuelTankPool)
        {
            if (!fuelTank.activeInHierarchy)
            {
                fuelTank.transform.position = GetRandomPosition();
                fuelTank.SetActive(true);
                activeFuelTanks++;
                break;
            }
        }
    }

    private Vector3 GetRandomPosition()
    {
        return new Vector3(Random.Range(-50, 51), 1, Random.Range(-50, 51)); 
    }
}
