using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    [Header("Camera Settings")]
    public Vector3 offset;
    public float followSpeed = 10f;
    public float rotationSpeed = 5f;


    private float timer = 0f;
    private bool actionDone = false;

    private void Start()
    {
        Invoke("AfterStart", 0.2f);
    }
    public void AfterStart()
    {
        if (CarSelectionScript.instance.spawnedCar != null)
        {
            target = CarSelectionScript.instance.spawnedCar.transform;
        }
    }

    void Update()
    {

        if (!actionDone)
        {
            timer += Time.deltaTime;

            if (timer >= 0.5f)
            {
                Vector3 desiredPosition = target.position + offset;
                transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);

                //Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position);
                //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }
}
