using UnityEngine;

public class GameButtonVisibility : MonoBehaviour
{
    public GameObject spriteObject; // Ссылка на объект спрайта
    private ExhibitData exhibitData;

    private void Start()
    {
        exhibitData = exhibitData = ExhibitData.currentExhibit;;
        // Проверяем значение переменной isVisible при запуске сцены и устанавливаем видимость спрайта
        if (exhibitData.gameScene == "Scenes/Pascalina")
        {
            spriteObject.SetActive(true);
        }
        else
        {
            spriteObject.SetActive(false);
        }
    }
}
