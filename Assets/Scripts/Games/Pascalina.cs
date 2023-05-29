using UnityEngine;
using UnityEngine.UI;

public class Pascalina : MonoBehaviour
{
    public Text numberText1;
    public Text numberText2;

    public void ModifyNumbers()
    {
        int number1 = int.Parse(numberText1.text);
        int number2 = int.Parse(numberText2.text);

        // Уменьшаем первое число и увеличиваем второе число
        number1--;
        number2++;

        // Проверяем, что первое число не меньше 0
        if (number1 < 0)
            number1 = 9;

        // Проверяем, что второе число не больше 9
        if (number2 > 9)
            number2 = 0;

        // Обновляем значения в текстовых полях
        numberText1.text = number1.ToString();
        numberText2.text = number2.ToString();
    }
}
