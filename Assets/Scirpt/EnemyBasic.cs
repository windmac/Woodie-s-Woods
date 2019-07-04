using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasic : MonoBehaviour
{
    public int health = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health<=0)
        {
            Destroy(this.gameObject);
        }
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.transform.name);
        if (collision.transform.tag == "Axe")
        { health--; }
    }*/
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.transform.tag == "Axe")
        {
            Debug.Log(this.transform.name + " Damaged");
            health--;
        }
    }


}
