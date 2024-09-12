using UnityEngine;

public class ToggleCanvas : MonoBehaviour
{
  
    public GameObject joystick;
    private Vector2 _startTouchPosition;

    void Update()
    { 
        if (Input.touchCount > 0) { 

            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                _startTouchPosition = touch.position;
            }

            Debug.Log("Basýldý");
           
            //joystick.transform.position = _startTouchPosition;
   
        }
        else
        {
            Debug.Log("Çekildi");
           
        }
        
    }
 
}
