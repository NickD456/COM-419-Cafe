using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Weppon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletVelocity = 30;
    public float bulletPrefabTime = 3f;
    public int currentClip = 5;
    public int maxClip = 5;
    public TMPro.TMP_Text clipText;
    private GameManager gameManager;

    public AudioClip gunshotSound; 
    public AudioSource audioSource;


    private void Awake()
    {
        currentClip = 5;
        clipText.text = "Ammo : " + currentClip.ToString();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    // Update is called once per frame
    void Update()
    {

        if (!gameManager.isPaused)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (currentClip > 0)
                {

                    FireWeapon();
                }

                //FPlayAudioGun();
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                if (currentClip <= 0)
                {
                    Reload();
                }

            }
        }
    }

    private void FireWeapon()
    {

        audioSource.PlayOneShot(gunshotSound);
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);
        currentClip--;
        clipText.text = "Ammo : " + currentClip.ToString();


        bullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward.normalized * bulletVelocity, ForceMode.Impulse);
        //destroy bullet
        //


        StartCoroutine(DestroyBulletAfterTime(bullet,bulletPrefabTime));
    
    }

    public void Reload()
    {
        currentClip = maxClip;
        clipText.text = "Ammo : " + currentClip.ToString();
    }


    private IEnumerator DestroyBulletAfterTime(GameObject bullet,float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(bullet);
    }

    void PlayAudioGun()
    {
     audioSource.PlayOneShot(gunshotSound);

    }
}
    

