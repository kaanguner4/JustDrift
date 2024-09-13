using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FuelManager : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI fuelText;
    [SerializeField] public GameObject Car;

    private bool isFuelEmpty;

    private CarController carController;

    public static FuelManager instance;
    
    public GameManager gameManager;


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
        if (carController.Fuel <= 0)
        {
            isFuelEmpty = true;
            gameManager.GameOver();
            Debug.Log("Fuel finished");
        }
        fuelText.text = "FUEL:" + Mathf.FloorToInt(carController.Fuel).ToString();
    }

    public void AddFuel(float value)
    {
        if(carController.Fuel <= 90)
        carController.Fuel += value;
        
    }
        
    public void RemoveFuel()
    {
        if(carController.Fuel>0.01f)
        carController.Fuel -= carController.FuelConsumption;
    }


}
