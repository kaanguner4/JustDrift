using UnityEngine;

public class Coin : MonoBehaviour
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
            ScoreManager.instance.AddScore(value); 
            spawner.activeCoins--; 
            gameObject.SetActive(false);
            gameObject.transform.position = RandomSpawner.instance.GetRandomPosition();
            gameObject.SetActive(true);
        }
    }
}
