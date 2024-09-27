using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FuelManager : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI fuelText;
    public GameObject spawnedCar;
    public CarController carController;

    public static FuelManager instance;
    public GameManager gameManager;


    private float timer = 0f;
    private bool actionDone = false;


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Invoke("AfterStart", 0.2f);
    }

    public void AfterStart()
    {
        spawnedCar = CarSelectionScript.instance.spawnedCar;
        carController = spawnedCar.GetComponent<CarController>();

        fuelText.text = "FUEL:" + Mathf.FloorToInt(carController.Fuel).ToString();
    }
    private void Update()
    {
        if (!actionDone)
        {
            timer += Time.deltaTime;

            if (timer >= 0.5f)
            {
                if (carController.Fuel <= 0)
                {

                    gameManager.GameOver();
                    Debug.Log("Fuel finished");
                    actionDone = true;
                }
                fuelText.text = "FUEL:" + Mathf.FloorToInt(carController.Fuel).ToString();
                if (carController.rb.velocity.magnitude > 0.1f)
                {
                    FuelManager.instance.RemoveFuel();
                }
            }
        }
        
    }
    
    public void AddFuel(float value)
    {
        //if(carController.Fuel <= 100)
        carController.Fuel += value;
        //carController.Fuel = Mathf.Clamp(carController.Fuel, 0, 100);


    }
        
    public void RemoveFuel()
    {
        if(carController.Fuel>0)
        carController.Fuel -= carController.FuelConsumption * (carController.rb.velocity.magnitude / 10);
    }
}
