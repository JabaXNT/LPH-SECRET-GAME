using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoToTextToImage : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject videoPanel;
    public GameObject textPanel;
    public GameObject imagePanel;
    public Scrollbar videoScrollbar;

    private bool isPlaying;
    private int currentPanel = 0; // 0 = video, 1 = text, 2 = image
    private double lastPlaybackTime; // to store the last playback time of the video
    private bool scrollbarEnabled; // to store whether the scrollbar is enabled or not

    void Start()
    {
        // Show the video panel and hide the text and image panels at start
        videoPanel.SetActive(true);
        textPanel.SetActive(false);
        imagePanel.SetActive(false);

        // Add listener for video player to detect when the video has ended
        videoPlayer.loopPointReached += EndReached;

        // Play the video
        videoPlayer.Play();
        isPlaying = true;
        scrollbarEnabled = true;
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        // When video ends, hide the video panel and show the text panel
        videoPanel.SetActive(false);
        textPanel.SetActive(true);
        currentPanel = 1;
        scrollbarEnabled = false;
        videoScrollbar.gameObject.SetActive(false);
    }

    public void OnVideoButtonClick()
    {
        if (currentPanel != 0)
        {
            // Stop playing the video and hide the text and image panels
            videoPlayer.Pause();
            isPlaying = false;
            lastPlaybackTime = videoPlayer.time; // save the last playback time
            textPanel.SetActive(false);
            imagePanel.SetActive(false);

            // Show the video panel
            videoPanel.SetActive(true);
            currentPanel = 0;

            // Reset the scrollbar to 0 and enable it
            videoScrollbar.value = 0f;
            scrollbarEnabled = true;
            videoScrollbar.gameObject.SetActive(true);
        }
    }

    public void OnTextButtonClick()
    {
        if (currentPanel != 1)
        {
            currentPanel = 1;
            if (isPlaying)
            {
                // Pause the video and show the text panel
                videoPlayer.Pause();
                isPlaying = false;
                lastPlaybackTime = videoPlayer.time; // save the last playback time
                videoPanel.SetActive(false);
                textPanel.SetActive(true);
                imagePanel.SetActive(false);
                scrollbarEnabled = false;
                videoScrollbar.gameObject.SetActive(false);
            }
            else
            {
                // Show the text panel and hide the video and image panels
                textPanel.SetActive(true);
                videoPanel.SetActive(false);
                imagePanel.SetActive(false);
                scrollbarEnabled = false;
                videoScrollbar.gameObject.SetActive(false);
            }
        }
    }

    public void OnImageButtonClick()
    {
        if (currentPanel != 2)
        {
            if (isPlaying)
            {
                // Pause the video and show the image panel
                videoPlayer.Pause();
                isPlaying = false;
                lastPlaybackTime = videoPlayer.time; // save the last playback time
                videoPanel.SetActive(false);
                textPanel.SetActive(false);
                imagePanel.SetActive(true);
                scrollbarEnabled = false;
                videoScrollbar.gameObject.SetActive(false);
            }
            else
            {
                // Show the image panel and hide the video and text panels
                imagePanel.SetActive(true);
                videoPanel.SetActive(false);
                textPanel.SetActive(false);
                currentPanel = 2;
                scrollbarEnabled = false;
                videoScrollbar.gameObject.SetActive(false);
            }
        }
    }

void Update()
{
    if(currentPanel == 0)
    {
            // Check if the video is playing and if the user presses the "space" key
    if (isPlaying && Input.GetKeyDown(KeyCode.Space))
    {
        // Pause the video
        videoPlayer.Pause();
        isPlaying = false;
        lastPlaybackTime = videoPlayer.time; // save the last playback time

        // Hide the scrollbar in the video panel
        var scrollbar = videoPanel.GetComponentInChildren<Scrollbar>();
        if (scrollbar != null)
        {
            scrollbar.gameObject.SetActive(false);
        }
    }
    // Check if the video is paused and if the user presses the "space" key
    else if (!isPlaying && Input.GetKeyDown(KeyCode.Space))
    {
        if (currentPanel == 0)
        {
            videoPlayer.time = lastPlaybackTime;

            // Resume playing the video
            videoPlayer.Play();
            isPlaying = true;

            // Show the scrollbar in the video panel
            var scrollbar = videoPanel.GetComponentInChildren<Scrollbar>();
            if (scrollbar != null)
            {
                scrollbar.gameObject.SetActive(true);
                scrollbar.value = 0f;
            }
        }
        else
        {
            // Resume playing the video from the beginning
            videoPlayer.time = 0f;
            videoPlayer.Play();
            isPlaying = true;

            // Hide the scrollbar in the video panel
            var scrollbar = videoPanel.GetComponentInChildren<Scrollbar>();
            if (scrollbar != null)
            {
                scrollbar.gameObject.SetActive(false);
            }
        }
        currentPanel = 0;
    }
    }
    }
}