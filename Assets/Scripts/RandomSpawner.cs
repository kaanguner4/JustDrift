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

    public static RandomSpawner instance;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        for (int i = 0; i < maxCoins; i++)
        {
            Instantiate(coinPrefab, GetRandomPosition(), Quaternion.identity);
            SpawnCoin();
        }

        for (int i = 0; i < maxFuelTanks; i++)
        {
            Instantiate(fuelTankPrefab, GetRandomPosition(), Quaternion.identity);
            SpawnFuelTank();
        }
    }

    private void Update()
    {
        if (activeCoins < maxCoins)
        {
            SpawnCoin();
        }
        if (activeFuelTanks< maxFuelTanks)
        {
            SpawnFuelTank();
        }

    }
    

    private void SpawnCoin()
    {
        activeCoins++;
    }
    private void SpawnFuelTank()
    {
        activeFuelTanks++;
    }

    public Vector3 GetRandomPosition()
    {
        return new Vector3(Random.Range(-99, 99), 1, Random.Range(-99, 99)); //+ car.transform.position; //(creates a position depending on the car)
    }
}
