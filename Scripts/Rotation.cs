using UnityEngine;

public class Rotation : MonoBehaviour
{

    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch screenTouch = Input.GetTouch(0);

            if (screenTouch.phase == TouchPhase.Moved)
            {
                transform.Rotate(-screenTouch.deltaPosition.y*0.25f, 0f, -screenTouch.deltaPosition.x*0.25f);
            }
        }
    }
}