using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactAttack : MonoBehaviour
{

    public float attack_force =900f;
    public int damage = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Vector3 attack_vec = other.transform.position - this.transform.position;
        //attack_vec = attack_vec.normalized;

        if(other.transform.tag=="Woodie")
        {
            
            other.GetComponent<Rigidbody>().AddForce(attack_vec * attack_force * Time.fixedDeltaTime, ForceMode.Impulse);
            WoodieStat.instance.takeDamage(damage);
        }

        if (other.transform.tag == "Friend")
        {

            //other.GetComponent<Rigidbody>().AddForce(attack_vec * attack_force * Time.fixedDeltaTime, ForceMode.Impulse);
           // WoodieStat.instance.takeDamage(damage);
           // other.GetComponent<EnemyStat>().takeDamage(damage);
            other.GetComponent<EnemyStat>().die();
            Debug.Log("Friend damaged");
        }
    }
}
