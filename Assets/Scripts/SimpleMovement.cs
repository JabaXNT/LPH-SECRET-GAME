using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    public float speed = 5f; // Скорость движения

    private Rigidbody2D rb; // Ссылка на компонент Rigidbody
    private Animator animator; // Ссылка на компонент Animator
    private SpriteRenderer spriteRenderer; // Ссылка на компонент SpriteRenderer

    private bool canRotate = true; // Флаг для разрешения поворота

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Получаем ссылку на компонент Rigidbody
        animator = GetComponent<Animator>(); // Получаем ссылку на компонент Animator
        spriteRenderer = GetComponent<SpriteRenderer>(); // Получаем ссылку на компонент SpriteRenderer
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

        // Устанавливаем параметр "IsMoving" в аниматоре в зависимости от движения
        bool isMoving = movement.magnitude > 0;
        animator.SetBool("IsMoving", isMoving);

        // Изменяем направление спрайта, если движение влево
        if (moveHorizontal < 0)
        {
            spriteRenderer.flipX = true;
            canRotate = false; // Запрещаем поворот, если движение влево
        }
        // Изменяем направление спрайта, если движение вправо
        else if (moveHorizontal > 0)
        {
            spriteRenderer.flipX = false;
            canRotate = false; // Запрещаем поворот, если движение вправо
        }
        else
        {
            canRotate = true; // Разрешаем поворот в остальных случаях
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (canRotate)
        {
            // Запрещаем поворот при коллизии с объектом
            rb.freezeRotation = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (canRotate)
        {
            // Разрешаем поворот после выхода из коллизии с объектом
            rb.freezeRotation = false;
        }
    }
}
