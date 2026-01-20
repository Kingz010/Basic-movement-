using UnityEngine;

public class MouseMovement3 : MonoBehaviour
{
    public Transform player;

    public float mouseSensitivity = 1000f;

    public float minXAngle = -30f;
    public float maxXAngle = 30f;
    public float minYAngle = -360f;
    public float maxYAngle = 360;

    public float smoothSpeed = 100f;

    float xRotation = 0f;
    float yRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mousey = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mousey;
        yRotation += mouseX;

        xRotation = Mathf.Clamp(xRotation, minXAngle, maxXAngle);
        yRotation = Mathf.Clamp(yRotation, minYAngle, maxYAngle);

        Quaternion targetRotation = Quaternion.Euler(xRotation, yRotation, 0f);

        player.rotation = Quaternion.Slerp(player.rotation, targetRotation, smoothSpeed * Time.deltaTime);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, smoothSpeed * Time.deltaTime);
    }
}
