using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class BotEnemy : MonoBehaviour {

    public float lookRadius = 2f;
    public float attackRange = 1f;

    [SerializeField]
    Transform Player;

    NavMeshAgent _agent;
    Animator anim;

    // Use this for initialization
    void Start () {
        _agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        
    }
    
    // Update is called once per frame
    private void Update() {
        // Get the distance to the player
        float distance = Vector3.Distance(Player.position, transform.position);
        if (distance >= lookRadius)
            anim.SetBool("Walk", false);
        // If inside the radius
        if (distance <= lookRadius)
        {
            // Move towards the player
            SetDestination();

            //agent.destination = playercupu.position;
            anim.SetBool("Walk", true);

            if (distance <= attackRange)
            {
                anim.SetBool("Walk", false);
                anim.SetBool("Attack", true);
            }
            else anim.SetBool("Attack", false);

            if (distance <= _agent.stoppingDistance)
            {
                // Attack
                FaceTarget();
            }
        }
    }

    private void SetDestination()
    {
        if(Player != null)
        {
            Vector3 playerVektor = Player.transform.position;
            _agent.SetDestination(playerVektor);
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (Player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
