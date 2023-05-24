using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    public float speed = 5f; // Скорость движения

    private Rigidbody2D rb; // Ссылка на компонент Rigidbody

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Получаем ссылку на компонент Rigidbody
    }

    private void Update()
    {
        // Получаем ввод по горизонтали и вертикали
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Создаем вектор движения
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        // Применяем силу к Rigidbody для движения
        rb.velocity = movement * speed;
    }
}
