using UnityEngine;
using UnityEngine.UI;

public class CompareAnswer : MonoBehaviour
{
    public InputField inputField;
    public int targetNumber;
    public Button compareButton;

    private Color correctColor = Color.green;
    private Color incorrectColor = Color.red;

    private void Start()
    {
        compareButton.onClick.AddListener(CompareInputNumber);
    }

    private void CompareInputNumber()
    {
        int inputNumber = int.Parse(inputField.text);

        if (inputNumber == targetNumber)
        {
            compareButton.image.color = correctColor;
        }
        else
        {
            compareButton.image.color = incorrectColor;
        }
    }
}
