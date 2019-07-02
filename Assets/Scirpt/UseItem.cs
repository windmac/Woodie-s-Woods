using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour
{
    public GameObject item;
    public int indication = 0;//0表示斧头，1表示浇水器，2表示怪物种子，3表示蔓藤种子

    // Start is called before the first frame update
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

        if (Input.GetKeyDown(KeyCode.C))
        {
            //扔斧头
            if (indication == 0)
            {
                GameObject clone;
                clone = Instantiate(item, new Vector3(x,y + 0.5f, z),transform.rotation) as GameObject;
            }


        }
    }
}
