using UnityEngine;

public class FlyCamera : MonoBehaviour
{
    [SerializeField] private bool isRotating;
    private readonly float _mainSpeed = 100.0f; //regular speed
    private float _rotationY;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1)) isRotating = true;

        if (Input.GetMouseButtonUp(1)) isRotating = false;

        if (isRotating)
        {
            var rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X");
            _rotationY += Input.GetAxis("Mouse Y");
            _rotationY = Mathf.Clamp(_rotationY, -90, 90);
            transform.localEulerAngles = new Vector3(-_rotationY, rotationX, 0.0f);
        }

        var p = GetBaseInput() * _mainSpeed;
        p *= Time.deltaTime;

        transform.Translate(p);
    }

    private static Vector3 GetBaseInput()
    {
        var pVelocity = new Vector3();
        if (Input.GetKey(KeyCode.W)) pVelocity += new Vector3(0, 0, 1);
        if (Input.GetKey(KeyCode.S)) pVelocity += new Vector3(0, 0, -1);
        if (Input.GetKey(KeyCode.A)) pVelocity += new Vector3(-1, 0, 0);
        if (Input.GetKey(KeyCode.D)) pVelocity += new Vector3(1, 0, 0);
        return pVelocity;
    }
}