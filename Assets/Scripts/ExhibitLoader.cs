using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class ExhibitLoader : MonoBehaviour
{
    public Text exhibitText;
    public VideoPlayer exhibitVideo;
    public Button exhibitGameButton;
    public Button exhibitTestButton;
    public Image exhibitImagePanel;
    private ExhibitData exhibitData;

    void Start()
    {
        exhibitData = ExhibitData.currentExhibit;
        exhibitVideo.url = Application.dataPath + "/" + exhibitData.videoPath + ".mp4";
        exhibitText.text = exhibitData.textContent;
        // Load the image from a file
        Texture2D texture = LoadImageFromFile(exhibitData.imageContent);

        // Create a new Sprite object and assign the texture to it
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);

        // Set the sprite to the Image component
        exhibitImagePanel.sprite = sprite;

        exhibitVideo.Play();
        exhibitGameButton.onClick.AddListener(LoadGameScene);
        exhibitTestButton.onClick.AddListener(LoadTestScene);
    }

    Texture2D LoadImageFromFile(string path)
    {
        byte[] bytes = System.IO.File.ReadAllBytes(path);
        Texture2D texture = new Texture2D(2, 2);
        texture.LoadImage(bytes);
        return texture;
    }

    void LoadGameScene()
    {
        SceneManager.LoadScene(exhibitData.gameScene);
    }

    void LoadTestScene()
    {
        SceneManager.LoadScene("TestScene");
    }
}
