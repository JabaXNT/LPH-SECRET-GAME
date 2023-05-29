using UnityEngine;
using UnityEngine.UI;

public class AnswerCheck : MonoBehaviour
{
    public InputField resultInputField;
    public Text[] inputFields;

    private void Update()
    {
        // Объединение чисел из всех текстовых полей
        string concatenatedString = "";
        for (int i = 0; i < inputFields.Length; i++)
        {
            concatenatedString += inputFields[i].text;
        }

        // Отображение объединенной строки в результате
        resultInputField.text = concatenatedString;
    }
}
