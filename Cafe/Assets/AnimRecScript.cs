using UnityEngine;

public class AnimRecScript : MonoBehaviour
{
    private GameManager gameManager;
    private Animator anim1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        anim1 = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.hasGun == true)
        {
            Debug.Log("Has Gun");
            anim1.SetBool("HasGun", true);
            Transform child = this.transform.Find("Gun");
            if (child != null)
            {
                child.gameObject.SetActive(true);
            }

        }
        else
        {
            Debug.Log("Does not have gun");
            anim1.SetBool("HasGun", false);
            Transform child = this.transform.Find("Gun");
            if (child != null)
            {
                child.gameObject.SetActive(false);
            }
        }
    }
}
