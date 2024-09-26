// kamera konumu ýþýnlanarak deðiþiyor bunu deðiþtirmeliyiz ki daha smoot bir geçiþ elde edelim veya böyle kalacak bilmiyorum 
using UnityEngine;

public class MenuCameraController : MonoBehaviour
{
    [SerializeField] private GameObject m_Camera;
    public float swipeSpeed;
    private Vector3 firstTouchPosition, lastTouchPosition;

    public float minX = 0f;  // Kameranýn gidebileceði minimum x pozisyonu
    public float maxX = 1000f;   // Kameranýn gidebileceði maksimum x pozisyonu

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

