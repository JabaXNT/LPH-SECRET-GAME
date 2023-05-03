using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoToText : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject videoPanel;
    public GameObject textPanel;

    private bool isPlaying;

    void Start()
    {
        // Hide the text panel at start
        textPanel.SetActive(false);

        // Add listener for video player to detect when the video has ended
        videoPlayer.loopPointReached += EndReached;

        // Play the video
        videoPlayer.Play();
        isPlaying = true;
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        // When video ends, hide the video panel and show the text panel
        videoPanel.SetActive(false);
        textPanel.SetActive(true);
    }

    public void OnButtonClick()
    {
        if (videoPanel.activeSelf)
        {
            // Pause the video
            videoPlayer.Pause();
            isPlaying = false;

            // Show the text panel and hide the video panel
            textPanel.SetActive(true);
            videoPanel.SetActive(false);

            // Change the button text to "Video"
            GetComponentInChildren<Text>().text = "Видео";
        }
        else
        {

            // Hide the text panel and show the video panel
            textPanel.SetActive(false);
            videoPanel.SetActive(true);

            // Change the button text to "Text"
            GetComponentInChildren<Text>().text = "Текст";
        }
    }

    void Update()
    {
        // Check if the video is playing and if the user presses the "space" key
        if (isPlaying && Input.GetKeyDown(KeyCode.Space))
        {
            // Pause the video
            videoPlayer.Pause();
            isPlaying = false;

            // Show the text panel
            textPanel.SetActive(true);
        }
        // Check if the video is paused and if the user presses the "space" key
        else if (!isPlaying && Input.GetKeyDown(KeyCode.Space))
        {
            // Resume playing the video
            videoPlayer.Play();
            isPlaying = true;

            // Hide the text panel
            textPanel.SetActive(false);
        }
    }
}
