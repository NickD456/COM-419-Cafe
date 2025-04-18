using UnityEngine;

public class NPCShooter : MonoBehaviour
{
    private Transform firePoint;           // Where the bullets spawn from
    public GameObject bulletPrefab;       // Your bullet prefab
    public float shootRange = 15f;
    public float fireRate = 1f;
    private float nextFireTime = 0f;
    private GameManager gameManager;
    public AudioSource audioSource;
    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
        if (gameManager.hasGun == true)
        {
            firePoint = transform.Find("Gun/FirePoint");

            GameObject target = FindClosestZombie();
            if (target != null && Time.time >= nextFireTime)
            {
                Vector3 direction = (target.transform.position - firePoint.position).normalized;
                Shoot(direction);
                nextFireTime = Time.time + 1f / fireRate;
            }
        }
    }

    GameObject FindClosestZombie()
    {
        GameObject[] zombies = GameObject.FindGameObjectsWithTag("Zombie");
        GameObject closest = null;
        float minDist = Mathf.Infinity;

        foreach (GameObject zombie in zombies)
        {
            float dist = Vector3.Distance(transform.position, zombie.transform.position);
            if (dist < minDist && dist <= shootRange)
            {
                minDist = dist;
                closest = zombie;
            }
        }

        return closest;
    }

    void Shoot(Vector3 direction)
    {
        if (audioSource != null)
        {
            Debug.Log("Playing shoot sound");
            audioSource.Play();
        }
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.LookRotation(direction));
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = direction * 100f; // bullet speed

        }

        // Optional: trigger shoot animation
        // GetComponent<Animator>().SetTrigger("Shoot");
    }
}

