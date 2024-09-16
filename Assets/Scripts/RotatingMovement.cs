using UnityEngine;

public class RotatingMovement : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 45f;
    [SerializeField] private Transform rotateAround;

    private bool autoRotate = false;
    private bool rotateClockwise = true;

    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            Rotate(Vector3.forward);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            Rotate(-Vector3.forward);
        }

        if (Input.GetKey(KeyCode.A))
        {
            RotateAround(Vector3.forward);
        }

        if (Input.GetKey(KeyCode.D))
        {
            RotateAround(-Vector3.forward);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ToggleAutoRotation();
        }

        if (autoRotate)
        {
            RotateAround(rotateClockwise ? Vector3.forward : -Vector3.forward);
        }
    }

    private void Rotate(Vector3 axis)
    {
        transform.Rotate(axis, rotationSpeed * Time.deltaTime);
    }

    private void RotateAround(Vector3 axis)
    {
        transform.RotateAround(rotateAround.position, axis, rotationSpeed * Time.deltaTime);
    }

    private void ToggleAutoRotation()
    {
        autoRotate = !autoRotate;

        if (autoRotate)
        {
            rotateClockwise = !rotateClockwise;
        }
    }
}
