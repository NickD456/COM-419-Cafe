using UnityEngine;

namespace HarmonyDialogueSystem
{
    public class DialogueStartTrigger : MonoBehaviour
    {
        [Tooltip("The File type being used")]
        public FileTypeUsed fileTypeUsed;

        [Tooltip("The Dialogue File to use")]
        public TextAsset dialogueFile;

        private void Start()
        {
            Debug.Log("DialogueStartTrigger started");
            DialogueManager.instance.EnterDialogueMode(dialogueFile, fileTypeUsed);
        }
    }
}
