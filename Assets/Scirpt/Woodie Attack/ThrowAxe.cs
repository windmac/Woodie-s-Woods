using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowAxe : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject axe_projectile;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //调整
       
        float x = transform.position.x;
        float y = transform.position.y;
        float z = transform.position.z;
        //扔斧头
        if (Input.GetKeyDown(KeyCode.C)&&GameObject.FindGameObjectsWithTag("Axe").Length == 0)
        {
            

                GameObject clone;
                clone = Instantiate(axe_projectile, new Vector3(x, y + 0.5f, z), transform.rotation) as GameObject;

        }
    }
}
