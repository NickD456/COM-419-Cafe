using UnityEngine;
using TMPro;

public class BillboardText : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Make the text always face the camera
        transform.forward = mainCamera.transform.forward;
    }
}