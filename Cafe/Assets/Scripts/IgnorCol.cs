using UnityEngine;

public class IgnorCol : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Physics.IgnoreLayerCollision(7, 8);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
