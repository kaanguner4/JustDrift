using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class CarController : MonoBehaviour
{
    [Header("Car Settings")]
    [SerializeField] public float MoveSpeed = 40;
    [SerializeField] public float MaxSpeed = 15;
    [SerializeField] public float Drag = 0.98f;
    [SerializeField] public float SteerAngle = 140;
    [SerializeField] public float Traction = 1;
    [SerializeField] public float FixedYPosition = -0.2025898f;

    [Header("Fuel Settings")]
    [SerializeField] public float Fuel = 100;
    [SerializeField] public float FuelConsumption = 1;

    [Header("Joystick")]
    [SerializeField] private Rigidbody rb;
    [SerializeField] private FloatingJoystick _joystick;
    private Vector3 startPosition;
    private Quaternion startRotation;
    private bool isMovingBackward = false;


    private void Start()
    {

        rb = GetComponent<Rigidbody>();
        rb.drag = Drag;

        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

        rb.constraints |= RigidbodyConstraints.FreezePositionY;

        startPosition = transform.position;
        startRotation = transform.rotation;
    }
    /*private void FixedUpdate()
    {
        if (Input.touchCount == 3)
        {
            ResetCarPosition();
        };
        if (_joystick.Vertical < -0.65f)
        {
            isMovingBackward = true;
            MoveCar(isMovingBackward);
        }
        else if(Input.touchCount>0)
        {
            isMovingBackward=false;
            Vector3 forwardForce = transform.forward * MoveSpeed * Time.deltaTime;
            rb.AddForce(forwardForce, ForceMode.Acceleration);
            MoveCar(isMovingBackward);
        }
    }*/

    private void FixedUpdate()
    {
        
        if (rb.velocity.magnitude > 0.1f)
        {
            FuelManager.instance.RemoveFuel();
        }


        Vector3 forwardForce = new Vector3(_joystick.Horizontal * MoveSpeed, rb.velocity.y, _joystick.Vertical * MoveSpeed);

        // Kuvveti ekliyoruz, ama z ekseninde ileri hareketi sağlıyoruz (hareket eksenine dikkat etmelisin)
        rb.AddForce(forwardForce, ForceMode.Acceleration);

        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            Quaternion targetRotation = Quaternion.LookRotation(new Vector3(_joystick.Horizontal * Time.deltaTime, 0, _joystick.Vertical * Time.deltaTime));
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, SteerAngle * Time.deltaTime));

        }

    }

    void MoveCar(bool isMoveingBackward)
    {
        if (isMovingBackward == true)
        {
            // go back also steer
            Vector3 backwardForce = transform.forward * _joystick.Vertical * MoveSpeed/1.5f * Time.deltaTime ;
            rb.AddForce(backwardForce, ForceMode.Acceleration);

            if (rb.velocity.magnitude > 0.1f)
            {
                Quaternion deltaRotation = Quaternion.Euler(Vector3.up * _joystick.Horizontal * SteerAngle * Time.deltaTime * -1 );
                rb.MoveRotation(rb.rotation * deltaRotation);
            }
        }
        else
        {
            //always go forward also steer
            

            if (rb.velocity.magnitude > 0.1f)
            {
                Quaternion deltaRotation = Quaternion.Euler(Vector3.up * _joystick.Horizontal * SteerAngle * Time.deltaTime);
                rb.MoveRotation(rb.rotation * deltaRotation);
            }
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