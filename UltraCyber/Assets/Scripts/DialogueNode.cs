// DialogueNode.cs
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/Binary Node")]
public class DialogueNode : ScriptableObject
{
    [TextArea(2, 6)]
    public string promptText;

    [Header("Option A")]
    public string optionAText;
    public DialogueNode optionANode;

    [Header("Option B")]
    public string optionBText;
    public DialogueNode optionBNode;

    [Header("Ending (leaf)")]
    public bool isEnding;               // mark true for a finish
    [Tooltip("Runtime scene name to load when this node is chosen as final.")]
    public string sceneToLoad;          // runtime scene name

}
