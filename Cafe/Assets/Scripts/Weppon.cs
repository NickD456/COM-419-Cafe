using UnityEngine;
using System.Collections;


public class Weppon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletVelocity = 30;
    public float bulletPrefabTime = 3f;

    // Update is called once per frame
    void Update()
    {
     if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            FireWeapon();
        }
    }

    private void FireWeapon()
    {

        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);

        bullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward.normalized * bulletVelocity, ForceMode.Impulse);
        //destroy bullet

        StartCoroutine(DestroyBulletAfterTime(bullet,bulletPrefabTime));
    
    }


    private IEnumerator DestroyBulletAfterTime(GameObject bullet,float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(bullet);
    }
}
    

