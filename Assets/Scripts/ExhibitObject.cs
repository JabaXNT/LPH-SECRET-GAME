using UnityEngine;
using UnityEngine.SceneManagement;

public class ExhibitObject : MonoBehaviour
{
    public float interactionDistance = 2f; // the distance at which the player can interact with the object

    private bool canInteract = false; // flag to indicate whether the player is within interaction distance
    private Collider2D otherCollider; // reference to the collider of the other object

    void Update()
    {
        // check if the player is within interaction distance and pressed the E button
        if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
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