using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watering : MonoBehaviour
{
    // Start is called before the first frame update

    public bool watering = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
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
        Debug.Log("Watering");
        yield return new WaitForSeconds(0.5f);
        watering = false;
        Debug.Log("Stop Watering");
    }



}
