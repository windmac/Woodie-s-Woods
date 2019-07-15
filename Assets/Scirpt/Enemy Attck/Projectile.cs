using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10f;
    public Vector3 direction = Vector3.forward;
    // public float projectile_existing_time = 3f;
    public bool friend_or_enemy = false;
    public int damage = 1;
<<<<<<< HEAD
    public float attack_force =8f;
    public float rotate_speed = 500f;
=======
    public float attack_force =1000f;
>>>>>>> parent of 54e2db03... Mission

    void Start()
    {
       // Destroy(this.gameObject, projectile_existing_time);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }


    void OnTriggerEnter(Collider other)
    {
        Vector3 attack_vec = (other.transform.position - this.transform.position).normalized;
        attack_vec = new Vector3(attack_vec.x, 0, attack_vec.y);
        if (other.transform.tag == "Woodie"&& friend_or_enemy==false)
        {

           // other.GetComponent<Rigidbody>().AddForce(attack_vec * attack_force , ForceMode.VelocityChange);
            other.GetComponent<Rigidbody>().velocity = attack_vec * attack_force;
            WoodieStat.instance.takeDamage(damage);
            Debug.Log("Woodie Damaged " + damage);
            //    Debug.Log("Ouach");
            //    Debug.Log(attack_vec);
        }



        if (other.transform.tag == "Enemy" && friend_or_enemy == true)
        {

           // other.GetComponent<Rigidbody>().AddForce(attack_vec * attack_force, ForceMode.VelocityChange);
            other.GetComponent<Rigidbody>().velocity = attack_vec * attack_force;
            other.GetComponent<EnemyStat>().takeDamage(damage);
            //WoodieStat.instance.takeDamage(damage);
            Debug.Log("Enemy Damaged "+damage);
            // Debug.Log(attack_vec);
        }

        if (other.transform.tag == "Axe")
        {
            Destroy(this.gameObject);
        }
    }
}
