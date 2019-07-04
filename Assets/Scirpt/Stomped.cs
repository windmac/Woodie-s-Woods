using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stomped : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("Stomped" + other.tag);

        if (other.tag == "Woodie")
        {
            Debug.Log("Springed");
        
            other.GetComponent<Rigidbody>().AddRelativeForce(other.transform.up * 1000f * Time.fixedDeltaTime, ForceMode.Impulse);
            //other.GetComponent<Rigidbody>().AddForce(other.transform.up * 8f*Time.fixedDeltaTime, ForceMode.Impulse);
            GetComponentInParent<EnemyBasic>().health = -2;
        }
    }
}
