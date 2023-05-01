using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float padding = 0.5f; // adjust this value to add padding around the screen edges
    private float minX, maxX, minY, maxY;

    private void Start()
    {
        // get the bounds of the screen in world space
        Camera cam = Camera.main;
        Vector2 bottomLeft = cam.ViewportToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
        Vector2 topRight = cam.ViewportToWorldPoint(new Vector3(1, 1, cam.nearClipPlane));

        // calculate the limits of the screen with padding
        minX = bottomLeft.x + padding;
        maxX = topRight.x - padding;
        minY = bottomLeft.y + padding;
        maxY = topRight.y - padding;
    }

    private void Update()
    {
        // get the input direction
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // move the player
        Vector3 position = transform.position;
        position.x += horizontal * moveSpeed * Time.deltaTime;
        position.y += vertical * moveSpeed * Time.deltaTime;

        // clamp the position within the screen boundaries
        position.x = Mathf.Clamp(position.x, minX, maxX);
        position.y = Mathf.Clamp(position.y, minY, maxY);

        // set the new position
        transform.position = position;
    }
}
