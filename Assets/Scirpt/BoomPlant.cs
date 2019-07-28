using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomPlant : MonoBehaviour
{
    public float ExplosionDelayTime;
    public float ExplosionForce;
    public float ExlposionRadius;
    public int Damage;
    public ParticleSystem ps;

    private List<GameObject> CHAGameObjects;
    private SphereCollider Collider;

    private void Awake()
    {
        CHAGameObjects = new List<GameObject>();
        Collider = this.GetComponent<SphereCollider>();
        Collider.radius = ExlposionRadius;
    }
    private void Start()
    {
        Invoke("Boom", ExplosionDelayTime);
    }

    private void Boom()
    {

        AudioSource ads = Instantiate( this.GetComponent<AudioSource>(),transform.position, Quaternion.identity);
        ads.Play();
        Destroy(ads.gameObject, ads.clip.length);

        //this.GetComponent<AudioSource>().Play()
        if (ps == null) { return; }
        ParticleSystem ps1 = Instantiate(ps, transform.position, Quaternion.identity) as ParticleSystem;
        ps1.Play();
        Destroy(ps1.gameObject, ps1.main.startLifetime.constant);

        foreach (GameObject chaGameObject in CHAGameObjects)
        {
            Debug.Log("do damage");
            switch (chaGameObject.tag)
            {
                case "Woodie":
                    chaGameObject.GetComponent<Rigidbody>().velocity += (chaGameObject.transform.position - this.transform.position).normalized * ExplosionForce;
                    WoodieStat.instance.takeDamage(Damage);
                    break;
                case "Enemy":
                    chaGameObject.GetComponent<Rigidbody>().velocity += (chaGameObject.transform.position - this.transform.position).normalized * ExplosionForce;
                    chaGameObject.GetComponent<EnemyStat>().takeDamage(Damage);
                    break;
                case "Friend":
                    chaGameObject.GetComponent<Rigidbody>().velocity += (chaGameObject.transform.position - this.transform.position).normalized * ExplosionForce;
                    chaGameObject.GetComponent<EnemyStat>().takeDamage(Damage);
                    break;
                case "Destoryable":
                    //TO DO
                    //Debug.Log("Found destoryable");
                    chaGameObject.GetComponent<Destroyable>().DestoryObject();
                    break;
                default:
                    break;
            }
        }

       // Destroy(this.gameObject, 1);
        Destroy(this.gameObject);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other)
        {
            if (other.gameObject.tag == "Woodie" || other.gameObject.tag == "Enemy" || other.gameObject.tag == "Friend" || other.gameObject.tag == "Destoryable")
            {
                for (int i = 0; i < CHAGameObjects.Count; i++)
                {
                    if (other.gameObject==CHAGameObjects[i])
                    {
                        return;
                    }
                }
                Debug.Log(other.gameObject.tag);
                CHAGameObjects.Add(other.gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other)
        {
            if (other.gameObject.tag == "Woodie" || other.gameObject.tag == "Enemy" || other.gameObject.tag == "Friend" || other.gameObject.tag == "Destoryable")
            {
                for (int i = 0; i < CHAGameObjects.Count; i++)
                {
                    if (other.gameObject == CHAGameObjects[i])
                    {
                        CHAGameObjects.RemoveAt(i);
                        return;
                    }
                }
            }
        }
    }
}
