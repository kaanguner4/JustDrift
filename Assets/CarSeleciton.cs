using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSeleciton : MonoBehaviour
{
    public GameObject[] vehiclePrefabs;
    private GameObject selectedVehicle;
    public GameObject mainCamera;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    public GameObject VehicleSelection()
    {
        int index=0;
        Vector2 menuCameraPosition = (mainCamera.transform.position);
        if (menuCameraPosition.x == 0)
        {
            index = 0;
        }else if (menuCameraPosition.x == 1000)
        {
            index = 1;
        }
        
        selectedVehicle = vehiclePrefabs[index];

        return selectedVehicle;
    }


    public void SpawnCar(GameObject car)
    {
        Vector3 carSpawnPosition = new Vector3(0, -0.2025898f, 0);
        Instantiate(car, carSpawnPosition,Quaternion.identity);
    }
}
