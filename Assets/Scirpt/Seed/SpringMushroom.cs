using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringMushroom : MonoBehaviour
{

    public float pump_force = 20f;
  


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Woodie")
        {
            Debug.Log("Springed");

            //  other.GetComponent<Rigidbody>().AddForce(other.transform.up.normalized * pump_force , ForceMode.VelocityChange);
            other.GetComponent<Rigidbody>().velocity = other.transform.up.normalized * pump_force;

            //other.GetComponent<Rigidbody>().AddForce(other.transform.up * 8f*Time.fixedDeltaTime, ForceMode.Impulse);
            //GetComponentInParent<EnemyStat>().takeDamage(damage);
            Destroy(this.gameObject);
        }
    }

}
