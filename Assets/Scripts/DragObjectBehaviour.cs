using UnityEngine;

public class DragObjectBehaviour : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoordinate;

    private void OnMouseDown()
    {
        // transform the game object position to screen space and store the distance to the camera
        mZCoordinate = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        // store the offset = game object screen space - mouse screen space
        mOffset = gameObject.transform.position - GetMouseWorldPosition();
    }

    // Update is called once per frame
    private void OnMouseDrag()
    {
        // move the game object as the mouse moves
        transform.position = GetMouseWorldPosition() + mOffset;
    }

    // get the mouse position in world coordinates
    private Vector3 GetMouseWorldPosition()
    {
        var mousePoint = Input.mousePosition;
        mousePoint.z = mZCoordinate;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}