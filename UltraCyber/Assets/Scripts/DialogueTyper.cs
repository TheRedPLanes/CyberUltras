using UnityEngine;
using System.Collections;
using TMPro; // If using TextMeshPro, otherwise use UnityEngine.UI

public class TypewriterEffect : MonoBehaviour
{
    public float delayBetweenCharacters = 0.05f;
    public float delayBeforeStart = 0f;
    public string fullText;

    private TextMeshProUGUI textComponent; // Use Text for regular UI Text

    void Awake()
    {
        textComponent = GetComponent<TextMeshProUGUI>(); // Use GetComponent<Text>() for regular UI Text
        textComponent.text = ""; // Start with an empty text
    }

    void Start()
    {
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        yield return new WaitForSeconds(delayBeforeStart);

        foreach (char character in fullText)
        {
            textComponent.text += character;
            yield return new WaitForSeconds(delayBetweenCharacters);
        }
    }

    // Optional: A method to set new text and restart the effect
    public void SetAndTypeNewText(string newText)
    {
        StopAllCoroutines(); // Stop any ongoing typing
        fullText = newText;
        textComponent.text = ""; // Clear previous text
        StartCoroutine(TypeText());
    }
}