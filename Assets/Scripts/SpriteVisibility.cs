using UnityEngine;

public class SpriteVisibility : MonoBehaviour
{
    public GameObject spriteObject; // Ссылка на объект спрайта

    private void Start()
    {
        // Проверяем значение переменной isVisible при запуске сцены и устанавливаем видимость спрайта
        if (TestLoader.isVisible)
        {
            spriteObject.SetActive(true);
        }
        else
        {
            spriteObject.SetActive(false);
        }
    }
}
