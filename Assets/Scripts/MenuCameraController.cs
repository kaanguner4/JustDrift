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
                // Kamerayý sola kaydýr (saða kaydýrma hareketine tepki olarak)
                newCameraPosition += new Vector3(-1000,0,0) * swipeSpeed;
            }
            else if (swipeDirection.x < 0)
            {
                // Kamerayý saða kaydýr (sola kaydýrma hareketine tepki olarak)
                newCameraPosition += new Vector3(1000,0,0) * swipeSpeed;
            }

            // Kameranýn pozisyonunu sýnýrla
            newCameraPosition.x = Mathf.Clamp(newCameraPosition.x, minX, maxX);

            // Kameranýn yeni pozisyonunu uygula
            m_Camera.transform.position = newCameraPosition;
        }
    }
}

