using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class NightEnd : MonoBehaviour
{
private ZombieSpawn zombieSpawn;

public string nextSceneName;
private NightEnd nightend;
public int zombieCount =0;
private GameManager gameManager;
private Weppon weppon;

    public Image fadeImage; // Assign this in the Unity Inspector
 public float fadeDuration = 4f; // Duration of the fade effect
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        zombieSpawn = GameObject.Find("Zombie Spawn").GetComponent<ZombieSpawn>();
        
       // weppon.audioSource = GetComponent<AudioSource>();

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        
    }

    // Update is called once per frame
    void Update()
    {


        if(zombieCount <= 0 )
        {
            StartCoroutine(FadeToBlackAndLoadScene());
        }
        
    }

    IEnumerator FadeToBlackAndLoadScene()
    {
        float elapsedTime = 0f;
        Color startColor = fadeImage.color;
        Color endColor = new Color(0, 0, 0, 1); // Fully black

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            fadeImage.color = Color.Lerp(startColor, endColor, elapsedTime / fadeDuration);
            yield return null;
        }

        fadeImage.color = endColor;
        gameManager.dayNum += 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

}