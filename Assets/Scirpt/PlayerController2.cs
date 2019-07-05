using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{


    //public bool isGrounded;
    public bool isCrouching;
    public LayerMask groundLayers;
    public bool canMove = true;

    private float speed = 5f;
    private float w_speed = 5f;
    private float c_speed = 2.5f;
    private float rotation_speed = 5f;
    public float rotSpeed;
    public float jumpHeight = 1f;

    Rigidbody rb;
    // Animator anim;
    CapsuleCollider collider;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //      anim = GetComponent<Animator>();
        collider = GetComponent<CapsuleCollider>();
       // isGrounded = true;
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

        playerMovement();
       
        
        //transform.Translate(0, 0, z);
        //transform.Rotate(0, y, 0);

        //跳跃 x触发
        if ((Input.GetKey(KeyCode.X)|| Input.GetKey(KeyCode.Space)) && IsGrounded() == true)
        {

            rb.AddForce(Vector3.up*jumpHeight,ForceMode.Impulse);
            //anim.SetTrigger("isJumping");
            isCrouching = false;
            //isGrounded = false;
            Debug.Log("Jump");

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
    void FixedUpdate()
    {
        //修改重力
        rb.AddForce(Physics.gravity * rb.mass* rb.mass);
    }


    void playerMovement()
    {
        float vertical = 0;
        float horizontal = 0;

        if (canMove)
        {
             vertical = Input.GetAxisRaw("Vertical");
             horizontal = Input.GetAxisRaw("Horizontal");
        }



        Vector3 movement = new Vector3(horizontal, 0f, vertical) * speed * Time.deltaTime;

        transform.Translate(movement, Space.World);


         if(movement.sqrMagnitude>0.00003)
         {
            

            transform.rotation = Quaternion.Slerp(
                                                    transform.rotation,
                                                    Quaternion.LookRotation(movement),
                                                    Time.deltaTime * rotation_speed);
        }




    }



    void OnCollisionEnter()
    {
       // isGrounded = true;
    }

    public bool IsGrounded()
    {
        return Physics.CheckCapsule(collider.bounds.center,
                             new Vector3(collider.bounds.center.x,
                                         collider.bounds.min.y,
                                         collider.bounds.center.z),
                             collider.radius * 0.9f,groundLayers);
        
    }
}
