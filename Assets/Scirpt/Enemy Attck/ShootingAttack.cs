using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingAttack : Attack
{
    public Projectile projectile;
  //  public GameObject projectileSpawn;
    public Transform shoot_position;
    // public float shoot_speed = 1f;
    public int damage = 1;
    public float attack_rate = 1f;
    public bool is_attacking = true;
    public float timeBetweenShoot = 1f;
    private float shootCounter = 1f;
    public float projectile_speed = 2f;
    private Transform target;
    public float projectile_existing_time = 3f;
    

    void Update()
    {
        if (is_attacking)
        {
            //Debug.Log(shootCounter);
            shootCounter -= Time.deltaTime* attack_rate;

            if(shootCounter <=0 &&target!=null)
            {
                shootCounter = timeBetweenShoot;
                Projectile projectile_ref = Instantiate(projectile, shoot_position.position, shoot_position.rotation) as Projectile;
                projectile_ref.speed = projectile_speed;
                //projectile_ref.direction = (target.position- shoot_position.position).normalized;
               Destroy(projectile_ref.gameObject, projectile_existing_time);
            }

        }

    }

    public override void attack(Transform target)
    {
        is_attacking = true;
        this.target = target;
        Debug.Log("Start Attacking");

    }

    public override void stopAttack()
    {
        is_attacking = false;
       // Debug.Log("Stop Attacking");
       // this.target = null;

    }
}


