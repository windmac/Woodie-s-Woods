using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringMushroom : MonoBehaviour
{

    public float pump_force = 3000f;
  


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Woodie")
        {
            Debug.Log("Springed");

            other.GetComponent<Rigidbody>().AddForce(other.transform.up.normalized * pump_force * Time.fixedDeltaTime, ForceMode.Impulse);
            //other.GetComponent<Rigidbody>().AddForce(other.transform.up * 8f*Time.fixedDeltaTime, ForceMode.Impulse);
            //GetComponentInParent<EnemyStat>().takeDamage(damage);
            Destroy(this.gameObject);
        }
    }

}
