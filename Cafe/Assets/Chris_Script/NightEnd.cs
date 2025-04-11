using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering;

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

        
        

       

    }

    // Update is called once per frame
    void Update()
    {

        if (gameManager == null)
        {
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        }
        if (zombieCount <= 0 )
        {
            StartCoroutine(FadeToBlackAndLoadScene());
            if (gameManager.dayNum > PlayerPrefs.GetInt("HighScore", 0))
            {
                PlayerPrefs.SetInt("HighScore", gameManager.dayNum);
            }
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
        if (gameManager == null)
        {
            Debug.LogError("GameManager not found");
        }
        fadeImage.color = endColor;
        gameManager.dayNum += 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

}