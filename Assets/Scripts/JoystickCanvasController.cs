using UnityEngine;

public class JoystickCanvasController : MonoBehaviour
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

            Debug.Log("Bas�ld�");
           
            joystick.transform.position = _startTouchPosition;
            joystick.SetActive(true);
   
        }
        else
        {
            Debug.Log("�ekildi");
            joystick.SetActive(false);
        }
        
    }
 
}
