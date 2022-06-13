using UnityEngine;

public class ObjectScaleZoom : MonoBehaviour
{
    Vector3 touchStart;
    float scaleMin = 200;
    float scaleMax = 500;
    float zoomSpeed = 0.01f;
    

    void Update()
    {
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            zoom(difference * zoomSpeed);
        }
    }

    void zoom(float increment)
    {
        gameObject.transform.position = new Vector3(0, Mathf.Clamp(gameObject.transform.position.y - increment, scaleMin, scaleMax), 0);
    }
}