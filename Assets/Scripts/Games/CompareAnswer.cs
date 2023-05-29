using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text.RegularExpressions;
using System.Data;

public class CompareAnswer : MonoBehaviour
{
    public InputField inputField;
    public Text targetText;
    public Button compareButton;

    private Color correctColor = Color.green;
    private Color incorrectColor = Color.red;

    private void Start()
    {
        compareButton.onClick.AddListener(CompareInputNumber);
    }

    private void CompareInputNumber()
    {
        string targetString = targetText.text;
        string inputString = inputField.text;

        // Удаление всех пробелов из строк
        targetString = targetString.Replace(" ", "");
        inputString = inputString.Replace(" ", "");

        // Удаление всех символов, кроме цифр и знаков плюса и минуса
        targetString = Regex.Replace(targetString, "[^0-9+-]", "");
        inputString = Regex.Replace(inputString, "[^0-9+-]", "");

        // Вычисление значения целевой строки
        int targetNumber = EvaluateMathExpression(targetString);

        int inputNumber;
        if (!int.TryParse(inputString, out inputNumber))
        {
            // Не удалось преобразовать введенное значение в число
            return;
        }

        if (inputNumber == targetNumber)
        {
            compareButton.image.color = correctColor;
        }
        else
        {
            compareButton.image.color = incorrectColor;
        }
    }

    private int EvaluateMathExpression(string expression)
    {
        try
        {
            return (int)Convert.ToDouble(new DataTable().Compute(expression, null));
        }
        catch (Exception)
        {
            // Не удалось вычислить выражение
            return 0;
        }
    }
}
