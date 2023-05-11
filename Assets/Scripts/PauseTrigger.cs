using UnityEngine;
using UnityEngine.InputSystem;

public class PauseTrigger : MonoBehaviour
{
    public GameObject pauseLayout;

    void Update()
    {
        // Check if the escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Show the pause layout
            ShowPauseLayout();
        }
    }

    public void OnPauseButtonClick()
    {
        // Show the pause layout
        ShowPauseLayout();
    }

    private void ShowPauseLayout()
    {
        // Show the pause layout
        pauseLayout.SetActive(true);

        // Pause the game
        Time.timeScale = 0f;
    }

    public void OnResumeButtonClick()
    {
        // Hide the pause layout
        pauseLayout.SetActive(false);

        // Unpause the game
        Time.timeScale = 1f;
    }
}
