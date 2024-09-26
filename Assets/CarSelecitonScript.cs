using UnityEngine;
using UnityEngine.SceneManagement;

public class CarSelectionScript : MonoBehaviour
{
    public GameObject[] vehiclePrefabs;
    public GameObject menuCamera;
    public Vector2 cameraPosition;
    public GameObject selectedCar;
    public GameObject spawnedCar;
    public static CarSelectionScript instance;

    public int spawnedCarNumber = 0;
    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
    }
    private void Update()
    {
        int index = PlayerPrefs.GetInt("VehicleIndex");
        Debug.Log("GetIndex");
        selectedCar = vehiclePrefabs[index];
        Debug.Log("selectedcar=vehicleprefabs[index]");
        if (SceneManager.GetActiveScene().name == "MainMenu") // Ana menü sahnesinin adýný buraya yaz
        {
            Invoke("MenuCameraControlAndSetInt",0.2f); // Eðer sahne "MainMenu" ise bu fonksiyonu çaðýr
        }
        if (SceneManager.GetActiveScene().name == "SampleScene" && spawnedCarNumber == 0 )
        {
            SpawnVehicle();
            spawnedCarNumber = 1;
        }
    }

    public void MenuCameraControlAndSetInt()
    {
        menuCamera = GameObject.Find("Main Camera");
        cameraPosition = menuCamera.transform.position;

        if (cameraPosition.x == 0)
        {
            PlayerPrefs.SetInt("VehicleIndex", 0);
        }
        else if (cameraPosition.x == 1000)
        {
            PlayerPrefs.SetInt("VehicleIndex", 1);
        }
        else PlayerPrefs.SetInt("VheicleIndex", 0);


    }

    public void SpawnVehicle()
    {
        Vector3 carSpawnPosition = new Vector3(0, 0, 0);
        spawnedCar = Instantiate(selectedCar, carSpawnPosition, Quaternion.identity);
        Debug.Log("spawned");
    }
}
