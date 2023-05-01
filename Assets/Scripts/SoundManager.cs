using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public float volume = 0.5f;

    void Start()
    {
        AudioListener.volume = volume;
    }

    public void SetVolume(float vol)
    {
        volume = vol;
        AudioListener.volume = volume;
    }
}
