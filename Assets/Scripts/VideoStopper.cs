using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoStopper : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public Button stopButton;
    private double videoTime;
    private bool isPlaying = true;
    private double lastPlaybackTime;

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
            isPlaying = true;
            // Hide the stop button
            stopButton.gameObject.SetActive(false);
        }
        else
        {
            isPlaying = false;
            // Show the stop button
            stopButton.gameObject.SetActive(true);
        }
    }

    public void StopVideo()
    {
        videoTime = 0;
        videoPlayer.Pause();

        // Hide the stop button
        stopButton.gameObject.SetActive(false);
        
        lastPlaybackTime = videoPlayer.time; // save the last playback time
    }

    public void PlayVideo()
    {
        // Set the video time to the last playback time and play the video
        videoPlayer.time = lastPlaybackTime;
        videoPlayer.Play();
        isPlaying = true;

        // Hide the stop button
        stopButton.gameObject.SetActive(false);
    }

    public bool IsPlaying()
    {
        return isPlaying;
    }

    public double GetVideoTime()
    {
        return videoTime;
    }
}
