using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Narration/Character")]
public class NarrationCharacter : ScriptableObject
{
    [SerializeField]
    private string m_CharacterName;

    [SerializeField]
    private Color m_CharacterColor;

    public string CharacterName => m_CharacterName;
    public Color CharacterColor => m_CharacterColor;
}
