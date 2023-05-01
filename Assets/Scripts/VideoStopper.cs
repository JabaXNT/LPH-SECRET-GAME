using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoStopper : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public Button stopButton;

    private double videoTime;

    private void Start()
    {
        // Hide the stop button by default
        stopButton.gameObject.SetActive(false);
    }

    private void Update()
    {
        videoTime = videoPlayer.time;
        // Check if the video is playing
        if (videoPlayer.isPlaying)
        {
            // Hide the stop button
            stopButton.gameObject.SetActive(false);
        }
        else
        {
            // Show the stop button
            stopButton.gameObject.SetActive(true);
        }
    }

    public void StopVideo()
    {
        videoPlayer.Pause();
        videoPlayer.time = 0;

        // Hide the stop button
        stopButton.gameObject.SetActive(false);
    }

    public void PlayVideo()
    {
        videoPlayer.time = videoTime;
        // Play the video
        videoPlayer.Play();
    }
}
