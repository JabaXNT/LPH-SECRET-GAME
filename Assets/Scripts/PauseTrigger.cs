using UnityEngine;

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

        // Disable player input
        // (you can use this to prevent the player from moving or doing anything else while the game is paused)
        //GetComponent<PlayerInput>().enabled = false;
    }

    public void OnResumeButtonClick()
    {
        // Hide the pause layout
        pauseLayout.SetActive(false);

        // Unpause the game
        Time.timeScale = 1f;

        // Enable player input
        //GetComponent<PlayerInput>().enabled = true;
    }
}
