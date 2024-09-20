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
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            firstTouchPosition = Input.GetTouch(0).position;
            Debug.Log("First Touch Got");
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            lastTouchPosition = Input.GetTouch(0).position;
            Vector2 swipeDirection = lastTouchPosition - firstTouchPosition;
            Debug.Log("Last Touch Got & swipeDirection calculated");

            Vector3 newCameraPosition = m_Camera.transform.position;

            if (swipeDirection.x > 0)
            {
                // Kameray� sola kayd�r (sa�a kayd�rma hareketine tepki olarak)
                newCameraPosition += new Vector3(-1000,0,0) * swipeSpeed;
            }
            else if (swipeDirection.x < 0)
            {
                // Kameray� sa�a kayd�r (sola kayd�rma hareketine tepki olarak)
                newCameraPosition += new Vector3(1000,0,0) * swipeSpeed;
            }

            // Kameran�n pozisyonunu s�n�rla
            newCameraPosition.x = Mathf.Clamp(newCameraPosition.x, minX, maxX);

            // Kameran�n yeni pozisyonunu uygula
            m_Camera.transform.position = newCameraPosition;
        }
    }
}

