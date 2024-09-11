using UnityEngine;

public class CarControl : MonoBehaviour
{
    [Header("Car Settings")]
    [SerializeField] public float MoveSpeed = 40;
    [SerializeField] public float MaxSpeed = 15;
    [SerializeField] public float Drag = 0.98f;
    [SerializeField] public float SteerAngle = 140;
    [SerializeField] public float Traction = 1;
    [SerializeField] public float FixedYPosition = -0.2025898f;
    [SerializeField] public FixedJoystick joystick;

    private Rigidbody rb;
    private Vector2 touchStartPos; // Ýlk dokunma pozisyonu
    private Vector3 startPosition;
    private Quaternion startRotation;
    private bool isMovingBackward = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.drag = Drag;

        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

        rb.constraints |= RigidbodyConstraints.FreezePositionY;

        startPosition = transform.position;
        startRotation = transform.rotation;

    }

    void FixedUpdate()
    {
        if (Input.touchCount == 3)
        {
            ResetCarPosition();
        };

        
           
        MoveCar();
                
            

        
    }

    void MoveCar()
    {

        Vector3 forwardForce = transform.forward * MoveSpeed * joystick.Vertical * Time.deltaTime;
        rb.AddForce(forwardForce, ForceMode.Acceleration);
        Quaternion deltaRotation = Quaternion.Euler(Vector3.up * joystick.Horizontal * SteerAngle * Time.deltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
        




        /*
        // when there is a touch car goes forward
        Vector3 forwardForce = transform.forward * MoveSpeed * Time.deltaTime;
        rb.AddForce(forwardForce, ForceMode.Acceleration);
        

        if (rb.velocity.magnitude > 0.1f)
        {
            Quaternion deltaRotation = Quaternion.Euler(Vector3.up * horizontalInput * SteerAngle * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }
        */
    }

    void ResetCarPosition()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        transform.position = startPosition;
        transform.rotation = startRotation;
    }
}
