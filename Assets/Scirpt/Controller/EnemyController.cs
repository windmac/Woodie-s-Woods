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

    public Attack attack;

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = 999999999999;
        if (target != null)
        {
            distance = Vector3.Distance(target.position, transform.position);
        }
        

        if(distance<=lookRadius)
        {
            agent.SetDestination(target.position);

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
            if (attack != null)
            {
                attack.stopAttack();
            }
            
        }
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
