using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStat : MonoBehaviour
{
    public int max_health = 2;
    public int current_health { get; private set; }

    public GameObject enemy;

    public GameObject drop;

    void Awake()
    {
        current_health = max_health;
    }


    /*private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.transform.name);
        if (collision.transform.tag == "Axe")
        { health--; }
    }*/
    private void OnTriggerEnter(Collider other)
    {
       

    }

    public void takeDamage(int damage)
    {
        current_health -= damage;
        Debug.Log(enemy.name + "takes " + damage + " damage");

        //If health belows 0, then die
        if (current_health <= 0)
        {
            die();
        }

    }

    public void die()
    {
        Debug.Log(enemy.name + " Die");
        if(drop!=null)
        {
            GameObject clone = Instantiate(drop, transform.position, transform.rotation) as GameObject;
            clone.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            //  = Instantiate(drop, new Vector3(x, y + 0.2f, z), transform.rotation) as GameObject;
            Debug.Log("Drop" + clone.name);
        }
        Destroy(enemy.gameObject);
    }
}
