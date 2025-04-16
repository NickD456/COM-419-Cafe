using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    private GameManager gameManager;
    private Animator anim1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim1 = GetComponent<Animator>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.doorClose)
        {
           
            anim1.SetBool("Open", false);
        }
        else
        
        {
           
            anim1.SetBool("Open", true);
        }

    }

    void OpenDoor()
    {

    }

    void CloseDoor()
    {
        
    }
}
