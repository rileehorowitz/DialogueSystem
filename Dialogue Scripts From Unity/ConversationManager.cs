using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationManager : MonoBehaviour
{
    [SerializeField]
    private DialogueChannel m_DialogueChannel;

    public Dialogue chatDialogue;

    public UIDialogueTextboxController tbc;
    public void Awake()
    {
        m_DialogueChannel.RaiseDialogueNodeStart(chatDialogue.FirstNode);
    }


}
