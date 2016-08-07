using UnityEngine;
using System.Collections;

public class PinchToZoom : MonoBehaviour {

    public float zoomSpeed = 0.5f;

    void Update() {
        if (Input.touchCount == 2) {
            Touch touchOne = Input.GetTouch(0);
            Touch touchTwo = Input.GetTouch(1);

            Vector2 touchOneLastPos = touchOne.position - touchOne.deltaPosition;
            Vector2 touchTwoLastPos = touchTwo.position - touchTwo.deltaPosition;

            float lastTouchDeltaMagnitude = (touchOneLastPos - touchTwoLastPos).magnitude;
            float touchDeltaMagnitude = (touchOne.position - touchTwo.position).magnitude;

            float deltaMagnitudeDiff = lastTouchDeltaMagnitude - touchDeltaMagnitude;

            Camera.main.orthographicSize += deltaMagnitudeDiff * zoomSpeed;
            Camera.main.orthographicSize = Mathf.Max(Camera.main.orthographicSize, 1f);
        }
    }
}
