using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watering : MonoBehaviour
{
    // Start is called before the first frame update

    public bool watering = false;
    private PlayerController2 pc;
    public float stop_time = 0.1f;
    void Start()
    {
        pc = gameObject.GetComponentInParent(typeof(PlayerController2)) as PlayerController2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)&& pc.IsGrounded())
        {

            StartCoroutine(Coroutine());
            
        }
    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.transform.tag == "Seed"&&watering==true)
        {
           Seed seed = collider.gameObject.GetComponent<Seed>();
            if(seed != null)
            {
                seed.growth();
            }
        }
    }

    IEnumerator Coroutine()
    {
        watering = true;
   
        pc.canMove = false;
        yield return new WaitForSeconds(stop_time);

        watering = false;
        pc.canMove = true;
        //  Debug.Log("Stop Watering");
    }



}
