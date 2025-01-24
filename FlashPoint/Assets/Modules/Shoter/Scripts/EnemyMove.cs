using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
  
    public Transform[] patrolPoints;
    public float speed = 2f;

    
    public float visionRange = 5f;
    public float visionAngle = 45f; 
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

    void Patrol()
    {
        if (patrolPoints.Length == 0)
            return;

        Transform targetPoint = patrolPoints[currentPointIndex];

      
        transform.position = Vector2.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);

     
        if (Vector2.Distance(transform.position, targetPoint.position) < 0.1f)
        {
            currentPointIndex = (currentPointIndex + 1) % patrolPoints.Length; 
        }

        
        HandleRotation(targetPoint);
    }

  
    void HandleRotation(Transform targetPoint)
    {
        
        Vector2 direction = (targetPoint.position - transform.position).normalized;

        
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        
        
        transform.localRotation = Quaternion.Euler(0, 0, angle);
    }

   
    void CheckPlayerInSight()
    {
        if (player == null)
        {
            return;
        }
            

        Vector2 directionToPlayer = (player.position - transform.position).normalized;
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

       
        if (distanceToPlayer < visionRange)
        {
            float angleToPlayer = Vector2.Angle(GetFacingDirection(), directionToPlayer);
           
            if (angleToPlayer < visionAngle / 2)
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToPlayer, visionRange, playerLayer);
                if (hit.collider != null && hit.collider.CompareTag("Player"))
                {
                    EndGame(); 
                }
            }
        }
    }

  
    Vector2 GetFacingDirection()
    {
        return transform.right; 
    }

 
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
 
    private void OnDrawGizmosSelected()
    {
  
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, visionRange);

    
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