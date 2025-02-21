using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BlackoutScreen : MonoBehaviour
{
    public Image blackScreen; // Assign the black screen UI Image here
    public float fadeDuration = 1f;
    private NightEnd nightend;
    private void Start()
    {
        blackScreen.color = new Color(0, 0, 0, 0); // Make sure it's invisible at the start
    }

    void Update()
    {
        if(nightend.zombieCount == 0)
        {
            FadeToBlack();
        }
    }

    public void FadeToBlack()
    {
        StartCoroutine(FadeBlack());
    }

    private IEnumerator FadeBlack()
    {
        float elapsedTime = 0f;
        Color startColor = blackScreen.color;
        Color endColor = new Color(0, 0, 0, 1); // Fully black

        while (elapsedTime < fadeDuration)
        {
            blackScreen.color = Color.Lerp(startColor, endColor, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        blackScreen.color = endColor; // Ensure it ends fully black
    }
}