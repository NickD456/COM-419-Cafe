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
        AddSubscriber();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
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
            
            if(value == "yes")
            {
                if (tag == "enter")
                {
                    gameManager.canEnter = true;
                }
                if(tag == "recruit")
                {
                    gameManager.isRecruit = true;
                }
               
                gameManager.canTalk = false;
            }
            else if (value == "no")
            {
                gameManager.canEnter = false;
             
                gameManager.canTalk = false;
                gameManager.turnBack = true;
            }

        }
    }
}
