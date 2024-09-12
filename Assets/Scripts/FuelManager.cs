using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FuelManager : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI fuelText;
    [SerializeField] public GameObject Car;
 
    private CarController carController;

    public static FuelManager instance;
    


    private void OnEnable()
    {
         carController = FindObjectOfType<CarController>();

    }
    private void Awake()
    {

        instance = this;
    }

    void Start()
    {
        fuelText.text = "FUEL:" + Mathf.FloorToInt(carController.Fuel).ToString();
    }
    private void FixedUpdate()
    {
        if (carController.Fuel<0)
        {
            Destroy(Car);
        }
        fuelText.text = "FUEL:" + Mathf.FloorToInt(carController.Fuel).ToString();
    }

    public void AddFuel(float value)
    {
        carController.Fuel += value;
        
    }
        
    public void RemoveFuel()
    {
        carController.Fuel -= carController.FuelConsumption;
    }


}
