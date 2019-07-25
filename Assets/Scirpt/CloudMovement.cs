using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class CloudMovement : MonoBehaviour
{
    [SerializeField] Vector3 movementVector = new Vector3(0f, 10f, 10f);
    [Range(0, 1)] [SerializeField] float movementFactor;
    [SerializeField] float period = 2f;

    Vector3 startingPos;

    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon) { return; }
        Move();
    }

    private void Move()
    {
        float cycles = Time.time / period;
        const float tau = Mathf.PI * 2; // about 6.28
        float rawSinWave = Mathf.Sin(cycles * tau);
        Vector3 offset = movementFactor * movementVector * rawSinWave;
        transform.localPosition = startingPos + offset;
    }

    private void OnTriggerEnter(Collider other)
    {
        print("enter");
        if (other.tag == "Woodie")
        {
            other.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Woodie")
        {
            other.transform.parent = null;
        }
    }
}
