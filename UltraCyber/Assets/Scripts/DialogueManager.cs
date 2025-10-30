// DialogueManager.cs
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class DialogueManager : MonoBehaviour
{
    [Header("Config")]
    public DialogueTree dialogueTree;      // assign the DialogueTree asset
    public DialogueNode startNode;         // optional: startNode (if null uses dialogueTree.rootNode)

    [Header("UI")]
    public TMPro.TextMeshProUGUI promptText;                // UnityEngine.UI.Text (swap to TMP if desired)
    public Button buttonA;
    public Button buttonB;
    public TMPro.TextMeshProUGUI buttonAText;
    public TMPro.TextMeshProUGUI buttonBText;

    private DialogueNode current;

    void Start()
    {
        current = startNode != null ? startNode : dialogueTree?.rootNode;
        if (current == null)
        {
            Debug.LogError("DialogueManager: No start node or root node assigned.");
            return;
        }

        // hook up listeners (optional: remove previous listeners)
        buttonA.onClick.RemoveAllListeners();
        buttonB.onClick.RemoveAllListeners();
        buttonA.onClick.AddListener(ChooseA);
        buttonB.onClick.AddListener(ChooseB);

        RefreshUI();
    }

    void RefreshUI()
    {
        promptText.text = current.promptText ?? "";

        // If this is an ending node, show choices as final labels (or hide buttons and trigger)
        if (current.isEnding)
        {
            // make both buttons act as final choices that load the assigned scene.
            // You could also show a single button or different text.
            buttonAText.text = current.optionAText ?? "Confirm A";
            buttonBText.text = current.optionBText ?? "Confirm B";
        }
        else
        {
            buttonAText.text = current.optionAText ?? "Option A";
            buttonBText.text = current.optionBText ?? "Option B";
        }

        // optionally disable a button if its node reference is null
        buttonA.interactable = (current.optionANode != null || current.isEnding);
        buttonB.interactable = (current.optionBNode != null || current.isEnding);
    }

    public void ChooseA()
    {
        if (current.isEnding)
        {
            // On final selection, use whichever scene name is appropriate.
            // Option: choose between different scenes depending on A vs B final selection.
            // We assume the node stores a single sceneToLoad — if you want different scenes for A vs B,
            // you can instead store sceneToLoadA and sceneToLoadB on the node.
            if (!string.IsNullOrEmpty(current.sceneToLoad))
            {
                SceneManager.LoadScene(current.sceneToLoad);
            }
            else
            {
                Debug.LogWarning("DialogueManager: Ending node has no sceneToLoad assigned.");
            }
            return;
        }

        if (current.optionANode != null)
        {
            current = current.optionANode;
            RefreshUI();
        }
        else
        {
            Debug.LogWarning("DialogueManager: chosen A but optionANode is null.");
        }
    }

    public void ChooseB()
    {
        if (current.isEnding)
        {
            if (!string.IsNullOrEmpty(current.sceneToLoad))
            {
                SceneManager.LoadScene(current.sceneToLoad);
            }
            else
            {
                Debug.LogWarning("DialogueManager: Ending node has no sceneToLoad assigned.");
            }
            return;
        }

        if (current.optionBNode != null)
        {
            current = current.optionBNode;
            RefreshUI();
        }
        else
        {
            Debug.LogWarning("DialogueManager: chosen B but optionBNode is null.");
        }
    }
}
