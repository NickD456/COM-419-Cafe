using UnityEngine;

public class AnimeSet1 : MonoBehaviour
{
    private Animator anim1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim1 = GetComponent<Animator>();
        anim1.SetBool("Sitting1", true);
        Debug.Log("hi");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
