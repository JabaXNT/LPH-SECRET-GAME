using UnityEngine;
using UnityEngine.SceneManagement;

public class ExhibitObject : MonoBehaviour
{
    public float interactionDistance = 2f; // the distance at which the player can interact with the object
    public string exhibitName = "Default Exhibit"; // the name of the exhibit to be shown in the exhibit scene
    public string videoPath = "Videos/lectureMaterial"; // the path to the video to be shown in the exhibit scene
    public string textContent = "Default text content"; // the text content to be shown in the exhibit scene
    public string imageContent = "Assets/Sprites/logo.png"; // the image content to be shown in the exhibit scene
    public string testPath = "test1"; // the text content to be shown in the exhibit scene
    public string gameScene = "Assets/Scenes/Pascalina"; // the game scene to be shown

    private bool canInteract = false; // flag to indicate whether the player is within interaction distance
    private Collider2D otherCollider; // reference to the collider of the other object

    void Update()
    {
        // check if the player is within interaction distance and pressed the E button
        if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
            // set the exhibit data to be passed to the next scene
            ExhibitData exhibitData = new ExhibitData(exhibitName, videoPath, textContent, testPath, gameScene, imageContent);
            ExhibitData.currentExhibit = exhibitData;

            // load the new scene
            SceneManager.LoadScene("ExhibitScene");
        }
    }

    // called when the player enters the collider area
    void OnCollisionEnter2D(Collision2D other)
    {
        // check if the other object is the player
        if (other.gameObject.CompareTag("Player"))
        {
            // set the canInteract flag to true
            canInteract = true;
            otherCollider = other.collider;
        }
    }

    // called when the player exits the collider area
    void OnCollisionExit2D(Collision2D other)
    {
        // check if the other object is the player
        if (other.collider == otherCollider)
        {
            // set the canInteract flag to false
            canInteract = false;
            otherCollider = null;
        }
    }
}

public class ExhibitData
{
    public static ExhibitData currentExhibit;

    public string exhibitName;
    public string videoPath;
    public string textContent;
    public string testPath;
    public string gameScene;
    public string imageContent;

    public ExhibitData(string exhibitName, string videoPath, string textContent, string testPath, string gameScene, string imageContent)
    {
        this.exhibitName = exhibitName;
        this.testPath = testPath;
        this.videoPath = videoPath;
        this.textContent = textContent;
        this.gameScene = gameScene;
        this.imageContent = imageContent;
    }
}
