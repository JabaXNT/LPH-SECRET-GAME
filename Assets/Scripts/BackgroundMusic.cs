using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusic : MonoBehaviour
{
    private static BackgroundMusic instance;
    private AudioSource audioSource;
    public AudioClip defaultMusic; // Аудиофайл по умолчанию
    public AudioClip alternateMusic; // Альтернативный аудиофайл для определенных сцен

    // Получение экземпляра BackgroundMusic
    public static BackgroundMusic Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        // Проверяем, существует ли уже экземпляр скрипта BackgroundMusic
        if (instance != null && instance != this)
        {
            // Если экземпляр уже существует и не является текущим объектом, уничтожаем текущий объект
            Destroy(gameObject);
            return;
        }

        // Если экземпляр не существует, делаем текущий объект постоянным при переходе между сценами
        instance = this;
        DontDestroyOnLoad(gameObject);

        // Получаем компонент AudioSource для управления воспроизведением музыки
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        // Здесь вы можете настроить воспроизведение музыки, например, загрузить аудиофайл и начать его воспроизведение
        audioSource.volume = 0.3f; // Установите громкость музыки на полную

        // Подписываемся на событие загрузки сцены
        SceneManager.sceneLoaded += OnSceneLoaded;

        // Воспроизводим музыку по умолчанию
        PlayDefaultMusic();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Получаем имя загруженной сцены
        string sceneName = scene.name;
        if (sceneName == "ExhibitScene" || sceneName == "SceneName2")
        {
            audioSource.volume = 0f;
        }
        // Проверяем, находимся ли мы в сцене, где нужно изменить музыку
        if (sceneName == "Pascalina" || sceneName == "SceneName2")
        {
            PlayAlternateMusic();
        }
    }

    void PlayDefaultMusic()
    {
        // Устанавливаем аудиофайл по умолчанию для проигрывания
        audioSource.clip = defaultMusic;
        audioSource.Play();
    }

    void PlayAlternateMusic()
    {
        // Устанавливаем альтернативный аудиофайл для проигрывания
        audioSource.clip = alternateMusic;
        audioSource.Play();
    }
}
