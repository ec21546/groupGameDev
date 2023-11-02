using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform spawnPoint;
    public float movementSpeed = 1.0f;
    public float maxDistanceFromSpawn = 5.0f;
    public float detectionRadius = 3.0f;
    public bool isAggressive = false;

    private Vector3 initialPosition;
    private Vector3 targetPosition;
    private bool isMoving = true;

    private Transform player;

    void Start()
    {
        initialPosition = spawnPoint.position;
        targetPosition = GetRandomTargetPosition();

        player = GameObject.FindGameObjectWithTag("Player").transform;

        //isAggressive = Random.Range(0, 2) == 0; If we want random aggressiveness 

        isMoving = true;
    }

    void Update()
    {
        if (!isAggressive)
        {
            if (isMoving)
            {
                MoveToTarget();
            }
        }
        else
        {
            ChasePlayer();
        }
    }

    bool IsPlayerNearby()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);
            return distanceToPlayer <= detectionRadius;
        }
        return false;
    }

    void MoveToTarget()
    {
        Vector3 direction = targetPosition - transform.position;
        float distance = direction.magnitude;

        if (distance > 0.1f)
        {
            transform.Translate(direction.normalized * movementSpeed * Time.deltaTime);
        }
        else
        {
            targetPosition = GetRandomTargetPosition();
        }
    }

    void ChasePlayer()
    {
        if (player != null)
        {
            Vector3 direction = player.position - transform.position;
            transform.Translate(direction.normalized * movementSpeed * Time.deltaTime);
        }
    }

    Vector3 GetRandomTargetPosition()
    {
        Vector2 randomPoint = Random.insideUnitCircle * maxDistanceFromSpawn;
        Vector3 targetPosition = initialPosition + new Vector3(randomPoint.x, 0, randomPoint.y);
        targetPosition.y = transform.position.y;
        return targetPosition;
    }
}
