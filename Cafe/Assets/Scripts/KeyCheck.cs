using HarmonyDialogueSystem;
using UnityEngine;


public class KeyCheck : MonoBehaviour
{
    private Character character;
    private GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        AddSubscriber();
    }

    public void AddSubscriber()
    {
        CharacterManager.instance.characterChanged.AddListener(GetCharacterTag);
    }

    public void GetCharacterTag(Character character)
    {
        string tag = gameManager.KeyName;
       

        if (character.LookForCharacterTag(tag, out string value))
        {
          

            if (value == "yes")
            {
                if (tag == "enter")
                {
                    gameManager.canEnter = true;
                }
                if(tag == "recruit")
                {
                    gameManager.isRecruit = true;
                }
                if(tag == "send_out")
                {
                    gameManager.sentLoot = true;
                }

                gameManager.isTalking = false;


            }
            else if (value == "no")
            {
                if (tag != "send_out")
                {

                    gameManager.canEnter = false;
                    gameManager.turnBack = true;
                    
                }

                gameManager.isTalking = false;



            }

        }
    }
}
