using UnityEngine;
using UnityEngine.AI;


public enum EnemyType { Melee, Ranged }

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] patrolPoints; // Puntos de patrulla
    private int currentPoint = 0;
    private NavMeshAgent agent; // Controlador de navegación
    public EnemyType enemyType; // Tipo de enemigo
    public GameObject projectilePrefab;

    public Transform player; // Referencia al jugador
    public float detectionRange = 15f; // Rango de detección
    public float attackRange = 2f; // Rango de ataque melee
    public float rangedAttackDistance = 10f; // Distancia para ataques a distancia
    public float visionAngle = 90f; // Ángulo de visión
    public float damage = 10f; // Daño infligido al jugador
    public float attackCooldown = 1.5f; // Tiempo entre ataques creo que esto es innecesario por que el otro parcero hizo algo similar
    private float lastAttackTime;

    public Animator animator; // Control de animaciones

    private bool isPlayerDetected = false;
    private Vector3 startPosition; // Posición inicial para enemigos sin patrulla


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // Configurar posición inicial para enemigos sin patrulla
        if (patrolPoints.Length == 0)
        {
            startPosition = transform.position;
        }
        else
        {
            agent.SetDestination(patrolPoints[currentPoint].position);
        }

        if (animator != null)
        {
            animator.SetBool("isPatrolling", patrolPoints.Length > 0);
        }
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Detectar al jugador
        if (CanSeePlayer())
        {
            isPlayerDetected = true;
        }
        else if (distanceToPlayer > detectionRange)
        {
            isPlayerDetected = false;
        }

        // Lógica de comportamiento
        if (isPlayerDetected)
        {
            EngagePlayer(distanceToPlayer);
        }
        else
        {
            if (patrolPoints.Length > 0)
            {
                Patrol();
            }
            else
            {
                WatchArea(); // Vigilancia para enemigos sin patrulla
            }
        }
    }

    bool CanSeePlayer()
    {
        Vector3 directionToPlayer = player.position - transform.position;
        float angleToPlayer = Vector3.Angle(transform.forward, directionToPlayer);

        if (angleToPlayer <= visionAngle / 2 && Vector3.Distance(transform.position, player.position) <= detectionRange)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, directionToPlayer.normalized, out hit, detectionRange))
            {
                if (hit.transform == player)
                {
                    return true;
                }
            }
        }
        return false;
    }

    void Patrol()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            currentPoint = (currentPoint + 1) % patrolPoints.Length;
            agent.SetDestination(patrolPoints[currentPoint].position);
        }
//<<<<<<< HEAD

        if (animator != null)
        {
            animator.SetBool("isPatrolling", true);
            animator.SetBool("isAttacking", false);
        }
    }

    void WatchArea()
    {
        // Vigilancia para enemigos sin patrulla
        if (!isPlayerDetected)
        {
            transform.Rotate(Vector3.up * Time.deltaTime * 30f); // Rotación lenta mientras vigila
        }

        if (animator != null)
        {
            animator.SetBool("isPatrolling", false);
            animator.SetBool("isAttacking", false);
        }
    }

    void EngagePlayer(float distanceToPlayer)
    {
        if (enemyType == EnemyType.Melee)
        {
            agent.SetDestination(player.position); // Perseguir al jugador

            if (distanceToPlayer <= attackRange && Time.time > lastAttackTime + attackCooldown)
            {
                AttackPlayer();
            }
        }
        else if (enemyType == EnemyType.Ranged)
        {
            if (distanceToPlayer > rangedAttackDistance)
            {
                agent.SetDestination(player.position); // Acercarse si está fuera de rango
            }
            else
            {
                agent.SetDestination(transform.position); // Mantener posición al disparar
                if (Time.time > lastAttackTime + attackCooldown)
                {
                    AttackPlayer();
                }
            }
        }

        if (animator != null)
        {
            animator.SetBool("isPatrolling", false);
            animator.SetBool("isAttacking", true);

        }
    }

    void AttackPlayer()
    {

        lastAttackTime = Time.time;

        if (enemyType == EnemyType.Melee)
        {
            Debug.Log("Melee: Atacando al jugador");
            DealDamageToPlayer();
        }
        else if (enemyType == EnemyType.Ranged)
        {
            Debug.Log("Ranged: Disparando al jugador");
            ShootProjectile();
        }
    }

    void DealDamageToPlayer()
    {
        WeaponManager playerScript = player.GetComponent<WeaponManager>();
        if (playerScript != null)
        {
            playerScript.TakeDamage(damage);
        }
    }

    void ShootProjectile()
    {
        if (projectilePrefab == null) return; 

        // Instanciar el proyectil
        GameObject projectile = Instantiate(projectilePrefab, transform.position + transform.forward * 1.5f, Quaternion.identity);

        // Obtener el Rigidbody del proyectil y lanzarlo hacia el jugador
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            rb.velocity = direction * 10f; // Velocidad del proyectil
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);

        Vector3 leftLimit = Quaternion.Euler(0, -visionAngle / 2, 0) * transform.forward * detectionRange;
        Vector3 rightLimit = Quaternion.Euler(0, visionAngle / 2, 0) * transform.forward * detectionRange;

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + leftLimit);
        Gizmos.DrawLine(transform.position, transform.position + rightLimit);
    }
}