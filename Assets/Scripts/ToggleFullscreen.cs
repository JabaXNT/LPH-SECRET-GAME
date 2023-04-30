using UnityEngine;
using UnityEngine.UI;

public class ToggleFullscreen : MonoBehaviour
{
    public Toggle fullscreenToggle;

    public void SetFullscreen()
    {
        Screen.fullScreen = fullscreenToggle.isOn;
    }
}
