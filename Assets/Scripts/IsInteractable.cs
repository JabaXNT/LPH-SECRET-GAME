using UnityEngine;
using UnityEngine.SceneManagement;

public class IsInteractable : MonoBehaviour
{
    public KeyCode interactionKey = KeyCode.E;
    public float interactionRadius = 1f;
    public string targetSceneName;

    private void Update()
    {
        if (Input.GetKeyDown(interactionKey))
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, interactionRadius);

            foreach (Collider2D collider in colliders)
            {
                if (collider.CompareTag("Player"))
                {
                    // Если обнаружена коллизия с тайлом двери
                    // Выполните код для перемещения в другую локацию
                    SceneManager.LoadScene(targetSceneName);
                    break;
                }
            }
        }
    }
}
