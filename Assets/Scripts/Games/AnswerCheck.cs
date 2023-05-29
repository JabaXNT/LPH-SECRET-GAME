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
            string inputText = inputFields[i].text;
            // Удаляем незначащие нули в начале числа
            inputText = inputText.TrimStart('0');
            concatenatedString += inputText;
        }

        // Отображение объединенной строки в результате
        resultInputField.text = concatenatedString;
    }
}
