// kamera konumu ���nlanarak de�i�iyor bunu de�i�tirmeliyiz ki daha smoot bir ge�i� elde edelim veya b�yle kalacak bilmiyorum 
using UnityEngine;

public class MenuCameraController : MonoBehaviour
{
    [SerializeField] private GameObject m_Camera;
    public float swipeSpeed;
    private Vector3 firstTouchPosition, lastTouchPosition;

    public float minX = 0f;  // Kameran�n gidebilece�i minimum x pozisyonu
    public float maxX = 1000f;   // Kameran�n gidebilece�i maksimum x pozisyonu

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Check if the touch is in the desired y-range
            if (touch.position.y > Screen.height * 0.35f)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    firstTouchPosition = touch.position;
                    Debug.Log("First Touch Got");
                }

                if (touch.phase == TouchPhase.Ended)
                {
                    lastTouchPosition = touch.position;
                    Vector2 swipeDirection = lastTouchPosition - firstTouchPosition;
                    Debug.Log("Last Touch Got & swipeDirection calculated");

                    Vector3 newCameraPosition = m_Camera.transform.position;

                    if (swipeDirection.x > 0)
                    {
                        // Move the camera left (reacting to a swipe right)
                        newCameraPosition += new Vector3(-1000, 0, 0) * swipeSpeed;
                    }
                    else if (swipeDirection.x < 0)
                    {
                        // Move the camera right (reacting to a swipe left)
                        newCameraPosition += new Vector3(1000, 0, 0) * swipeSpeed;
                    }

                    // Clamp the camera's position
                    newCameraPosition.x = Mathf.Clamp(newCameraPosition.x, minX, maxX);

                    // Apply the new camera position
                    m_Camera.transform.position = newCameraPosition;
                }
            }
        }
    }
}

