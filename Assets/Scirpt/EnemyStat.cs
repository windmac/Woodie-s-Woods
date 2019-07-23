﻿using System.Collections;
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
            Instantiate(drop, this.transform);
        }
        Destroy(enemy.gameObject);
    }
}
