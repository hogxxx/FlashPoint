using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    // Массив точек для патрулирования
    public Transform[] patrolPoints;
    public float speed = 2f;

    // Поле зрения
    public float visionRange = 5f;
    public float visionAngle = 45f; // Угол зрения (в градусах)
    public LayerMask playerLayer;

    private int currentPointIndex = 0;
    private Transform player;

    public GameObject buttle;



    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        Patrol();
        CheckPlayerInSight();

    }

    // Патрулирование между точками
    void Patrol()
    {
        if (patrolPoints.Length == 0)
            return;

        Transform targetPoint = patrolPoints[currentPointIndex];

        // Двигаемся к следующей точке
        transform.position = Vector2.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);

        // Проверяем, достиг ли дрон текущей точки
        if (Vector2.Distance(transform.position, targetPoint.position) < 0.1f)
        {
            currentPointIndex = (currentPointIndex + 1) % patrolPoints.Length; // Переход к следующей точке
        }

        // Разворот в зависимости от направления
        HandleRotation(targetPoint);
    }

    // Метод для поворота дрона во всех направлениях
    void HandleRotation(Transform targetPoint)
    {
        // Вычисляем направление движения
        Vector2 direction = (targetPoint.position - transform.position).normalized;

        // Устанавливаем угол поворота в зависимости от направления
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Поворачиваем дрон к цели
        
        transform.localRotation = Quaternion.Euler(0, 0, angle);
    }

    // Проверка нахождения игрока в поле зрения
    void CheckPlayerInSight()
    {
        if (player == null)
        {
            return;
        }
            

        Vector2 directionToPlayer = (player.position - transform.position).normalized;
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Проверяем, находится ли игрок в пределах поля зрения и на заданном расстоянии
        if (distanceToPlayer < visionRange)
        {
            float angleToPlayer = Vector2.Angle(GetFacingDirection(), directionToPlayer);
            // Если игрок находится в пределах угла зрения
            if (angleToPlayer < visionAngle / 2)
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToPlayer, visionRange, playerLayer);
                if (hit.collider != null && hit.collider.CompareTag("Player"))
                {
                    EndGame(); // Завершение игры
                }
            }
        }
    }

    // Получение текущего направления движения (право/лево/вверх/вниз)
    Vector2 GetFacingDirection()
    {
        return transform.right; // Теперь дрон смотрит в сторону, куда "смотрит" его передняя часть
    }

    // Завершение игры, если игрок попал в поле зрения
    void EndGame()
    {
        Debug.Log("Игра окончена. Дрон заметил игрока!");
        buttle.SetActive(true);
        Invoke("Fog", (1f / 5f));
    }
    void Fog()
    {
        buttle.SetActive(false);
    }
    // Для визуализации поля зрения в редакторе Unity
    private void OnDrawGizmosSelected()
    {
        // Отрисовка радиуса поля зрения
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, visionRange);

        // Отрисовка угла зрения (конуса)
        Gizmos.color = Color.yellow;
        Vector3 leftBoundary = Quaternion.Euler(0, 0, visionAngle / 2) * GetFacingDirection();
        Vector3 rightBoundary = Quaternion.Euler(0, 0, -visionAngle / 2) * GetFacingDirection();
        Gizmos.DrawLine(transform.position, transform.position + leftBoundary * visionRange);
        Gizmos.DrawLine(transform.position, transform.position + rightBoundary * visionRange);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bullet"))
        {
            int points = MyClass.point;
            MyClass.pointRedact(points + 1);
            Destroy(gameObject);
        }

    }
}