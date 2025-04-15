using UnityEngine;

public class DestroyCust : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyTalkObject()
    {
        Debug.Log("Destroying Object");
        Destroy(this.gameObject);
    }
}
