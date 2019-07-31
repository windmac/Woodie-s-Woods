using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{


    //public bool isGrounded;
    public bool isCrouching;
    public LayerMask groundLayers;
    public bool canMove = true;

    public float speed = 8f;
    private float w_speed = 5f;
    private float c_speed = 2.5f;
    private float rotation_speed = 8f;
    public float rotSpeed;
    public float jumpHeight = 20;
    public Camera cam;
    public AudioSource jump_sound;
   //public AudioSource walking_sound;

    public Animator animator;

    private bool is_walking = false;
    Rigidbody rb;
    // Animator anim;
    CapsuleCollider footCollider;
    BoxCollider collider;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //      anim = GetComponent<Animator>();
        collider = GetComponent<BoxCollider>();
        footCollider = GetComponent<CapsuleCollider>();
        // isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
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




            //跳跃k触发
            if (KeyMappingManager.instance.jump && IsGrounded() == true)
            {

                rb.velocity = Vector3.up * jumpHeight ;
                //anim.SetTrigger("isJumping");
                isCrouching = false;
                //isGrounded = false;
                Debug.Log("Jump");
                jump_sound.Play();
            }

            //蹲着
          /*  if (isCrouching)
            {
                speed = c_speed;
            }
            else if (!isCrouching)
            {
                speed = w_speed;

                //以下放动画控制
            }*/



        }else
        {
            animator.SetBool("isMoving", false);
        }

        if (!IsGrounded())
        {
            if (rb.velocity.y > 0)
            {
                animator.SetBool("isJumping", true);
                animator.SetBool("isFalling", false);
            }
            else
            {
                animator.SetBool("isJumping", false);
                animator.SetBool("isFalling", true);
            }

        }
        else
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", false);
        }

    }
    void FixedUpdate()
    {
        //修改重力

        rb.AddForce(Physics.gravity * rb.mass* rb.mass);
    }


    void playerMovement()
    {
        Vector2 input = Vector2.zero;


            input.y = Input.GetAxisRaw("Vertical");
            input.x = Input.GetAxisRaw("Horizontal");
            input = SquareToCircle(input);


        Vector3 movement = new Vector3(input.x, 0f, input.y) * speed * Time.deltaTime;

        //Movement chase camera angle

        Quaternion cam_rotation =  Quaternion.FromToRotation(new Vector3(0,0,1), new Vector3(cam.transform.forward.x,0, cam.transform.forward.z));
        movement = cam_rotation * movement;

        transform.Translate(movement, Space.World);

        //is Moving
         if(movement.sqrMagnitude>0.00003)
         {


            transform.rotation = Quaternion.Slerp(
                                                    transform.rotation,
                                                    Quaternion.LookRotation(movement),
                                                    Time.deltaTime * rotation_speed);

          /*  if(!walking_sound.isPlaying&&IsGrounded())
            {
                walking_sound.Play();
            }*/


                animator.SetBool("isMoving", true);

            
        }
        else
        {
           // walking_sound.Stop();
            animator.SetBool("isMoving", false);
        }


    }



    void OnCollisionEnter(Collision collision)
    {

        //Pick up object
        if (collision!=null&&collision.collider.tag=="PickUps")
        {
            Debug.Log("Pick");
            collision.collider.GetComponent<ItemPickUp>().PickUp();

        }


    }

    public bool IsGrounded()
    {
        return Physics.CheckCapsule(footCollider.bounds.center,
                             new Vector3(footCollider.bounds.center.x,
                                         footCollider.bounds.min.y,
                                         footCollider.bounds.center.z),
                             footCollider.radius * 0.9f,groundLayers);
    }

    private Vector2 SquareToCircle(Vector2 vector2)
    {
        Vector2 newVector2 = Vector2.zero;
        newVector2.x = vector2.x * Mathf.Sqrt(1 - (vector2.y * vector2.y) / 2);
        newVector2.y = vector2.y * Mathf.Sqrt(1 - (vector2.x * vector2.x) / 2);
        return newVector2;
    }

    public void SetPlayerPosition(Vector3 position)
    {
        if (canMove)
        {
            this.gameObject.transform.position = position;
            this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
