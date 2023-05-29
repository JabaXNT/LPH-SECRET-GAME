using UnityEngine;
using UnityEngine.UI;

public class ToggleVisibility : MonoBehaviour
{
    public GameObject objectToHide;
    public GameObject objectToShow;

    private Button button;

    void Start()
    {
        // Получаем компонент Button
        button = GetComponent<Button>();

        // Назначаем метод-обработчик на событие клика кнопки
        button.onClick.AddListener(ToggleObjectsVisibility);
    }

    void ToggleObjectsVisibility()
    {
        // Переключаем видимость объектов
        objectToHide.SetActive(false);
        objectToShow.SetActive(true);
    }
}
