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
        if(nightend.zombieCount == 1)
        {
            blackScreen.color = new Color(0, 0, 0, 1);       
        }
    }

    // Method to immediately make the black screen visible
    void MakeBlackScreenVisible()
    {
        // Set the black screen image's alpha to 1 to make it fully visible
        blackScreen.color = new Color(0, 0, 0, 1); // Fully opaque (black)
    }
}
