using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingCamera : MonoBehaviour
{

    public float rotation_speed = 5f;
    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0, Time.deltaTime * rotation_speed, 0);
    }
}
