using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Ссылка на трансформ игрока

    private void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
    }
}
