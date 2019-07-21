using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringMushroom : MonoBehaviour
{

    public float pump_force = 20f;

    public AudioSource sound;
    void Start()
    {
        sound = WoodieStat.instance.player.transform.Find("Sounds").Find("SpringSound").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Woodie")
        {

            sound.Play();
            other.GetComponent<Rigidbody>().velocity = other.transform.up.normalized * pump_force;
            Destroy(this.gameObject);
        }
    }

}
