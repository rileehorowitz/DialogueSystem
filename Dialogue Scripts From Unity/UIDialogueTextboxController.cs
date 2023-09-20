using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UIDialogueTextboxController : MonoBehaviour, DialogueNodeVisitor
{
    [SerializeField]
    private GameObject TextBoxPrefab;
    private float tbPadding;

    private Vector3 currentPos;

    public List<GameObject>MessageHistory = new List<GameObject>();

    [SerializeField]
    private RectTransform m_ChoicesBoxTransform;
    [SerializeField]
    private UIDialogueChoiceController m_ChoiceControllerPrefab;

    [SerializeField]
    private DialogueChannel m_DialogueChannel;

    private bool m_ListenToInput = false;
    private DialogueNode m_NextNode = null;

    private void Awake()
    {
        tbPadding = TextBoxPrefab.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta.y + TextBoxPrefab.transform.GetChild(1).GetComponent<RectTransform>().sizeDelta.y + TextBoxPrefab.transform.GetChild(2).GetComponent<RectTransform>().sizeDelta.y;
        m_DialogueChannel.OnDialogueNodeStart += OnDialogueNodeStart;
        m_DialogueChannel.OnDialogueNodeEnd += OnDialogueNodeEnd;

        //gameObject.SetActive(false);
        m_ChoicesBoxTransform.gameObject.SetActive(false);

        currentPos = gameObject.GetComponent<RectTransform>().position;
    }

    private void OnDestroy()
    {
        m_DialogueChannel.OnDialogueNodeStart -= OnDialogueNodeStart;
        m_DialogueChannel.OnDialogueNodeEnd -= OnDialogueNodeEnd;
    }

    private void Update()
    {
        //maintainSize(MessageHistory[MessageHistory.Count - 1]);

        if (m_ListenToInput && Input.GetButtonDown("Submit"))
        {
            m_DialogueChannel.RaiseRequestDialogueNode(m_NextNode);
        }

       
    }

    private void OnDialogueNodeStart(DialogueNode node)
    {
        //gameObject.SetActive(true);

        generateBox(node);        
        if (MessageHistory.Count > 1)
        {
            sendUpMessage();
        }
        

        node.Accept(this);
    }

    private void OnDialogueNodeEnd(DialogueNode node)
    {
        m_NextNode = null;
        m_ListenToInput = false;

        foreach (Transform child in m_ChoicesBoxTransform)
        {
            Destroy(child.gameObject);
        }

        //gameObject.SetActive(false);
        m_ChoicesBoxTransform.gameObject.SetActive(false);
    }

    public void Visit(BasicDialogueNode node)
    {
        m_ListenToInput = true;
        m_NextNode = node.NextNode;
    }

    public void Visit(ChoiceDialogueNode node)
    {
        m_ChoicesBoxTransform.gameObject.SetActive(true);

        foreach (DialogueChoice choice in node.Choices)
        {
            UIDialogueChoiceController newChoice = Instantiate(m_ChoiceControllerPrefab, m_ChoicesBoxTransform);
            newChoice.Choice = choice;
            newChoice.m_Controller = this;
            newChoice.m_DialogueChannel = m_DialogueChannel;
        }
    }

    public void sendUpMessage()
    {
        float pad = (MessageHistory[MessageHistory.Count-1].GetComponent<RectTransform>().sizeDelta.y / 2f) + (MessageHistory[MessageHistory.Count - 2].GetComponent<RectTransform>().sizeDelta.y / 2f) + tbPadding;
        
        for (int i = 0; i < MessageHistory.Count-1; i++)
        {
            RectTransform newPos = MessageHistory[i].GetComponent<RectTransform>();
            newPos.position += new Vector3(0, pad, 0);
        }
    }
    public void generateBox(DialogueNode node)
    {
        GameObject curText = Instantiate(TextBoxPrefab, transform.parent);
        curText.GetComponent<RectTransform>().localScale = gameObject.GetComponent<RectTransform>().localScale;
        MessageHistory.Add(curText);

        curText.transform.GetChild(3).GetComponent<TextMeshProUGUI>().SetText(node.DialogueLine.Text);
        curText.transform.GetChild(2).GetComponent<TextMeshProUGUI>().SetText(node.DialogueLine.Speaker.CharacterName);
        curText.GetComponent<Image>().color = node.DialogueLine.Speaker.CharacterColor;
        curText.transform.GetChild(0).GetComponent<Image>().color = node.DialogueLine.Speaker.CharacterColor;
        curText.transform.GetChild(1).GetComponent<Image>().color = node.DialogueLine.Speaker.CharacterColor;

        if (curText.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text != "Me")
        {
            curText.GetComponent<RectTransform>().position = currentPos + (Vector3.left * 100);
            curText.transform.GetChild(0).GetComponent<RectTransform>().localPosition = Vector3.zero;
            curText.transform.GetChild(0).GetComponent<RectTransform>().rotation = new Quaternion(0, 0, 0, 1);
        }
        else
        {
            curText.GetComponent<RectTransform>().position = currentPos;
            curText.transform.GetChild(0).GetComponent<RectTransform>().localPosition = new Vector3(22f,0,0);
            curText.transform.GetChild(0).GetComponent<RectTransform>().rotation = new Quaternion(0, 180, 0,1);
        }

        maintainSize(curText);
    }
    public void maintainSize(GameObject textBox)
    {
        Canvas.ForceUpdateCanvases();
        float dif = Mathf.Abs(textBox.GetComponent<RectTransform>().sizeDelta.y - textBox.transform.GetChild(3).GetComponent<RectTransform>().sizeDelta.y);

        textBox.GetComponent<RectTransform>().sizeDelta = new Vector2(textBox.GetComponent<RectTransform>().sizeDelta.x, textBox.transform.GetChild(3).GetComponent<RectTransform>().sizeDelta.y);

        textBox.transform.GetChild(2).GetComponent<RectTransform>().localPosition = new Vector3(-100, textBox.GetComponent<RectTransform>().sizeDelta.y / 2f + 20f, 0);
        textBox.transform.GetChild(0).GetComponent<RectTransform>().localPosition = new Vector3(textBox.transform.GetChild(0).GetComponent<RectTransform>().localPosition.x, textBox.GetComponent<RectTransform>().sizeDelta.y/2 + textBox.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta.y/2, 0);
        textBox.transform.GetChild(1).GetComponent<RectTransform>().localPosition = new Vector3(0, -(textBox.GetComponent<RectTransform>().sizeDelta.y / 2 + textBox.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta.y / 2), 0);
    }
}
