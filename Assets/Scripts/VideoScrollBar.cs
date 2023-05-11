using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoScrollBar : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public Scrollbar scrollbar;

    private bool isDraggingScrollbar = false;

    void Start()
    {
        scrollbar.interactable = true;
        scrollbar.handleRect.gameObject.SetActive(true);

        // Set the scrollbar's maximum value to the number of frames in the video
        scrollbar.numberOfSteps = (int)videoPlayer.frameCount;
        scrollbar.value = 0;
    }

    void Update()
    {
        if (!isDraggingScrollbar && videoPlayer.frameCount > 0)
        {
            scrollbar.value = (float)(videoPlayer.frame + 0.11) / (float)videoPlayer.frameCount;
        }
    }

    public void OnScrollbarValueChanged()
    {
        if (isDraggingScrollbar)
        {
            // Set the video's current frame based on the scrollbar's value
            videoPlayer.frame = (long)(scrollbar.value * videoPlayer.frameCount);
        }
    }

    public void OnScrollbarBeginDrag()
    {
        isDraggingScrollbar = true;
        videoPlayer.Pause();
    }

    public void OnScrollbarEndDrag()
    {
        isDraggingScrollbar = false;
        videoPlayer.Play();
    }
}
