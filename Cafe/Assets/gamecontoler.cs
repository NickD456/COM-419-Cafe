using UnityEngine;

public class gamecontoler : MonoBehaviour
{
    public GameObject player;
    public GameObject zombie;
    public GameObject bullet;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("zombie"))
        {
            print("hit " + collision.gameObject.name + " !");
            Destroy(zombie);
            
        }
    }


}