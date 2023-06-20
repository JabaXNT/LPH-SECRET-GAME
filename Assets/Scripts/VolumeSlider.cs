using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public Slider volumeSlider;
    private AudioSource audioSource;

    private void Start()
    {
        // Находим компонент AudioSource в текущей сцене
        audioSource = FindObjectOfType<AudioSource>();

        if (audioSource != null)
        {
            // Устанавливаем начальное значение слайдера
            volumeSlider.value = audioSource.volume;

            // Добавляем обработчик события изменения значения слайдера
            volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
        }
    }

    private void OnVolumeChanged(float volume)
    {
        // Изменяем громкость аудиоисточника на основе значения слайдера
        audioSource.volume = volume;
    }
}
