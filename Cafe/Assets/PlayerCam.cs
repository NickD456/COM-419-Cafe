using UnityEngine;

public class PlayerCam : MonoBehaviour
{


    public double sensX;
    public double sensY;

    public Transform orientation;

    double xRotation;
    double yRotation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {
        double mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        double mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensX;

        yRotation += mouseX;
        xRotation -= mouseY;
    }
}
