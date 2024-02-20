using System;
using UnityEditor;
using UnityEngine;

public class DragObjectBehaviour : MonoBehaviour
{
    private Vector3 _mOffset;
    private float _mZCoordinate;
    
    public Transform mTransform;
    [SerializeField] private bool isDragging;

    private void Start()
    {
        if (mTransform == null)
            mTransform = transform;
    }

    private void OnMouseDown()
    {
        // transform the game object position to screen space and store the distance to the camera
        if (Camera.main != null) _mZCoordinate = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        // store the offset = game object screen space - mouse screen space
        _mOffset = mTransform.position - GetMouseWorldPosition();
        isDragging = true;
    }

    // Update is called once per frame
    private void OnMouseDrag()
    {
        if (isDragging == false)
            return;
        // move the game object as the mouse moves
        mTransform.position = GetMouseWorldPosition() + _mOffset;
    }

    // get the mouse position in world coordinates
    private Vector3 GetMouseWorldPosition()
    {
        var mousePoint = Input.mousePosition;
        mousePoint.z = _mZCoordinate;
        return Camera.main == null ? Vector3.negativeInfinity : Camera.main.ScreenToWorldPoint(mousePoint);
    }


    void OnMouseUp()
    {
        isDragging = false;
    }

    // Call this method when you want to stop dragging
    public void StopDragging()
    {
        isDragging = false;
    }
}