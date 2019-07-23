using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour
{
    bool back;
    GameObject player;
    GameObject axe;

    Transform rotating_model;
    Vector3 frontOfPlayer_location;

    public float attack_range = 5f;
    public float stay_time = 0.5f;
    public float fly_speed = 20f;
    public float rotation_speed = 0f;
    public int damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        back = false;

        player = GameObject.Find("Woodie");
        axe = GameObject.Find("Axe");

        axe.GetComponent<MeshRenderer>().enabled = false;

        //rotating_model = gameObject.transform.GetChild(0);
        rotating_model = gameObject.transform;

        frontOfPlayer_location = new Vector3(player.transform.position.x,
                                             player.transform.position.y+0.5f ,
                                             player.transform.position.z)
                                  +player.transform.forward* attack_range;

        StartCoroutine(Boom());
    }

    IEnumerator Boom()
    {
        back = true;
        yield return new WaitForSeconds(stay_time);
        back = false;
    }

    // Update is called once per frame
    void Update()
    {
        rotating_model.transform.Rotate(0, Time.deltaTime * rotation_speed, 0);

        if(back)
        {
            transform.position = Vector3.MoveTowards(transform.position, frontOfPlayer_location, Time.deltaTime * fly_speed);
        }
        if(!back)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, player.transform.position.y + 0.5f, player.transform.position.z), Time.deltaTime * fly_speed);
        }
        if(!back&&Vector3.Distance(player.transform.position,transform.position)<0.8)
        {
            axe.GetComponent<MeshRenderer>().enabled = true;
            Destroy(this.gameObject);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
       // Debug.Log(collision.transform.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {
            Debug.Log(other.transform.name + " Damaged");

            other.GetComponent<EnemyStat>().takeDamage(damage);
        }
    }
}
