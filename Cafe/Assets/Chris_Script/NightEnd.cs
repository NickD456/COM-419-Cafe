using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class NightEnd : MonoBehaviour
{
public string nextSceneName;
private NightEnd nightend;
public int zombieCount =1;
private GameManager gameManager;
public TMP_Text DayNum;

    public Image fadeImage; // Assign this in the Unity Inspector
 public float fadeDuration = 4f; // Duration of the fade effect
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        DayNum.text = "DayNum: " + gameManager.dayNum;
    }

    // Update is called once per frame
    void Update()
    {

        if(zombieCount == 0){
            Debug.Log("Zomb 0");
            StartCoroutine(FadeToBlackAndLoadScene());
        }
        Debug.Log(zombieCount);
        
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