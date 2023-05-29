using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChapterSummaryObject : MonoBehaviour
{
    public float interactionDistance = 2f; // the distance at which the player can interact with the object
    public string ChapterName = "Default Exhibit"; // the name of the exhibit to be shown in the exhibit scene
    public string textContent = "Default text content"; // the text content to be shown in the exhibit scene
    public string imageContent = "Assets/Sprites/logo.png"; // the image content to be shown in the exhibit scene
    public string testPath = "test1"; // the text content to be shown in the exhibit scene
    public ExhibitData VideoScene1; // the game scene to be shown
    public ExhibitData VideoScene2; // the game scene to be shown
    private bool canInteract = false; // flag to indicate whether the player is within interaction distance
    private Collider2D otherCollider; // reference to the collider of the other object

    void Update()
    {
        // check if the player is within interaction distance and pressed the E button
        if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
            // set the exhibit data to be passed to the next scene
            SummaryData objectData = new SummaryData(ChapterName, textContent, imageContent, testPath, VideoScene1, VideoScene2);
            SummaryData.currentChapter = objectData;

            // load the new scene
            SceneManager.LoadScene("ToBeOrNotToBeScene");
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

public class SummaryData
{
    public static SummaryData currentChapter;

    public string objectName;
    public string videoPath;
    public string textContent;
    public string testPath;
    public ExhibitData videoScene1;
    public ExhibitData videoScene2;

    public SummaryData(string ChapterName, string videoPath, string textContent, string testPath, ExhibitData VideoScene1, ExhibitData VideoScene2)
    {
        this.objectName = ChapterName;
        this.testPath = testPath;
        this.textContent = textContent;
        this.videoScene1 = VideoScene1;
        this.videoScene2 = VideoScene2;
    }
}

