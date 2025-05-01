using UnityEngine;

public class SunCycle : MonoBehaviour
{
    public float rotationSpeed = 0.0007f; // Degrees per second
    private float sceneTimer = 0f;

    void Update()
    {
        // Increment your own timer
        sceneTimer += Time.deltaTime;

        // Rotate based on elapsed scene time
        float rotationAngle = sceneTimer * rotationSpeed;

        transform.Rotate(Vector3.right, rotationAngle * Time.deltaTime);
    }
}