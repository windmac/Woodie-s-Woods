using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stomped : MonoBehaviour
{
    // Start is called before the first frame update

    public float pump_force = 10f;
    public int damage = 2;
    //public GameObject enemy;
    public AudioSource sound;
    
    void Start()
    {
        sound =  WoodieStat.instance.player.transform.Find("Sounds").Find("StompedSound").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

      //  Debug.Log("Stomped" + other.tag);

        if (other.tag == "Woodie")
        {
           // Debug.Log("Springed");
            sound.Play();
            other.GetComponent<Rigidbody>().velocity = other.transform.up.normalized * pump_force;
            GetComponentInParent<EnemyStat>().takeDamage(damage) ;
            
        }
    }
}
