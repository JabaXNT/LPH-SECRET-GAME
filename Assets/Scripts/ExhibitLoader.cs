using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class ExhibitLoader : MonoBehaviour
{
    public Text exhibitText;
    public VideoPlayer exhibitVideo;

    private ExhibitData exhibitData;

    void Start()
    {
        // Get the current exhibit data from the ExhibitData static variable
        exhibitData = ExhibitData.currentExhibit;
        Debug.Log(exhibitData.videoPath);
        // Set the video clip of the video player object to the video for the current exhibit
        exhibitVideo.url = Application.dataPath + "/" + exhibitData.videoPath + ".mp4";
        exhibitText.text = exhibitData.textContent;
        exhibitVideo.Play();
    }
}
