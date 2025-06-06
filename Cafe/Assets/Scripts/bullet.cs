using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
public NightEnd nightend;
public int zombieCount;
    public float lifetime = 0.5f;

    private void Start()
    {
        nightend = GameObject.Find("NightEnd").GetComponent<NightEnd>();
        Destroy(gameObject, lifetime);
    }
    void OnCollisionEnter(Collision collision)
    {
        // Check if the bullet collided with an object tagged "Zombie"
        if (collision.gameObject.CompareTag("Zombie"))
        {
            // Destroy the zombie
            Destroy(collision.gameObject); 
            nightend.zombieCount -=1;
             // Destroy the zombie object that was hit

            // Optionally, destroy the bullet itself
            Destroy(gameObject);  
        }
    }




}

