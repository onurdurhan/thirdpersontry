using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    private Health health;
    private Animator anim;


    //Patrolling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking 
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    [SerializeField] private Transform pfBulletProjectile;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        player = GameObject.Find("Soldier").transform;
        agent = GetComponent<NavMeshAgent>();
        health = GetComponent<Health>();
        anim = GetComponent<Animator>();

    }

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        if (!playerInSightRange && !playerInSightRange) Patrolling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();
        if (GetComponent<Rigidbody>().velocity.magnitude > 10f) anim.SetBool("isRunning", true);
        else anim.SetBool("isRunning", false);
        //Debug.Log(GetComponent<Rigidbody>().acceleration.magnitude);

    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range 
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void Patrolling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);
        
        
        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        //WalkPoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;

    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        
    }
    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            ////Attack Code here

            Rigidbody rb = Instantiate(pfBulletProjectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 8f, ForceMode.Impulse);

            ///
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }

    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    private void TakeDamage(float damage)
    {
        health.Damage(damage);
        Debug.Log("Curent Health"+health.m_CurrentHealth);

        if (health.m_CurrentHealth <= 0) {
            anim.SetBool("isDead", true);
            Invoke(nameof(DestroyEnemy), 1.5f);
        }
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("");
        if (collision.gameObject.tag=="dost_kursunu")
        {
            Debug.Log("Delivering damage");
            TakeDamage(10f);
        }
    }

}
