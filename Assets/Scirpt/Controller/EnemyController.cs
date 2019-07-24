using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour
{
    public float lookRadius = 5f;

    public Transform target;
    NavMeshAgent agent;
    public float target_facing_rotationSpeed = 10f;
    public Sensation sensation;
    public Attack attack;
    private Vector3 origin_position;
    public Animator anim;
    

    [Header("Patrol Settings")]
    [SerializeField] Vector3 patrolOffset = new Vector3(5f, 0f, 0f);

    Vector3 startPos;
    Vector3 patrolPos;
    Vector3 currentTarget;
    bool isAttacking = false;

    // Start is called before the first frame update
    void Start()
    {
        //initialize patrol target
        startPos = transform.position;
        patrolPos = startPos + patrolOffset;
        currentTarget = patrolPos;
        print(startPos + " " + patrolPos);


        if (this.tag=="Enemy")
        {
            target = PlayerManager.instance.player.transform;
        }

        agent = GetComponent<NavMeshAgent>();
        origin_position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAttacking)
        {            
            Patrol();
        }
       
        float distance = 999999999999;
        target = sensation.target;



        if (target != null)
        {
            distance = Vector3.Distance(target.position, transform.position);
        }
        

        if(distance<=lookRadius)
        {
            agent.SetDestination(target.position);
            isAttacking = true;

            if(anim!=null)
            {
                if(agent.isStopped)
                {
                    anim.SetBool("isMoving", false);
                }
                else
                {
                    anim.SetBool("isMoving", true);
                }
                
            }

            if(distance<= agent.stoppingDistance)
            {
                //Attack the target
                //Face the target
                FaceTarget();

                if(attack!= null)
                {
                    attack.attack(target);
                }
                
            }

        }
        else
        {
            //if(agent.remainingDistance<=0.1f)
            //{
                //Debug.Log("Agent Stop");
            //   agent.SetDestination(origin_position);
            //}
           
            if (attack != null)
            {
                attack.stopAttack();
            }
            
        }
    }

    private void Patrol()
    {
        if (Vector3.Distance(transform.position, startPos) < 1f)
        {
            currentTarget = patrolPos;

        }
        if (Vector3.Distance(transform.position, patrolPos) < 1f)
        {
            currentTarget = startPos;
        }
        agent.SetDestination(currentTarget);
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * target_facing_rotationSpeed);

      

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
