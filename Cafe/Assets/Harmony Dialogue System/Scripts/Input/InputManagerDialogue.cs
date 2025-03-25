using UnityEngine;

namespace HarmonyDialogueSystem
{
    public class InputManagerDialogue : MonoBehaviour
    {

        private GameManager gameManager;

        public static InputManagerDialogue instance;

        public void Start()
        {
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        }
        private void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(instance);
            }

            instance = this;
            
        }

        /// <summary>
        /// If the User is interacting with a trigger
        /// </summary>
        /// <returns></returns>
        public static bool isInteracting()
        {
            instance.makeInteract();
            return Input.GetKeyDown(KeyCode.I);
            Debug.Log("Interacting");
        }

        /// <summary>
        /// If the user is continuing on with the dialogue flow
        /// </summary>
        /// <returns></returns>
        public static bool isContinuing()
        {
            return Input.GetKeyDown(KeyCode.Space);
        }

        public void makeInteract()
        {
            gameManager.isTalking = true;
        }
    }
}
