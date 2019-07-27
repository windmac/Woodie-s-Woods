using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watering : MonoBehaviour
{
    // Start is called before the first frame update

    public bool watering = false;
    private PlayerController2 pc;
    public float stop_time = 0.1f;
    public AudioSource sound;

    public Animator animator;
    void Start()
    {
        pc = gameObject.GetComponentInParent(typeof(PlayerController2)) as PlayerController2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J)&& pc.IsGrounded()&&pc.canMove)
        {
            animator.SetTrigger("Nock");
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
        if (collider.transform.tag == "Bridge Seed" && watering == true)
        {
            BridgeSeed seed = collider.gameObject.GetComponent<BridgeSeed>();
            if (seed != null)
            {
                seed.growth();
            }
        }

    }

    IEnumerator Coroutine()
    {
        watering = true;
        sound.Play();
        pc.canMove = false;
        yield return new WaitForSeconds(stop_time);
       // sound.Stop();
        watering = false;
        pc.canMove = true;
    }



}
