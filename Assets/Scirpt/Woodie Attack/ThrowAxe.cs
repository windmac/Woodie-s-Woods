using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowAxe : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject axe_projectile;
    private PlayerController2 pc;
    public float stop_time = 0.1f;

    void Start()
    {
        pc  = gameObject.GetComponentInParent(typeof(PlayerController2)) as PlayerController2;
    }

    // Update is called once per frame
    void Update()
    {
        //调整
       
        float x = transform.position.x;
        float y = transform.position.y;
        float z = transform.position.z;

        //扔斧头
        if (Input.GetKeyDown(KeyCode.F)&&GameObject.FindGameObjectsWithTag("Axe").Length == 0)
        {

            if(pc.IsGrounded())
            {
                StartCoroutine(Coroutine());
            }
            
                GameObject clone;
                clone = Instantiate(axe_projectile, new Vector3(x, y + 0.5f, z), transform.rotation) as GameObject;

        }
    }

    IEnumerator Coroutine()
    {
        pc.canMove = false;
        yield return new WaitForSeconds(stop_time);
        pc.canMove = true;
  
    }
}
