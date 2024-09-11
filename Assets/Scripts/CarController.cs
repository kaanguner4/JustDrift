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

    private Rigidbody rb;
    private Vector2 touchStartPos; // �lk dokunma pozisyonu
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

    void Update()
    {
        if (Input.touchCount == 3)
        {
            ResetCarPosition();
        };

        // Dokunmatik kontrolleri i�leme
        if (Input.touchCount > 0)
        {
            if (Input.touchCount == 2)
            {
                isMovingBackward = true;
                
                Vector3 backwardForce = -transform.forward * MoveSpeed / 2 * Time.deltaTime;
                rb.AddForce(backwardForce, ForceMode.Acceleration);
            }
            else
            {
                isMovingBackward = false;

                Touch touch = Input.GetTouch(0); // �lk dokunu�u al

                if (touch.phase == TouchPhase.Began)
                {
                    // Dokunma ba�lad���nda pozisyonu kaydet
                    touchStartPos = touch.position;
                }
                else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
                {
                    // Dokunma hareket ettik�e y�n� belirle
                    Vector2 touchDelta = touch.position - touchStartPos;

                    // Y�n hareketi (Horizontal de�erlerini belirle)
                    float horizontal = Mathf.Clamp(touchDelta.x / Screen.width, -1, 1); // Sa�/sol hareket


                    MoveCar(horizontal);
                }
            }

        }
    }

    void MoveCar(float horizontalInput)
    {

        
        // when there is a touch car goes forward
        Vector3 forwardForce = transform.forward * MoveSpeed * Time.deltaTime;
        rb.AddForce(forwardForce, ForceMode.Acceleration);
        

        if (rb.velocity.magnitude > 0.1f)
        {
            Quaternion deltaRotation = Quaternion.Euler(Vector3.up * horizontalInput * SteerAngle * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }
    }

    void ResetCarPosition()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        transform.position = startPosition;
        transform.rotation = startRotation;
    }
}
