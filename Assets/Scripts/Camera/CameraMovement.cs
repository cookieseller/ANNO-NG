using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    public float mapScrollSpeed = 2f;
    public float scrollZoomSpeed = 3f;
    Vector3 startPosition = Vector3.zero;

	// Update is called once per frame
	void Update () {

        handleMouseScroll();
        handleScrollZoom();
	}

    void handleMouseScroll() {
        if (Input.GetMouseButtonDown(1)) {
            startPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(1)) {
            Vector3 delta = startPosition - Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Camera.main.transform.position -= delta * mapScrollSpeed;
            startPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    void handleScrollZoom() {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0) {
            Camera.main.orthographicSize -= scroll * scrollZoomSpeed;
            Camera.main.orthographicSize = Mathf.Max(Camera.main.orthographicSize, 1f);
        }
    }
}
