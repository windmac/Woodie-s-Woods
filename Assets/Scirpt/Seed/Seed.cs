using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject plant;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void growth()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        float z = transform.position.z;

        GameObject clone = Instantiate(plant, new Vector3(x, y+0.2f, z), transform.rotation) as GameObject;

        Debug.Log("Growth");

        Destroy(this.gameObject);
    }
}
