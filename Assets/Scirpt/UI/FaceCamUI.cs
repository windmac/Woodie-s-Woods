using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamUI : MonoBehaviour
{
    public Camera camera;

    // Start is called before the first frame update
    void Start()
    {
       // camera = Camera.current;
    }

    // Update is called once per frame
    void Update()
    {
        if(camera!=null)
        {
            this.transform.LookAt(camera.transform);
        }
        else
        {
            camera = Camera.current;
        }
        
    }
}
