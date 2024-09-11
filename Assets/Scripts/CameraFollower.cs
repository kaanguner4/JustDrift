using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Target Settings")]
    public Transform target; 

    [Header("Camera Settings")]
    public Vector3 offset;
    public float followSpeed = 10f; 
    public float rotationSpeed = 5f; 

    void Update()
    {
        
        Vector3 desiredPosition = target.position + offset;
        transform.position = desiredPosition;

        
        Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}