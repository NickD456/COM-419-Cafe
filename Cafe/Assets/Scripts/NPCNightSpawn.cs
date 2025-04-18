using UnityEngine;

public class NPCNightSpawn : MonoBehaviour
{

private NightEnd nightend;
private GameManager gameManager;

public Transform spawnPoint1; 
public Transform spawnPoint2;
public Transform spawnPoint3;
public Transform spawnPoint4;
public GameObject bulletPrefab;
    public AudioClip shootClip;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
              gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        gameManager.hasGun = true;

        Debug.Log(gameManager.recruitedNPC[0]);
        if (gameManager.recruitedNPC[0] != null)
        {

            Quaternion rotation = Quaternion.Euler(0, 90, 0);
            GameObject npc = Instantiate(gameManager.recruitedNPC[0], spawnPoint4.position, rotation);
            NPCShooter shooter = npc.GetComponent<NPCShooter>();
            if (shooter != null)
            {
                shooter.bulletPrefab = bulletPrefab;
                AudioSource audio = npc.GetComponent<AudioSource>();
                if (audio != null)
                {
                    audio.playOnAwake = false;
                    audio.clip = shootClip; // Optional if the shooter script sets the clip
                    shooter.audioSource = audio;
                }
            }
        }
        if (gameManager.recruitedNPC[1] != null) {
            Quaternion rotation = Quaternion.Euler(0, 90, 0);
            GameObject npc = Instantiate(gameManager.recruitedNPC[1], spawnPoint1.position, rotation);

            NPCShooter shooter = npc.GetComponent<NPCShooter>();
            if (shooter != null)
            {
                shooter.bulletPrefab = bulletPrefab;
                AudioSource audio = npc.GetComponent<AudioSource>();
                if (audio != null)
                {
                    audio.playOnAwake = false;
                    audio.clip = shootClip; // Optional if the shooter script sets the clip
                    shooter.audioSource = audio;
                }
            }
            }

        if (gameManager.recruitedNPC[2] != null)
        {
            Quaternion rotation = Quaternion.Euler(0, 90, 0);
            GameObject npc = Instantiate(gameManager.recruitedNPC[2], spawnPoint2.position, rotation);
            NPCShooter shooter = npc.GetComponent<NPCShooter>();
            if (shooter != null)
            {
                shooter.bulletPrefab = bulletPrefab;
                AudioSource audio = npc.GetComponent<AudioSource>();
                if (audio != null)
                {
                    audio.playOnAwake = false;
                    audio.clip = shootClip; // Optional if the shooter script sets the clip
                    shooter.audioSource = audio;
                }
            }
        }
        if (gameManager.recruitedNPC[3] != null)
        {
            Quaternion rotation = Quaternion.Euler(0, 90, 0);
            GameObject npc = Instantiate(gameManager.recruitedNPC[3], spawnPoint3.position, rotation);
            NPCShooter shooter = npc.GetComponent<NPCShooter>();
            if (shooter != null)
            {
                shooter.bulletPrefab = bulletPrefab;
                AudioSource audio = npc.GetComponent<AudioSource>();
                if (audio != null)
                {
                    audio.playOnAwake = false;
                    audio.clip = shootClip; // Optional if the shooter script sets the clip
                    shooter.audioSource = audio;
                }
            }
        }
        






    }
}