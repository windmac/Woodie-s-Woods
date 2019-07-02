using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{


    public bool isGrounded;
    public bool isCrouching;

    private float speed = 0;
    private float w_speed = 0.05f;
    private float c_speed = 0.025f;
    public float rotSpeed;
    public float jumpHeight;

    Rigidbody rb;
    // Animator anim;
    BoxCollider collider;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //      anim = GetComponent<Animator>();
        collider = GetComponent<BoxCollider>();
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        //触发蹲下 按下z
      /*  if (Input.GetKeyDown(KeyCode.Z))
        {
            if (isCrouching)
            {
                isCrouching = false;
                //anim.SetBool("isCrouching",false);
                collider.center = new Vector3(0, 1, 0);
                // collider.size.Set(collider.size.x, collider.size.y / 2, collider.size.z);
               // collider.size = new Vector3(1, 1.5f, 1);
                
            }
            else
            {
                isCrouching = true;
                //anim.SetBool("isCrouching",false);
                collider.center = new Vector3(0, 0.5f, 0);
                // collider.size.Set(collider.size.x, collider.size.y * 2, collider.size.z);
               // collider.size = new Vector3(1, 3, 1);
            }
        }*/

        var y = Input.GetAxis("Vertical") * speed;
        var x = Input.GetAxis("Horizontal") * speed;

        transform.Translate(new Vector3(x, 0, y),Space.World);
        

        Vector3 movement = new Vector3(x, 0.0f, y);
        transform.rotation = Quaternion.LookRotation(movement);
        //transform.Translate(0, 0, z);
        //transform.Rotate(0, y, 0);

        //跳跃 x触发
        if (Input.GetKey(KeyCode.X) )
        {

            rb.AddForce(0, jumpHeight, 0);
            //anim.SetTrigger("isJumping");
            isCrouching = false;
            isGrounded = false;

        }

        if (isCrouching)
        {
            speed = c_speed;
        }
        else if (!isCrouching)
        {
            speed = w_speed;

            //以下放动画控制
        }


    }

    void OnCollisionEnter()
    {
        isGrounded = true;
    }
}
