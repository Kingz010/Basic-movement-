using UnityEngine;

public class MouseMovement : MonoBehaviour
{   
    public float mouseSensitivity = 800f;

    float xRotation = 0f; //pitch = up/down = rotation around x axis
    float yRotation = 0f; //yaw = left/right = rotation around y axis
                          //We set it to 0 because we want to start looking straight ahead


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //Rotation around the x axis (up/down)
        xRotation = xRotation - mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); //clamping so we can't look too far up or down

        //Rotation around the y axis (left/right)
        yRotation = yRotation + mouseX;

        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);

    }
} 